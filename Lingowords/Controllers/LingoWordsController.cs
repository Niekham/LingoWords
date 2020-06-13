using System.IO.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Lingowords.Controllers
{
    public class LingowordsController : Controller
    {
        private readonly ILogger<LingowordsController> _logger;

        private readonly IProcessor _processor;

        public LingowordsController(ILogger<LingowordsController> logger, IProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [Route("/")]
        public IActionResult Index()
        {   
            return View();
        }

        [HttpGet]
        [Route("Word")]
        public string Word( string language = "DUTCH" )
        {
            return this.RandomWord( language );
        }

        [HttpGet]
        [Route("WordCommon")]
        public string WordCommon( string language = "DUTCH" )
        {
            return this.RandomWord( language, true );
        }

        private string RandomWord( string language, bool common = false ){
            IList<string> words = _processor.ListWords(language, common).WordsList();
            Random rnd = new Random();

            string value = words[rnd.Next(words.Count)];
            return value;
        }

        [HttpGet]
        [Route("List")]
        public string List( string language = "DUTCH" )
        {
            return JsonSerializer.Serialize(_processor.ListWords( language ).WordsList());
        }

        [HttpGet]
        [Route("ListCommon")]
        public string ListCommon( string language = "DUTCH" )
        {
            return JsonSerializer.Serialize(_processor.ListWords( language, true ).WordsList());
        }
    }
}
