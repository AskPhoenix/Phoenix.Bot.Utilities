using Phoenix.Language.Bot.Types.BotError;

namespace Phoenix.Bot.Utilities.Errors
{
    public enum BotError
    {
        Unknown = 0,

        SchoolNotFound = BotErrorCodeBases.SchoolErrorCodesBase,
        SchoolNotConnected,

        UserNotFound = BotErrorCodeBases.UserErrorCodesBase,
        UserNotValid,
        UserPhoneNotFound,
        UserNotSubscribedToSchool,
        UserNotEnrolledToCourses,
        AffiliatedUserNotEnrolledToCourses,
        ParentHasNoAffiliations,
        UserNotAcceptedTerms,
        UserHasNoExams,
        UserHasNoLectures,

        RoleNotValid = BotErrorCodeBases.RoleErrorCodesBase,

        ActionNotAvailable = BotErrorCodeBases.ActionErrorCodesBase,
        ActionForbidden,

        AuthFailed = BotErrorCodeBases.AuthErrorCodesBase,
        AuthMaxFails,

        CourseHasNoExams = BotErrorCodeBases.CourseErrorCodesBase,
        CourseHasNoLectures
    }

    public static class BotErrorCodeBases
    {
        public const int GeneralErrorCodesBase = 1;
        public const int SchoolErrorCodesBase = 100;
        public const int UserErrorCodesBase = 200;
        public const int RoleErrorCodesBase = 300;
        public const int ActionErrorCodesBase = 400;
        public const int AuthErrorCodesBase = 500;
        public const int CourseErrorCodesBase = 600;
    }

    public static class BotErrorExtensions
    {
        public static bool IsGeneralError(this BotError me) =>
            (int)me >= BotErrorCodeBases.GeneralErrorCodesBase && (int)me < BotErrorCodeBases.SchoolErrorCodesBase;
        public static bool IsSchoolError(this BotError me) =>
            (int)me >= BotErrorCodeBases.SchoolErrorCodesBase && (int)me < BotErrorCodeBases.UserErrorCodesBase;
        public static bool IsUserError(this BotError me) =>
            (int)me >= BotErrorCodeBases.UserErrorCodesBase && (int)me < BotErrorCodeBases.RoleErrorCodesBase;
        public static bool IsRoleError(this BotError me) =>
            (int)me >= BotErrorCodeBases.RoleErrorCodesBase && (int)me < BotErrorCodeBases.ActionErrorCodesBase;
        public static bool IsActionError(this BotError me) =>
            (int)me >= BotErrorCodeBases.ActionErrorCodesBase && (int)me < BotErrorCodeBases.AuthErrorCodesBase;
        public static bool IsAuthError(this BotError me) =>
            (int)me >= BotErrorCodeBases.AuthErrorCodesBase && (int)me < BotErrorCodeBases.CourseErrorCodesBase;
        public static bool IsCourseError(this BotError me) => (int)me >= BotErrorCodeBases.CourseErrorCodesBase;

        public static BotError[] AllBotErrors => Enum.GetValues<BotError>();
        public static BotError[] GeneralBotErrors => AllBotErrors.Where(e => e.IsGeneralError()).ToArray();
        public static BotError[] SchoolBotErrors => AllBotErrors.Where(e => e.IsSchoolError()).ToArray();
        public static BotError[] UserBotErrors => AllBotErrors.Where(e => e.IsUserError()).ToArray();
        public static BotError[] RoleBotErrors => AllBotErrors.Where(e => e.IsRoleError()).ToArray();
        public static BotError[] ActionBotErrors => AllBotErrors.Where(e => e.IsActionError()).ToArray();
        public static BotError[] AuthBotErrors => AllBotErrors.Where(e => e.IsAuthError()).ToArray();
        public static BotError[] CourseBotErrors => AllBotErrors.Where(e => e.IsCourseError()).ToArray();

        public static string GetMessage(this BotError me)
        {
            return me switch
            {
                BotError.Unknown => ErrorMessageResources.Unknown,

                BotError.SchoolNotFound => ErrorMessageResources.SchoolNotFound,
                BotError.SchoolNotConnected => ErrorMessageResources.SchoolNotConnected,

                BotError.UserNotFound => ErrorMessageResources.UserNotFound,
                BotError.UserNotValid => ErrorMessageResources.UserNotValid,
                BotError.UserPhoneNotFound => ErrorMessageResources.UserPhoneNotFound,
                BotError.UserNotSubscribedToSchool => ErrorMessageResources.UserNotSubscribedToSchool,
                BotError.UserNotEnrolledToCourses => ErrorMessageResources.UserNotEnrolledToCourses,
                BotError.AffiliatedUserNotEnrolledToCourses => ErrorMessageResources.AffiliatedUserNotEnrolledToCourses,
                BotError.ParentHasNoAffiliations => ErrorMessageResources.ParentHasNoAffiliations,
                BotError.UserNotAcceptedTerms => ErrorMessageResources.UserNotAcceptedTerms,
                BotError.UserHasNoExams => ErrorMessageResources.UserHasNoExams,
                BotError.UserHasNoLectures => ErrorMessageResources.UserHasNoLectures,

                BotError.RoleNotValid => ErrorMessageResources.RoleNotValid,

                BotError.ActionNotAvailable => ErrorMessageResources.ActionNotAvailable,
                BotError.ActionForbidden => ErrorMessageResources.ActionForbidden,

                BotError.AuthFailed => ErrorMessageResources.AuthFailed,
                BotError.AuthMaxFails => ErrorMessageResources.AuthMaxFails,

                BotError.CourseHasNoExams => ErrorMessageResources.CourseHasNoExams,
                BotError.CourseHasNoLectures => ErrorMessageResources.CourseHasNoLectures,
                _ => ErrorMessageResources.Unknown
            };
        }

        public static string GetSolution(this BotError me)
        {
            return me switch
            {
                BotError.SchoolNotFound => ErrorSolutionResources.SchoolNotFound,
                BotError.SchoolNotConnected => ErrorSolutionResources.SchoolNotConnected,

                BotError.UserNotFound => ErrorSolutionResources.UserNotFound,
                BotError.UserNotValid => ErrorSolutionResources.UserNotValid,
                BotError.UserPhoneNotFound => ErrorSolutionResources.UserPhoneNotFound,
                BotError.UserNotSubscribedToSchool => ErrorSolutionResources.UserNotSubscribedToSchool,

                BotError.ActionNotAvailable => ErrorSolutionResources.ActionNotAvailable,
                BotError.ActionForbidden => ErrorSolutionResources.ActionForbidden,

                BotError.AuthFailed => ErrorSolutionResources.AuthFailed,
                BotError.AuthMaxFails => ErrorSolutionResources.AuthMaxFails,

                _ => ErrorSolutionResources.Default
            };
        }
    }
}
