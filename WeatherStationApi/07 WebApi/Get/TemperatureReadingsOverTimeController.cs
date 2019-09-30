using System;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/temperaturereadingsovertime")]
    [ApiController]
    public class TemperatureReadingsOverTimeController
    {
        private readonly ITemperatureReadingOverTimeService _service = new TemperatureReadingsOverTimeService();
        
        // /api/get/temperaturereadingsovertime/station/day?StationId= &Date=
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchStationDayTemperatureReadingsOverTime(int StationId, DateTime Date)
        {
            var answer = _service.FetchStationDetailDay(StationId, Date);

            return new JsonResult(answer);
        }
        
        // /api/get/temperaturereadingsovertime/station/week?StationId= &Date=
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchStationWeekTemperatureReadingsOverTime(int StationId, DateTime Date)
        {
            var answer = _service.FetchStationDetailWeek(StationId, Date);

            return new JsonResult(answer);
        }

        // /api/get/temperaturereadingsovertime/station/month?StationId= &Date=
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchStationMonthTemperatureReadingsOverTime(int StationId, DateTime Date)
        {
            var answer = _service.FetchStationDetailMonth(StationId, Date);

            return new JsonResult(answer);
        }
        
        // /api/get/temperaturereadingsovertime/station/year?StationId= &Date=
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