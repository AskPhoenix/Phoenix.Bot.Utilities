namespace Phoenix.Bot.Utilities.Linguistic
{
    public static class Greek
    {
        public static string NameVocative(string name)
        {
            if (!name.EndsWith('ς'))
                return name;

            char letter = name.Substring(name.Length - 2, 1).ToCharArray()[0];

            if (letter == 'ο')
                letter = 'ε';
            else if (letter == 'ό')
                letter = 'έ';

            return name[..^2] + letter;
        }

        public static string DayArticle(DayOfWeek day, bool accusative = true)
        {
            if (accusative)
            {
                if (day == DayOfWeek.Monday)
                    return "τη";
                else if (day == DayOfWeek.Saturday)
                    return "το";
                else
                    return "την";
            }
            else
            {
                if (day == DayOfWeek.Saturday)
                    return "το";
                else
                    return "η";
            }
        }
    }
}
