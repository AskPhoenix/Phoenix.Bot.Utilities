using Microsoft.Bot.Schema;
using Phoenix.DataHandle.Main;
using Phoenix.DataHandle.Main.Models;
using Phoenix.DataHandle.Repositories;

namespace Phoenix.Bot.Utilities.Miscellaneous
{
    public static class RepositoryExtensions
    {
        public static AspNetUsers FindUserFromLogin(this AspNetUserRepository repository, Activity activity)
        {
            return repository.FindUserFromLogin(activity.ChannelId.ToLoginProvider(), activity.From.Id);
        }

        public static bool AnyLogin(this AspNetUserRepository repository, Activity activity, bool onlyActive = false)
        {
            return repository.AnyLogin(activity.ChannelId.ToLoginProvider(), activity.From.Id, onlyActive);
        }
    }
}
