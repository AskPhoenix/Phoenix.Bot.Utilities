using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State
{
    public struct MainState
    {
        public bool RolesChecked { get; set; }
        public Role[] SelectedRoles { get; set; }
    }
}
