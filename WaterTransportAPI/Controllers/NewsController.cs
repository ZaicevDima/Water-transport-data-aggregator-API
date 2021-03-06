using Microsoft.AspNetCore.Mvc;
using WaterTransportAPI.Models;
using WaterTransportAPI.Services;

namespace WaterTransportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        private NewsService newsService = new NewsService();

        public NewsController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetNews")]
        public async Task<List<NewsResponse>> Get(string request)
            => await newsService.GetNewsAsync(request);


    }
}
