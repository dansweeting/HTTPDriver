using System;
using System.Linq;

namespace HTTPDriver
{
    public static class UrlExtensions
    {
        /// <param name="currentUrl">Current absolute url</param>
        /// <param name="relative">Relative destination url</param>
        /// <returns></returns>
        public static string FromRelativeUrl(this string currentUrl, string relative)
        {
            if (LooksLikeFolderUrl(currentUrl) &&
                currentUrl.Last() != '/')
                currentUrl += "/";

            return new Uri(
                new Uri(currentUrl, UriKind.Absolute), 
                new Uri(relative, UriKind.Relative))
            .AbsoluteUri;
        }

        private static bool LooksLikeFolderUrl(string baseUrl)
        {
            var uri = new Uri(baseUrl);
            if ( !string.IsNullOrEmpty(uri.Fragment) ||
                 !string.IsNullOrEmpty(uri.Query))
                return false;

            if (uri.PathAndQuery == "/")
                return true;

            var finalSegment = baseUrl.Split('/').Last();    
            return !(finalSegment.Contains('.') || finalSegment.Contains('?'));
        }
    }
}