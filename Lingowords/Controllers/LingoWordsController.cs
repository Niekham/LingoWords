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
    public class LingoWordsController : ControllerBase
    {
        private readonly ILogger<LingoWordsController> _logger;

        private readonly IProcessor _processor;

        public LingoWordsController(ILogger<LingoWordsController> logger, IProcessor processor)
        {
            _logger = logger;
            _processor = processor;

        }

        [HttpGet]
        [Route("Word")]
        public string Word( string language = "DUTCH" )
        {
            List<string> words = new List<string>(){ "woord", "kater", "tafel", "plant", "glans" };
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
