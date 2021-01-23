namespace Phoenix.Bot.Utilities.Linguistic
{
    public enum Command
    {
        NoCommand = 0,

        // Channels related: [10, 20)
        GetStarted = 10,

        // General: [20, 30)
        Greeting = 20,
        Home,
        Feedback,
        Cancel,
        Reset,
        
        // User's role specific: [30, 40)
        Help = 30,
        Exercises,
        Exams,
        Schedule
    }
}
