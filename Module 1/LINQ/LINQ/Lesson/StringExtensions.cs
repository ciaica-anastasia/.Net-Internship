namespace LINQ
{
    public static class StringExtensions
    {
        public static string GetShortcut(this string fullString)
        {
            if (string.IsNullOrWhiteSpace(fullString))
            {
                return "Smt";
            }
            
            return fullString.Substring(0, 3);
        }
    }
}