using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.State.Options.Authentification
{
    public class CredentialsOptions
    {
        public const int CodeExpiresAfterMins = 5;

        public string Phone { get; set; }
        public bool IsOwnerAuthentication { get; set; }
        public int PhoneOwnerUserId { get; set; }
        public int? VerifiedUserId { get; set; }
        public bool Verified => this.VerifiedUserId.HasValue;
        
        public Dictionary<string, int> Codes { get; }
        public Dictionary<string, DateTimeOffset> CodesCreatedAt { get; }

        public CredentialsOptions()
        {
            this.Codes = new Dictionary<string, int>();
            this.CodesCreatedAt = new Dictionary<string, DateTimeOffset>();
        }

        [JsonConstructor]
        protected CredentialsOptions(Dictionary<string, int> codes, Dictionary<string, DateTimeOffset> codesCreatedAt)
        {
            this.Codes = codes;
            this.CodesCreatedAt = codesCreatedAt;
        }

        public bool TryFindCode(string code, out int userId)
        {
            bool codeExists = this.Codes.ContainsKey(code);
            userId = codeExists ? this.Codes[code] : 0;

            return codeExists;
        }

        public bool IsCodeExpired(string code)
        {
            return (DateTimeOffset.UtcNow - this.CodesCreatedAt[code]).Duration().Minutes >= CodeExpiresAfterMins;
        }
    }
}
