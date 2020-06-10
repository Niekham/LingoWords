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
    [ApiController]
    [Route("[controller]")]
    public class LingowordsController : ControllerBase
    {
        private readonly ILogger<LingowordsController> _logger;

        private readonly IProcessor _processor;

        public LingowordsController(ILogger<LingowordsController> logger, IProcessor processor)
        {
            _logger = logger;
            _processor = processor;

        }

        [HttpGet]
        [Route("Word")]
        public string Word( string language = "DUTCH" )
        {
            IList<string> words = _processor.ListWords(language).WordsList();
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
    }
}
