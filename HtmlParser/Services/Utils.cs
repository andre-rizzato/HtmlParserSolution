using HtmlParser.Enums;
using HtmlParser.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace HtmlParser.Services
{
    public class Utils : IUtils
    {

        const string IMAGE_PATH_PATTERN = @"(?<name>src|href)=""(?<value>/[^""]*)""";
        public Utils()
        {

        }

        /// <summary>
        /// sanitizes the image path thats are relatives adding the absolute path
        /// </summary>
        /// <param name="imageTag"></param>
        /// <param name="baseUri"></param>
        /// <returns></returns>
        public string SetAbsoluteImagePath(string imageTag, Uri baseUri)
        {
            var matchEvaluator = new MatchEvaluator(
                match =>
                {
                    var value = match.Groups["value"].Value;
                    if (Uri.TryCreate(baseUri, value, out Uri uri))
                    {
                        return string.Format($"{match.Groups["name"].Value}=\"{uri.AbsoluteUri}\"");
                    }
                    return null;
                });
            return Regex.Replace(imageTag, IMAGE_PATH_PATTERN, matchEvaluator);
        }

        /// <summary>
        /// Checks if the uri does not have the scheme and adds it
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Uri GetAbsoluteUri(Uri uri)
        {
            string originalUri = uri.OriginalString;

            if (!originalUri.StartsWith(Enum.GetName(UriSchemes.http)) || !originalUri.StartsWith(Enum.GetName(UriSchemes.https)))
            {
                var newUri = $"{ Enum.GetName(UriSchemes.http)}://{ originalUri}";

                uri = new Uri(newUri);
            }
            return uri;
        }

    }

}
