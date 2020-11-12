using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Miscellaneous
{
    public static class ArithmeticExtensions
    {
        public static int[] GetDigitsArray(this int value)
        {
            var digits = new Stack<int>();

            for (; value > 0; value /= 10)
                digits.Push(value % 10);

            return digits.ToArray();
        }
    }
}
