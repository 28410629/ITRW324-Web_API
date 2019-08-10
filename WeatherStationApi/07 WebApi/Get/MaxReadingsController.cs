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

        // /api/get/maxreadings/all/day
        [Route("all/day")]
        [HttpGet]
        public IActionResult FetchMaxDayAllStationsReadings()
        {
            var answer = _service.FetchMaxDayAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/maxreadings/all/week
        [Route("all/week")]
        [HttpGet]
        public IActionResult FetchMaxWeekAllStationsReadings()
        {
            var answer = _service.FetchMaxWeekAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/maxreadings/all/month
        [Route("all/month")]
        [HttpGet]
        public IActionResult FetchMaxMonthAllStationsReadings()
        {
            var answer = _service.FetchMaxMonthAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/maxreadings/station/day?StationId=
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchMaxDayAStationReadings(int StationId)
        {
            var answer = _service.FetchMaxDayAStationReadings(StationId);

            return new JsonResult(answer);
        }
        
        // /api/get/maxreadings/station/week?StationId=
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchMaxWeekAStationReadings(int StationId)
        {
            var answer = _service.FetchMaxWeekAStationReadings(StationId);

            return new JsonResult(answer);
        }

        // /api/get/maxreadings/station/month?StationId=
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchMaxMonthAStationReadings(int StationId)
        {
            var answer = _service.FetchMaxMonthAStationReadings(StationId);

            return new JsonResult(answer);
        }
    }
}