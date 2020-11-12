using System.Globalization;
using System.Linq;

namespace Phoenix.Bot.Utilities.Linguistic
{
    public static class Synonyms
    {
        public static readonly string[] Greetings = new string[] { "hi", "hello", "γεια", "καλημέρα", "καλησπέρα" };
        public static readonly string[] Help = new string[] { "help", "βοήθεια" };

        public enum Topics
        {
            Greetings,
            Help
        }

        public static bool ContainsSynonyms(this string str, Topics topic)
        {
            var synonyms = typeof(Synonyms).GetField(topic.ToString()).GetValue(null) as string[];
            
            return str.Split(' ').Any(w => synonyms.Any(s => 
                s.IsTheSameWith(w, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase)));
        }

        #nullable enable
        private static bool IsTheSameWith(this string strA, string? strB, CultureInfo? culture, CompareOptions options)
            => string.Compare(strA, strB, culture, options) == 0;
        #nullable disable
    }
}
