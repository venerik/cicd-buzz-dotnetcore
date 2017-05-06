using System.Text.RegularExpressions;

namespace Buzz
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string source)
        {
            return Regex.Replace(source.ToLower(), @"\b(\w)", m => m.Value.ToUpper());
        }
    }
}
