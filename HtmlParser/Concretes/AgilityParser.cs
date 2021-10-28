using HtmlAgilityPack;
using HtmlParser.Enums;
using HtmlParser.Interfaces;
using HtmlParser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace HtmlParser.Concretes
{      /// <summary>
       /// Implementation of the <<see cref="IParser"</see>>> interface that uses the <seealso cref="https://html-agility-pack.net/"/> />
       /// </summary>
    public class AgilityParser : IParser
    {
        
        IUtils _utils;

        public ParsingTypes ParsingType => ParsingTypes.Agility;

        static WebClient WebClient = new WebClient();

        static string page;

        public AgilityParser(IUtils utils)
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
            //downloads the html docuement to a string
            page = WebClient.DownloadString(uri.AbsoluteUri);

            //checks for null
            if (!string.IsNullOrEmpty(page))
            {
                
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(page);

                //gets a collection of image nodes
                var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//img");

                //loops thru the colection yielding the node with a sanitized image path 
                foreach (var node in htmlNodes)
                {
                    yield return _utils.SetAbsoluteImagePath(node.OuterHtml, uri);
                }
            }
            else
            {
                throw new ArgumentNullException("It was not possible download the webpage.");
            }
        }

        /// <summary>
        /// Function that returns a dictionary  that contains the top 10 words occurring in a given uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public IDictionary<string, int> GetWords(Uri uri)
        {
            //download the page 
            page = WebClient.DownloadString(uri.AbsoluteUri);
            
            //checks for null
            
            if (!string.IsNullOrEmpty(page))
            {
                //object that will be returned
                var wordsDict = new Dictionary<string, int>();

                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(page);

                //gets the body node
                var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body");

                //replaces a great space quantity for just one
                var words = Regex.Replace(htmlNodes.FirstOrDefault().InnerText, @"\s+", " ");

                //gets rid of characters that aren't whitespace or letters/numeric digits
                words = new string((from w in words
                                    where char.IsWhiteSpace(w) || char.IsLetterOrDigit(w)
                                    select w).ToArray());


                //sanitizes the string inserting a space between attached words
                for (int ch = 0; ch < words.Length; ch++)
                {
                    if (char.IsUpper(words[ch]) && char.IsLower(words[ch - 1]))
                        words = words.Insert(ch, " ");

                }

                //creates an array of atring spliting whrere there is a space between words
                var wordsStrArray = words.Split(" ");

                //makes a distinction to eliminate duplications, populates the return object with the word and quantity within the array

                foreach (var item in wordsStrArray.ToList().Distinct())
                {
                    Console.WriteLine(item.ToString().Trim());

                    if (!string.IsNullOrEmpty(item) && !string.IsNullOrWhiteSpace(item))
                        wordsDict.Add(item, wordsStrArray.Where(w => w == item).Count());
                }

                //orders the dictionary and takes 10
                var orderedWords = wordsDict.AsEnumerable().OrderByDescending(w => w.Value).Take(10);

                //returns it
                return orderedWords.ToDictionary(x => x.Key, x => x.Value);

            }
            else
            {
                throw new ArgumentNullException("It was not possible download the webpage.");
            }

        }
    }
}
