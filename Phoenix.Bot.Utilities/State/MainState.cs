using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State
{
    public struct MainState
    {
        public bool RoleChecked { get; set; }
        public bool HasMultipleRoles { get; set; }
        public Role SelectedRole { get; set; }
    }
}
