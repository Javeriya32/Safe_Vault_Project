using System.Net;
using System.Text.RegularExpressions;

namespace SafeVault.Services
{
    public static class InputSanitizer
    {
        public static string Sanitize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = Regex.Replace(input, "<.*?>", string.Empty);
            input = WebUtility.HtmlEncode(input);
            input = Regex.Replace(input, @"['"";--]", string.Empty);

            return input.Trim();
        }
    }
}
