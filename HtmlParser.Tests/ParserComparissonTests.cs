using HtmlParser.Enums;
using HtmlParser.Factory;
using HtmlParser.Services;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Linq;

namespace HtmlParser.Tests
{


    [TestFixture]
     public class ParserComparissonTests
    {
        ILogger<ParserComparissonTests> logger = new Logger<ParserComparissonTests>(new LoggerFactory());

        [Test]
        [TestCase("https://www.uol.com.br")]
        [TestCase("https://www.comune.osiosotto.bg.it/it/page/anagrafe-stato-civile-elettorale-e-leva")]
        [TestCase("https://visualstudiomagazine.com/articles/2015/06/19/tdd-asp-net-mvc-part-4-unit-testing.aspx")]
        [TestCase("https://www.borah.com.br")]
        [TestCase("https://www.terra.com.br")]
        [TestCase("https://www.corriere.it")]
        [TestCase("https://www.repubblica.it/")]
        [TestCase("https://www.estadao.com.br")]
        [TestCase("https://www.folha.uol.com.br/")]
        [TestCase("https://www.youtube.com/")]
       
        public void Images_AssertTheEqualResults(string url)
        {
            // Arrange
            var parserAgility = new ParserFactory().Create(ParsingTypes.Agility);
            var parserRegex = new ParserFactory().Create(ParsingTypes.Regex);
            // Act
            var utilsAgility = parserAgility.GetImages(new Uri(url));
            var utilslRegex = parserRegex.GetImages(new Uri(url));
            //Assert

            Assert.That(utilsAgility.Count(), Is.EqualTo(utilslRegex.Count()));
          

        }

        [Test]
        [TestCase("https://www.uol.com.br")]
        [TestCase("https://www.comune.osiosotto.bg.it/it/page/anagrafe-stato-civile-elettorale-e-leva")]
        [TestCase("https://visualstudiomagazine.com/articles/2015/06/19/tdd-asp-net-mvc-part-4-unit-testing.aspx")]
        [TestCase("https://www.borah.com.br")]
        [TestCase("https://www.terra.com.br")]
        [TestCase("https://www.corriere.it")]
        [TestCase("https://www.repubblica.it/")]
        [TestCase("https://www.estadao.com.br")]
        [TestCase("https://www.folha.uol.com.br/")]
        [TestCase("https://www.youtube.com/")]

        public void Words_AssertTheEqualResults(string url)
        {
            // Arrange
            var parserAgility = new ParserFactory().Create(ParsingTypes.Agility);
            var parserRegex = new ParserFactory().Create(ParsingTypes.Regex);

            // Act
            var utilsAgility = parserAgility.GetWords(new Uri(url));
            var utilslRegex = parserRegex.GetWords(new Uri(url));

            foreach (var item in utilsAgility)
            {
                logger.LogDebug($"utilsAgility Key: {item.Key} Vlue: {item.Value}");
            }

            foreach (var item in utilslRegex)
            {
                logger.LogDebug($"utilslRegex Key: {item.Key} Vlue: {item.Value}");
            }

            var AreKeysEqual = utilsAgility.OrderBy(kvp => kvp.Key)
                        .SequenceEqual(utilslRegex.OrderBy(kvp => kvp.Key));

            var AreValuesEqual = utilsAgility.OrderBy(kvp => kvp.Value)
                        .SequenceEqual(utilslRegex.OrderBy(kvp => kvp.Value));
            //Assert
            Assert.IsTrue(AreKeysEqual && AreValuesEqual);

        }


    }
}
