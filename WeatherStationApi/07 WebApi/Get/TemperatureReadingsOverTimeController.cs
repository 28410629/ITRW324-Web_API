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
        
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchStationDayTemperatureReadingsOverTime(int StationId)
        {
            Console.WriteLine("Request StationDetailDay");
            var answer = _service.FetchStationDetailDay(StationId);

            return new JsonResult(answer);
        }
        
        // /api/get/temperaturereadingsovertime/station/week?StationId=
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchStationWeekTemperatureReadingsOverTime(int StationId)
        {
            var answer = _service.FetchStationWeekTemperatureReadingsOverTime(StationId);

            return new JsonResult(answer);
        }

        // /api/get/temperaturereadingsovertime/station/month?StationId=
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchStationMonthTemperatureReadingsOverTime(int StationId)
        {
            var answer = _service.FetchStationMonthTemperatureReadingsOverTime(StationId);

            return new JsonResult(answer);
        }
    }
}