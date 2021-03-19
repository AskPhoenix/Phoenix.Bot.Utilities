using System;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class AuthenticationOptions
    {
        public bool IsOwnerVerification { get; set; }
        public string Phone { get; set; }
        public Dictionary<int, string> Codes { get; set; }
        public Dictionary<int, DateTimeOffset?> CodesCreatedAt { get; set; }
        public bool Verified { get; set; }
        public string VerifiedCode { get; set; }

        public const int CodeDuration = 5;
    }
}
