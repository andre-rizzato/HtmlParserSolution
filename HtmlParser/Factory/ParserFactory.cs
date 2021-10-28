using HtmlParser.Concretes;
using HtmlParser.Enums;
using HtmlParser.Interfaces;
using System;
using Microsoft.AspNetCore.Mvc;
using HtmlParser.Services;

namespace HtmlParser.Factory
{
    public class ParserFactory
        {
            public IParser Create(ParsingTypes parsingType)
            {
                switch (parsingType)
                {
                    case ParsingTypes.Agility:
                        return new AgilityParser(new Utils());
                    case ParsingTypes.Regex:
                        return new RegexParser(new Utils());
                    default:
                        throw new NotImplementedException($"The type:{Enum.GetName(parsingType)} is not implemented yet. ");
                }
            }
        }

}
