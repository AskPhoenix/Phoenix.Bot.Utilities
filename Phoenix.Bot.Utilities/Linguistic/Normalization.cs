using System.Globalization;
using System.Linq;
using System.Text;

namespace Phoenix.Bot.Utilities.Linguistic
{
    public static class Normalization
    {
        public static string ToUnaccented(this string str)
        {
            string fullCanonicalDecompositionNormalized = str.Normalize(NormalizationForm.FormD);
            var unaccented = fullCanonicalDecompositionNormalized.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);

            return new string(unaccented.ToArray());
        }

        public static string TrimEmojis(this string str)
            => new string(str.Where(c => !char.IsSurrogate(c) && !char.IsSymbol(c)).ToArray()).Trim();

#nullable enable
        public static bool IsTheSameWith(this string strA, string? strB, CultureInfo? culture, CompareOptions options)
            => string.Compare(strA, strB, culture, options) == 0;
#nullable disable
    }
}
