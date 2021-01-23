namespace Phoenix.Bot.Utilities.Linguistic
{
    public enum Command
    {
        // Invalid: [-10, 0)
        Invalid = -10,

        // Channels related: [0, 10)
        GetStarted = 0,

        // General: [10, 20)
        Greeting = 10,
        Home,
        Feedback,
        Cancel,
        Reset,
        
        // User's role specific: [20, 30)
        Help = 20,
        Exercises,
        Exams,
        Schedule
    }
}
