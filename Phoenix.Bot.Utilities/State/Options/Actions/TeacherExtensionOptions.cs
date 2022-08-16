using Phoenix.Bot.Utilities.Actions;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class TeacherExtensionOptions : ActionOptions
    {
        public BotAction ExtensionAction { get; set; } = BotAction.Exercises;

        private const string ExtensionImageBaseUrl = "https://bot.askphoenix.gr/assets/";
        private const string ExtensionButtonBaseUrl = "https://teacher.askphoenix.gr/teacher/";

        public const string ExerciseImageUrl = ExtensionImageBaseUrl + "exercise_bg.png";
        public const string ExamImageUrl = ExtensionImageBaseUrl + "exam_bg.png";

        public const string ExerciseButtonUrl = ExtensionButtonBaseUrl + "homework";
        public const string ExamButtonUrl = ExtensionButtonBaseUrl + "exams";

        public TeacherExtensionOptions()
            : base()
        {
        }

        public TeacherExtensionOptions(ActionOptions actionOptions)
            : base(actionOptions)
        {
        }
    }
}
