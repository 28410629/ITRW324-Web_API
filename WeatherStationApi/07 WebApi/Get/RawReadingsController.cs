using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/rawreadings")]
    [ApiController]
    public class RawReadingsController : ControllerBase
    {
        private readonly IRawReadingsService _service = new RawReadingsService();
        
        // /api/get/rawreadings/station/day?StationId=
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchRawDayAStationReadings(int StationId)
        {
            var answer = _service.FetchRawDayAStationReadings(StationId);

            return new JsonResult(answer);
        }
        
        // /api/get/rawreadings/station/week?StationId=
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchRawWeekAStationReadings(int StationId)
        {
            var answer = _service.FetchRawWeekAStationReadings(StationId);

            return new JsonResult(answer);
        }

        // /api/get/rawreadings/station/month?StationId=
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchRawMonthAStationReadings(int StationId)
        {
            var answer = _service.FetchRawMonthAStationReadings(StationId);

            return new JsonResult(answer);
        }
        
        // /api/get/rawreadings/station/year?StationId=
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchRawYearAStationReadings(int StationId)
        {
            var answer = _service.FetchRawYearAStationReadings(StationId);

            return new JsonResult(answer);
        }
    }
}