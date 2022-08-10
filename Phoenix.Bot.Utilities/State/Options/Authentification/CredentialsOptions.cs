using Newtonsoft.Json;
using Phoenix.DataHandle.Main.Models;

namespace Phoenix.Bot.Utilities.State.Options.Authentification
{
    public class CredentialsOptions
    {
        public string Phone { get; set; } = null!;
        public bool IsOwnerAuthentication { get; set; }
        public int PhoneOwnerUserId { get; set; }
        public int? VerifiedUserId { get; set; }
        public bool Verified => this.VerifiedUserId.HasValue;
        
        public Dictionary<OneTimeCode, int> Codes { get; }

        public CredentialsOptions()
            : this(new())
        {
        }

        [JsonConstructor]
        protected CredentialsOptions(Dictionary<OneTimeCode, int> codes)
        {
            this.Codes = codes;
        }
    }
}
