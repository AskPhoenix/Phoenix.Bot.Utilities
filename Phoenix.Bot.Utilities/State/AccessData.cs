namespace Phoenix.Bot.Utilities.State
{
    public class AccessData
    {
        public int SMSFailedCount { get; set; }
        public int AccessFailedCount { get; set; }
        public string? TeacherPassword { get; set; }
    }

    public static class AccessLimitations
    {
        public const int MaxFails = 5;
    }
}
