namespace Phoenix.Bot.Utilities.Channels.Facebook
{
    public class FacebookException : Exception
    {
        public FacebookException() : base("There was a problem with Facebook's Channel Data.") { }

        public FacebookException(string message) : base(message) { }
    }
}
