using HtmlParser.Controllers;
using HtmlParser.Enums;
using HtmlParser.Models;
using HtmlParser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace HtmlParser.Tests
{
    public class ControllersTests
    {

       [TestFixture]
        public class ControllersTest
        {
            ILogger<ParseController> logger = new Logger<ParseController>(new LoggerFactory());


            [Test]
            public void CallImageParseResults_Assert_TheReturnViewResultsName()
            {
                // Arrange
                ParseController parseController = new(logger , new Utils());
                var model = new InputModel() { Field= "https://www.uol.com.br" , ParsingType = ParsingTypes.Agility};
                // Act
                var result  = parseController.ImageParseResults(model) as ViewResult;
                // Assert
                Assert.That(result.ViewName , Is.EqualTo("ImageParseResults"));
            }

            [Test]
            public void CallWordsParseResults_Assert_TheReturnViewResultsName()
            {
                // Arrange
                ParseController parseController = new(logger, new Utils());
                var model = new InputModel() { Field = "https://www.uol.com.br", ParsingType = ParsingTypes.Agility};
                // Act
                var result = parseController.WordsParseResults(model) as ViewResult;
                // Assert
                Assert.That(result.ViewName, Is.EqualTo("WordsParseResults"));

            }


        }
    }

}
