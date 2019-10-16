using System;
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
        public IActionResult FetchRawDayAStationReadings(int StationId, DateTime Date)
        {
            var answer = _service.FetchRawDayAStationReadings(StationId, Date);

            return new JsonResult(answer);
        }
        
        // /api/get/rawreadings/station/week?StationId=
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchRawWeekAStationReadings(int StationId, DateTime Date)
        {
            var answer = _service.FetchRawWeekAStationReadings(StationId, Date);

            return new JsonResult(answer);
        }

        // /api/get/rawreadings/station/month?StationId=
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchRawMonthAStationReadings(int StationId, DateTime Date)
        {
            var answer = _service.FetchRawMonthAStationReadings(StationId, Date);

            return new JsonResult(answer);
        }
        
        // /api/get/rawreadings/station/year?StationId=
        [Route("station/year")]
        [HttpGet]
        public IActionResult FetchRawYearAStationReadings(int StationId, DateTime Date)
        {
            var answer = _service.FetchRawYearAStationReadings(StationId, Date);

            return new JsonResult(answer);
        }
    }
}