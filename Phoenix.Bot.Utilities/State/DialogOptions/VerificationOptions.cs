namespace Phoenix.Bot.Utilities.State.Dialogs
{
    public class VerificationOptions
    {
        public bool IsOwnerVerification { get; set; }
        public int? UserToVerifyId { get; set; }
        public string Phone { get; set; }
        public bool Verified { get; set; }
    }
}
