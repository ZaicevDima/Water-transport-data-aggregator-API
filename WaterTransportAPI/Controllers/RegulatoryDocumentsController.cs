using Microsoft.AspNetCore.Mvc;
using RegulatoryDocuments.Services;
using WaterTransportAPI.Models;

namespace WaterTransportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegulatoryDocumentsController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        private RegulatoryDocumentsService regulatoryDocumentsService = new RegulatoryDocumentsService();

        public RegulatoryDocumentsController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRegulatoryDocuments")]
        public DocResult Get()
            => regulatoryDocumentsService.parse();
    }
}