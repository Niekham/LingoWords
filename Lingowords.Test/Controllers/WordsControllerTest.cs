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

        public WordsControllerTest()
        {
            var _processor = new Mock<IProcessor>();
            _processor.As<IProcessor>().Setup(x => x.ListWords(It.IsAny<string>())).Returns(new Words(
                    new string[] { "woord", "griezel", "verdamt", "grafiek", "perseel", "graad" },
                    Language.DUTCH
                ));


            var factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(IProcessor));
                        services.AddTransient<IProcessor>(x => _processor.Object);
                    });
                });

           
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
