namespace Phoenix.Bot.Utilities.Linguistic
{
    public enum Command
    {
        NoCommand = 0,

        // Channel related: [10, 20)
        GetStarted = 10,

        // General: [20, 30)
        Greeting = 20,
        Home,
        Cancel,
        Reset,
        
        // Action related: [30, 40)
        Exercises = 30,
        Exams,
        Schedule,
        Help,
        Feedback
    }
}
