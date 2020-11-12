using Newtonsoft.Json.Linq;

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
    }
}
