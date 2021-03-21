using Microsoft.Bot.Schema;
using Newtonsoft.Json.Linq;
using Phoenix.Bot.Utilities.Channels.Facebook.FacebookEvents;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Channels.Facebook
{
    public static class ChannelDataFactory
    {
        public static JObject Template(Template template)
        {
            return JObject.FromObject(new
            {
                attachment = new
                {
                    type = "template", 
                    payload = template 
                }
            });
        }

        public static JObject Attachment(HeroCard heroCard, 
            string imageAspectRatio = "horizontal",
            string webviewHeightRatio = "full",
            bool messengerExtensions = false,
            string fallback_Url = null,
            string webviewShareButton = null)
        {
            List<Button> buttons = new List<Button>(heroCard.Buttons.Count);
            foreach (CardAction button in heroCard.Buttons)
            {
                if (button.Type == ActionTypes.OpenUrl)
                {
                    buttons.Add(new UrlButton(title: button.Title, url: button.Value.ToString())
                    {
                        WebviewHeightRatio = webviewHeightRatio,
                        MessengerExtensions = messengerExtensions,
                        FallbackUrl = fallback_Url,
                        WebviewShareButton = webviewShareButton
                    });
                }
                else
                {
                    buttons.Add(new PostbackButton(title: button.Title, payload: button.Value.ToString()));
                }
            }

            UrlAction urlAction = null;
            if (heroCard.Tap != null)
                urlAction = new UrlAction(heroCard.Tap.Value.ToString(), webviewHeightRatio, messengerExtensions, fallback_Url, webviewShareButton);

            var template = new GenericTemplate()
            {
                ImageAspectRatio = imageAspectRatio,
                Elements = new GenericElement[1]
                {
                    new GenericElement()
                    {
                        Title = heroCard.Title,
                        Subtitle = heroCard.Subtitle,
                        ImageUrl = heroCard.Images?.First().Url,
                        DefaultAction = urlAction,
                        Buttons = buttons.ToArray()
                    }
                }
            };

            return Template(template);
        }
    }
}
