﻿using Phoenix.DataHandle.Utilities;

namespace Phoenix.Bot.Utilities.Dialogs.Helpers
{
    public static class CodeGenHelper
    {
        public static int GenerateCode(uint digitsNum = 4)
        {
            if (digitsNum > 9)
                throw new Exception("The number of digits must be less than or equal to 9.");

            int min = (int)Math.Pow(10, digitsNum - 1);
            int max = min * 10 - 1;

            return new Random().Next(min, max);
        }

        public static string GenerateAlphaCode(string token, uint alphaNum = 2, uint digitsNum = 4)
        {
            return token[..(int)alphaNum].ToUnaccented().ToUpper() + GenerateCode(digitsNum);
        }

        public static string GeneratePassCode(uint size)
        {
            char[] invalidPasswordChars = { 'l', 'I', 'O', '0', '1' };

            string passcode = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            passcode = new string(passcode.Where(
                c => !invalidPasswordChars.Contains(c) && char.IsLetterOrDigit(c)).ToArray())[..(int)size];

            return passcode;
        }
    }
}
