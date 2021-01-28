using Microsoft.Bot.Schema;
using Phoenix.DataHandle.Main;
using Phoenix.DataHandle.Main.Models;
using Phoenix.DataHandle.Repositories;

namespace Phoenix.Bot.Utilities.Miscellaneous
{
    public static class RepositoryExtensions
    {
        public static AspNetUsers FindUserFromBotActivity(this AspNetUserRepository repository, Activity activity)
        {
            return repository.FindUserFromLogin(activity.ChannelId.ToLoginProvider(), activity.From.Id);
        }
    }
}
