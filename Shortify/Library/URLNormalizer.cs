using System;
using System.Text.RegularExpressions;

namespace Shortify.Library
{
    public class URLNormalizer
    {
        public static string Escape(string url)
        {
            return Uri.EscapeUriString(url);
        }
        public static string Normalize(string url)
        {
            string sanitized = url.Trim();
            if (sanitized.Contains('.'))
            {
                if (!Regex.IsMatch(sanitized, @"^https?:\/\/", RegexOptions.IgnoreCase))
                {
                    sanitized = "https://" + sanitized;
                }
            }

            if (Uri.TryCreate(sanitized, UriKind.Absolute, out Uri validatedURL))
            {
                if (validatedURL.Scheme == Uri.UriSchemeHttp || validatedURL.Scheme == Uri.UriSchemeHttps)
                {
                    return validatedURL.ToString();
                }
                else
                {
                    throw new Exception("URL is not a valid http(s) address");
                }
            }
            throw new Exception("Malformed URL");
        }
    }
}
