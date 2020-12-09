namespace Phoenix.Bot.Utilities.State.Dialogs
{
    public class CredentialsOptions
    {
        public string Phone { get; set; }
        public bool HasCode { get; set; }
        public int? Code { get; set; }
    }
}
