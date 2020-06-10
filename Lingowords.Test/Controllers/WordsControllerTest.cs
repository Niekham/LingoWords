using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Lingowords.Test.Controllers
{

    public class WordsControllerTest
    {
        private readonly HttpClient _client;
        private readonly Language _language;

        public WordsControllerTest()
        {
            //_language = Language.DUTCH;
            //_words = new Words( new string[] { "woord", "woorden", "banaan", "graal", "aardbei", "harken", "paprika", "groen" }, _language );

            var factory = new WebApplicationFactory<Startup>();

            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Word()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "/Lingowords/Word");

            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact]
        public async Task List()
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "/Lingowords/List");

            var response = await _client.SendAsync(message);
            response.EnsureSuccessStatusCode();

            Assert.Equal("OK", response.StatusCode.ToString());
        }

    }
}
