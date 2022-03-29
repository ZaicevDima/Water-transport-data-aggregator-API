using Microsoft.AspNetCore.Mvc;
using WaterTransportAPI.Models;
using WaterTransportAPI.Services;

namespace WaterTransportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        private WeatherService weatherService = new WeatherService(); 

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeather")]
        public Weather Get(double lat, double lon) 
            => weatherService.GetWeatherConditions(lat, lon);
    }
}