using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/averageweekreadings)]")
    [ApiController]
    public class AverageWeekReadingsController : ControllerBase
    { 
        private readonly IAverageWeekReadingsService _service = new AverageWeekReadings();

        [HttpGet] 
        public IActionResult GetReadings() 
        {
            var answer = _service.AverageWeekReadings();

            return new JsonResult(answer);
        }
    }
    
}