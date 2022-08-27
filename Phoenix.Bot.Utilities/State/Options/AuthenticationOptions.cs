﻿namespace Phoenix.Bot.Utilities.State.Options
{
    public class AuthenticationOptions
    {
        public string Phone { get; set; } = null!;
        public int PhoneOwnerId { get; set; }
        public bool IsOwnerAuthentication { get; set; }
    }
}
