using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/minreadings")]
    [ApiController]
    public class MinReadingsController : ControllerBase
    {
        private readonly IMinReadingsService _service = new MinReadingsService();

        // /api/get/minreadings/all/day
        [Route("all/day")]
        [HttpGet]
        public IActionResult FetchMinDayAllStationsReadings()
        {
            var answer = _service.FetchMinDayAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/minreadings/all/week
        [Route("all/week")]
        [HttpGet]
        public IActionResult FetchMinWeekAllStationsReadings()
        {
            var answer = _service.FetchMinWeekAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/minreadings/all/month
        [Route("all/month")]
        [HttpGet]
        public IActionResult FetchMinMonthAllStationsReadings()
        {
            var answer = _service.FetchMinMonthAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/minreadings/station/day?StationId=
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchMinDayAStationReadings(int StationId)
        {
            var answer = _service.FetchMinDayAStationReadings(StationId);

            return new JsonResult(answer);
        }
        
        // /api/get/minreadings/station/week?StationId=
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchMinWeekAStationReadings(int StationId)
        {
            var answer = _service.FetchMinWeekAStationReadings(StationId);

            return new JsonResult(answer);
        }
        
        // /api/get/minreadings/station/month?StationId=
        [Route("station/month/")]
        [HttpGet]
        public IActionResult FetchMinMonthAStationReadings(int StationId)
        {
            var answer = _service.FetchMinMonthAStationReadings(StationId);

            return new JsonResult(answer);
        }
    }
}