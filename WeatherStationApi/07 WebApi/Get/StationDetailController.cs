using System;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    // get relevant period's from database for a station and generate information required for graphs on frontend.
    [Route("api/get/stationdetail")]
    [ApiController]
    public class StationDetailController
    {
        private readonly IStationDetailService _service = new StationDetailService();
        
        // last day period.
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchStationDayTemperatureReadingsOverTime(int StationId, DateTime Date)
        {
            var answer = _service.FetchStationDetailDay(StationId, Date);

            return new JsonResult(answer);
        }
        
        // last week period.
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchStationWeekTemperatureReadingsOverTime(int StationId, DateTime Date)
        {
            var answer = _service.FetchStationDetailWeek(StationId, Date);

            return new JsonResult(answer);
        }
        
        // last month period.
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchStationMonthTemperatureReadingsOverTime(int StationId, DateTime Date)
        {
            var answer = _service.FetchStationDetailMonth(StationId, Date);

            return new JsonResult(answer);
        }
        
        // last year period.
        [Route("station/year")]
        [HttpGet]
        public IActionResult FetchStationYearTemperatureReadingsOverTime(int StationId, DateTime Date)
        {
            Console.WriteLine("Request StationDetailDay");
            var answer = _service.FetchStationDetailYear(StationId, Date);

            return new JsonResult(answer);
        }
    }
}