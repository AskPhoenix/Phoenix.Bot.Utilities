using Phoenix.DataHandle.Main.Types;

namespace Phoenix.Bot.Utilities.State.Options.Authentification
{
    public class VerificationOptions : AuthenticationOptions
    {
        public OneTimeCodePurpose OTCPurpose { get; set; }

        public VerificationOptions()
            : base()
        {
        }

        public VerificationOptions(AuthenticationOptions authOptions)
        {
            this.Phone = authOptions.Phone;
            this.PhoneOwnerId = authOptions.PhoneOwnerId;
            this.IsOwnerAuthentication = authOptions.IsOwnerAuthentication;
        }
    }
}
