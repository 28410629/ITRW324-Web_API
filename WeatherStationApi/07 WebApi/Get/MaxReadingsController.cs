using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/maxreadings")]
    [ApiController]
    public class MaxReadingsController : ControllerBase
    {
        private readonly IMaxReadingsService _service = new MaxReadingsService();

        [Route("day")]
        [HttpGet]
        public IActionResult FetchMaxDayAllStationsReadings()
        {
            var answer = _service.FetchMaxDayAllStationsReadings();

            return new JsonResult(answer);
        }
        
        [Route("week")]
        [HttpGet]
        public IActionResult FetchMaxWeekAllStationsReadings()
        {
            var answer = _service.FetchMaxWeekAllStationsReadings();

            return new JsonResult(answer);
        }
        
        [Route("month")]
        [HttpGet]
        public IActionResult FetchMaxMonthAllStationsReadings()
        {
            var answer = _service.FetchMaxMonthAllStationsReadings();

            return new JsonResult(answer);
        }
        
        [Route("day/{StationId:int}")]
        [HttpGet]
        public IActionResult FetchMaxDayAStationReadings(int StationId)
        {
            var answer = _service.FetchMaxDayAStationReadings(StationId);

            return new JsonResult(answer);
        }
        
        [Route("week/{StationId:int}")]
        [HttpGet]
        public IActionResult FetchMaxWeekAStationReadings(int StationId)
        {
            var answer = _service.FetchMaxWeekAStationReadings(StationId);

            return new JsonResult(answer);
        }

        [Route("month/{StationId:int}")]
        [HttpGet]
        public IActionResult FetchMaxMonthAStationReadings(int StationId)
        {
            var answer = _service.FetchMaxMonthAStationReadings(StationId);

            return new JsonResult(answer);
        }
    }
}