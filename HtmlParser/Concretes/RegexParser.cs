using HtmlParser.Enums;
using HtmlParser.Interfaces;
using HtmlParser.Models;
using HtmlParser.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HtmlParser.Concretes
{
    /// <summary>
    /// Implementation of the <<see cref="IParser"</see>>> interface that uses only Regex from the System.Text.RegularExpressions;"/> 
    /// </summary>
    public class RegexParser : IParser
    {
        IUtils _utils;
        public ParsingTypes ParsingType => ParsingTypes.Regex;

        WebClient WebClient = new WebClient();
        //pattern to be searched
        const string IMAGE_ELEMENT_PATTERN = "<img\\s[^>]*?src\\s*=\\s*['\"]([^'\"]*?)['\"][^>]*?>";

        string page;
        public RegexParser(IUtils utils)
        {
            _utils = utils;
        }
        /// <summary>
        /// Function that returns an enumerable of strings that contains all images gathered from a a given uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public IEnumerable<string> GetImages(Uri uri)
        {
            page = WebClient.DownloadString(uri.AbsoluteUri);
            
            if (!string.IsNullOrEmpty(page))
                foreach (Match item in Regex.Matches(page, IMAGE_ELEMENT_PATTERN))
                {
                    yield return _utils.SetAbsoluteImagePath(item.Value, uri);
                }
        }

        /// <summary>
        /// Function that reutrns a dictionary  that contains the top 10 words occurring in a given uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public IDictionary<string, int> GetWords(Uri uri)
        {
            var page = WebClient.DownloadString(uri.AbsoluteUri);

            var wordsDict = new Dictionary<string, int>();

            string innerHtml = string.Empty;

            //creates an instance of the Regex objectt
            Regex rx = new Regex("<body[^>]*>((.|\n)*)<\\/body>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            //tries to take the body
            var m = rx.Match(page);
 
            //if successful sets the variable  
            if (m.Success)
            {
                innerHtml = m.Groups[1].Value;
            }

            //gets rid of the scripts
            innerHtml = Regex.Replace(innerHtml, "<script.*?</script>", string.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase);

            //takes the tag's innertext 
            var matches = Regex.Matches(innerHtml, "(?<=>)([^<]+)(?=<)");

            //creates one string with all the words 
            var matchesStr = string.Join(string.Empty, matches);

            //sanitizes the string to separate words attached
            for (int ch = 0; ch < matchesStr.Length; ch++)
            {
                if (char.IsUpper(matchesStr[ch]) && char.IsLower(matchesStr[ch - 1]))
                    matchesStr = matchesStr.Insert(ch, " ");
            }

          
            //replaces a great space quantity for just one

            matchesStr = Regex.Replace(matchesStr, @"\s+", " ");

            string wordsclr = string.Empty;

            //gets rid of characters that aren't whitespace or letters/numeric digits

            Regex rgx = new Regex("[^a-zA-Z0-9 -]");

            wordsclr = rgx.Replace(matchesStr, "");

            //creates a array of string and loops thru it ading value quantity in a dictionary
            var wordsStrArray = wordsclr.Split(" ").ToList();

            foreach (var item in wordsStrArray.ToList().Distinct())
            {
                Console.WriteLine(item.ToString().Trim());
                if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                    wordsDict.Add(item, wordsStrArray.Where(w => w == item).Count());
            }

            var orderedWords = wordsDict.AsEnumerable().OrderByDescending(w => w.Value).Take(10);
            //returns it
            return orderedWords.ToDictionary(x => x.Key, x => x.Value);

        }

    }
}

