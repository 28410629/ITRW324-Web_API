using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/Minreadings")]
    [ApiController]
    public class MinReadingsController : ControllerBase
    {
        private readonly IMinReadingsService _service = new MinReadingsService();

        [Route("day")]
        [HttpGet]
        public IActionResult FetchMinDayAllStationsReadings()
        {
            var answer = _service.FetchMinDayAllStationsReadings();

            return new JsonResult(answer);
        }
        
        [Route("week")]
        [HttpGet]
        public IActionResult FetchMinWeekAllStationsReadings()
        {
            var answer = _service.FetchMinWeekAllStationsReadings();

            return new JsonResult(answer);
        }
        
        [Route("month")]
        [HttpGet]
        public IActionResult FetchMinMonthAllStationsReadings()
        {
            var answer = _service.FetchMinMonthAllStationsReadings();

            return new JsonResult(answer);
        }
        
        [Route("day/{StationId:int}")]
        [HttpGet]
        public IActionResult FetchMinDayAStationReadings(int StationId)
        {
            var answer = _service.FetchMinDayAStationReadings(StationId);

            return new JsonResult(answer);
        }
        
        [Route("week/{StationId:int}")]
        [HttpGet]
        public IActionResult FetchMinWeekAStationReadings(int StationId)
        {
            var answer = _service.FetchMinWeekAStationReadings(StationId);

            return new JsonResult(answer);
        }

        [Route("month/{StationId:int}")]
        [HttpGet]
        public IActionResult FetchMinMonthAStationReadings(int StationId)
        {
            var answer = _service.FetchMinMonthAStationReadings(StationId);

            return new JsonResult(answer);
        }
    }
}