using Phoenix.DataHandle.Utilities;
using Phoenix.Language.Bot.Types.DateLiteral;

namespace Phoenix.Bot.Utilities.Linguistic
{
    public enum DateLiteral
    {
        Yesterday = -1,
        Never = 0,
        Today,
        Tomorrow
    }

    public static class DateLiteralExtensions
    {
        public static string ToFriendlyString(this DateLiteral me)
        {
            return me switch
            {
                DateLiteral.Yesterday   => DateLiteralResources.Yesterday,
                DateLiteral.Today       => DateLiteralResources.Today,
                DateLiteral.Tomorrow    => DateLiteralResources.Tomorrow,
                _                       => string.Empty
            };
        }

        public static DateLiteral[] AllDateLiterals => Enum.GetValues<DateLiteral>();

        private static bool DateLiteralPredicate(DateLiteral l, string str) =>
            l.ToString().Equals(str, StringComparison.OrdinalIgnoreCase) ||
            l.ToFriendlyString().ToUnaccented().Equals(str.ToUnaccented(), StringComparison.OrdinalIgnoreCase);
        
        public static DateLiteral ToDateLiteral(this string me)
        {
            return AllDateLiterals.SingleOrDefault(l => DateLiteralPredicate(l, me));
        }

        public static bool TryToDateLiteral(this string me, out DateLiteral dateLiteral)
        {
            dateLiteral = me.ToDateLiteral();

            return AllDateLiterals.Any(l => DateLiteralPredicate(l, me));
        }
    }
}
