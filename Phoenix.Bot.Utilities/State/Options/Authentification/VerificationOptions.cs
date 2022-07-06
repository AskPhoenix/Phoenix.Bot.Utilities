using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.State.Options.Authentification
{
    public class VerificationOptions : CredentialsOptions
    {
        public string Pin { get; set; } = null!;

        public VerificationOptions(CredentialsOptions credentialsOptions)
            : this(credentialsOptions.Codes, credentialsOptions.CodesCreatedAt)
        {
            this.Phone = credentialsOptions.Phone;
            this.IsOwnerAuthentication = credentialsOptions.IsOwnerAuthentication;
        }

        [JsonConstructor]
        private VerificationOptions(Dictionary<string, int> codes, Dictionary<string, DateTimeOffset> codesCreatedAt)
            : base(codes, codesCreatedAt) { }
    }
}
