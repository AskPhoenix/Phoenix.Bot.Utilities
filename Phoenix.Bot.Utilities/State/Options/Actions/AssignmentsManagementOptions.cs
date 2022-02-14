using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class AssignmentsManagementOptions : ActionOptions
    {
        public BotAction ExtensionAction { get; set; } = BotAction.Exercises;

        // TODO: Change image URLs (upload files somewhere like on a drive)
        private const string ExtensionImageBaseUrl = "https://bot.askphoenix.gr/assets/";
        private const string ExtensionButtonBaseUrl = "https://teacher.askphoenix.gr/teacher/";

        public const string ExerciseImageUrl = ExtensionImageBaseUrl + "exercise_bg.png";
        public const string ExamImageUrl = ExtensionImageBaseUrl + "exam_bg.png";

        public const string ExerciseButtonUrl = ExtensionButtonBaseUrl + "homework";
        public const string ExamButtonUrl = ExtensionButtonBaseUrl + "exams";

        public AssignmentsManagementOptions(ActionOptions actionOptions, BotAction extensionAction)
            : base(actionOptions)
        {
            this.ExtensionAction = extensionAction;
        }

        [JsonConstructor]
        public AssignmentsManagementOptions(int userId, Role userRole) 
            : base(userId, userRole) { }

        public AssignmentsManagementOptions(UserOptions userOptions)
            : base(userOptions) { }
    }
}
