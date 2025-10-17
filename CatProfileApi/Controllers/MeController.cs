using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http;
using System.Text.Json;

namespace CatProfileApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; // Interface for accessing an external API
        private readonly ILogger<MeController> _logger;

        public MeController(IHttpClientFactory httpClientFactory, ILogger<MeController> logger)
        {
            // Using Dependency Injection
            _httpClientFactory = httpClientFactory;  
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetMe()
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(10); // Timeout for the Api
            string catFact = "could not fetch cat fact.";
            _logger.LogInformation("Fetching cat fact from external API...");

            try
            {
                var response = await client.GetAsync("https://catfact.ninja/fact");
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                var json = await JsonDocument.ParseAsync(stream);

                catFact = json.RootElement.GetProperty("fact").GetString();

                _logger.LogInformation("Successfully fetched cat fact.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch cat fact from API.");
                catFact = "Cats are mysterious creatures — fact API unreachable."; // Handle errors without crashing
            }

            var result = new
            {
                status = "success",
                user = new
                {
                    email = "devjoel@gmail.com",
                    name = "Gbolahan Joel Adeoye",
                    stack = ".NET Core/Web API"
                },
                timestamp = DateTime.UtcNow.ToString("o"), // ISO format for date
                fact = catFact
            };
            return Ok(result);

        }
    }
}
