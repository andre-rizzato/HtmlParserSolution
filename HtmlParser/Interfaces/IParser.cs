using HtmlParser.Enums;
using HtmlParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlParser.Interfaces
{
    /// <summary>
    /// Represents a parse type
    /// </summary>
    public interface IParser
    {
        ParsingTypes ParsingType { get;}

        IEnumerable<string> GetImages(Uri uri);

        IDictionary<string, int> GetWords(Uri uri);

    }
}
