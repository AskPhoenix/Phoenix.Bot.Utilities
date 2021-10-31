using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State
{
    public struct MainState
    {
        public bool IsRoleChecked { get; set; }
        public Role SelectedRole { get; set; }
    }
}
