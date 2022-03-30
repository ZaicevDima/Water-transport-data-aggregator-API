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
        public async Task<String> Get(double lat, double lon) 
            => await weatherService.GetWeatherConditionsAsync(lat, lon);
    }
}