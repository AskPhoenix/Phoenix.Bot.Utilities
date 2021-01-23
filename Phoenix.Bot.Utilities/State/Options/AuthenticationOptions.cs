namespace Phoenix.Bot.Utilities.State.Options
{
    public class AuthenticationOptions
    {
        public bool IsOwnerVerification { get; set; }
        public string Phone { get; set; }
        public string[] Codes { get; set; }
        public bool Verified { get; set; }
        public string VerifiedCode { get; set; }
    }
}
