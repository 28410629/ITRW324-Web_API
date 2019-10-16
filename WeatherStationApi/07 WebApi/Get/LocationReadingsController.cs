using System;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
   
        [Route("api/get/locationreadings")]
        [ApiController]
        public class LocationReadingsController
        {
            private readonly ILocationReadingsService _service = new LocationReadingsService();
            
            [Route("location/day")]
            [HttpGet]
            public IActionResult FetchStationDayTemperatureReadingsOverTime(string Province, string City, DateTime Date)
            {
                var answer = _service.FetchLocationDetailDay(Province, City, Date);

                return new JsonResult(answer);
            }
            
            [Route("location/week")]
            [HttpGet]
            public IActionResult FetchStationWeekTemperatureReadingsOverTime(string Province, string City, DateTime Date)
            {
                var answer = _service.FetchLocationDetailWeek(Province, City, Date);

                return new JsonResult(answer);
            }
            
            [Route("location/month")]
            [HttpGet]
            public IActionResult FetchStationMonthTemperatureReadingsOverTime(string Province, string City, DateTime Date)
            {
                var answer = _service.FetchLocationDetailMonth(Province, City, Date);

                return new JsonResult(answer);
            }
            
            [Route("location/year")]
            [HttpGet]
            public IActionResult FetchStationYearTemperatureReadingsOverTime(string Province, string City, DateTime Date)
            {
                Console.WriteLine("Request StationDetailDay");
                var answer = _service.FetchLocationDetailYear(Province, City, Date);

                return new JsonResult(answer);
            }
        }
    
}