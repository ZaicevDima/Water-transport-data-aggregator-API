using Microsoft.AspNetCore.Mvc;
using WaterTransportAPI.Services;

namespace WaterTransportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        private WeatherService weatherService = new WeatherService();
        private NewsService newsService = new NewsService();

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeather")]
        public async Task<Dictionary<string, string>> Get(double lat, double lon) 
            => await weatherService.GetWeatherConditionsAsync(lat, lon);

        [HttpGet(Name = "GetNews")]
        public async Task<Dictionary<string, string>> Get(string request)
            => await newsService.GetNewsAsync(request);


    }
}