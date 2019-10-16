using System;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    // gets the raw readings from the database for a period and returns the information as a json.
    [Route("api/get/rawreadings")]
    [ApiController]
    public class RawReadingsController : ControllerBase
    {
        private readonly IRawReadingsService _service = new RawReadingsService();
        
        // last day period.
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchRawDayAStationReadings(int StationId, DateTime Date)
        {
            var answer = _service.FetchRawDayAStationReadings(StationId, Date);

            return new JsonResult(answer);
        }
        
        // last week period.
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchRawWeekAStationReadings(int StationId, DateTime Date)
        {
            var answer = _service.FetchRawWeekAStationReadings(StationId, Date);

            return new JsonResult(answer);
        }

        // last month period.
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchRawMonthAStationReadings(int StationId, DateTime Date)
        {
            var answer = _service.FetchRawMonthAStationReadings(StationId, Date);

            return new JsonResult(answer);
        }
        
        // last year period.
        [Route("station/year")]
        [HttpGet]
        public IActionResult FetchRawYearAStationReadings(int StationId, DateTime Date)
        {
            var answer = _service.FetchRawYearAStationReadings(StationId, Date);

            return new JsonResult(answer);
        }
    }
}