using HtmlParser.Factory;
using HtmlParser.Interfaces;
using HtmlParser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace HtmlParser.Controllers
{
    public class ParseController : Controller
    {

        private IUtils _utils;

        private readonly ILogger<ParseController> _logger;
        public ParseController(ILogger<ParseController> logger, IUtils utils)
        {
            _logger = logger;
            _utils = utils;
        }
        public IActionResult ImageParse()
        {
            return View();

        }
        public IActionResult ImageParseResults(InputModel model)
        {
              //validate model
           if (ModelState.IsValid)
            {
                ImageParseResultsModel imagesViewModel = new ();

                _logger.LogDebug("Validating the uri informed.");

                if (!Uri.TryCreate(model.Field.Trim(), UriKind.RelativeOrAbsolute, out Uri result))
                {
                    //if it's not possible to create an uri, add errors to the modelstate and returns the initial view 
                    ModelState.AddModelError("Undefined error", $"It was not possible continue the process");
                    return View("ImageParse", model);
                }
                try
                {  
                    //sanitizes the uri
                    result = _utils.GetAbsoluteUri(result);

                    //call the parser factory for a proper instance
                    var parser = new ParserFactory().Create((Enums.ParsingTypes) model.ParsingType);

                    //get the images
                    var imgs = parser.GetImages(result);

                    //give it to the model
                    if (imgs.Any())                        
                        imagesViewModel = new ImageParseResultsModel() { Images = imgs };

                        return View("ImageParseResults", imagesViewModel);

                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Empty Object", $"It was not possible to retrieve images from the informed url: {result.AbsoluteUri}");
                    _logger.LogError($"Message: {e.Message}, Inner message : {e.InnerException}");
                    return View("ImageParse", model);

                }

            }

            return View("ImageParse", model);
        }
        public IActionResult WordsParse()
        {
            return View();
        }
        public IActionResult WordsParseResults(InputModel model)
        {
            if (ModelState.IsValid)
            {
                WordsParseResultsViewModel wordsViewModel = new WordsParseResultsViewModel();

                _logger.LogDebug("Validating the uri informed.");

                if (!Uri.TryCreate(model.Field.Trim(), UriKind.RelativeOrAbsolute, out Uri result))
                {
                    ModelState.AddModelError("Undefined error", $"It was not possible continue the process");
                    return View("WordsParse", model);
                }
                try
                {

                    result = _utils.GetAbsoluteUri(result);
                   
                    var parser = new ParserFactory().Create((Enums.ParsingTypes)model.ParsingType);

                    var  wrds = parser.GetWords(result);
              

                    if (wrds.Any())
                    {
                        //sets the viewmodel and the grafs model , also configures the javascript call for graphs rendering
                        wordsViewModel = new WordsParseResultsViewModel() { WordsRanking = wrds };

                        SetGraphModel(wrds);

                    }

                    return View("WordsParseResults", wordsViewModel);

                }
                catch (Exception ex)
                {  
                    ModelState.AddModelError("Empty Object", $"It was not possible to retrieve data from the informed url: {result.AbsoluteUri}");
                    _logger.LogError($"Message: {ex.Message}, Inner message : {ex.InnerException}");
                    return View("WordsParse", model);
                }

            }

           
            return View("WordsParse", model);

        }

        //Sets graphs model and sets the javascrip call
        private void SetGraphModel(IDictionary<string, int> wrds)
        {
            var data = new ArrayList(wrds.Count());

            var categories = new ArrayList(wrds.Count());

            foreach (var item in wrds)
            {
                categories.Add(item.Key);
                data.Add(item.Value);
            }

            var chartModeData = new { data = data.ToArray(), categories = categories.ToArray() };

            var chartdataJson = JsonSerializer.Serialize(chartModeData);

            ViewBag.JavaScriptFunction = $"RenderGraph({chartdataJson});";
        }
    }
}
