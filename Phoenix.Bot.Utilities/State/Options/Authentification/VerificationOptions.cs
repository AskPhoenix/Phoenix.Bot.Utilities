using Newtonsoft.Json;
using Phoenix.DataHandle.Main.Models;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.State.Options.Authentification
{
    public class VerificationOptions : CredentialsOptions
    {
        public string Pin { get; set; } = null!;

        public VerificationOptions(CredentialsOptions credentialsOptions)
            : this(credentialsOptions.Codes)
        {
            this.Phone = credentialsOptions.Phone;
            this.IsOwnerAuthentication = credentialsOptions.IsOwnerAuthentication;
        }

        [JsonConstructor]
        private VerificationOptions(Dictionary<OneTimeCode, int> codes)
            : base(codes) { }
    }
}
