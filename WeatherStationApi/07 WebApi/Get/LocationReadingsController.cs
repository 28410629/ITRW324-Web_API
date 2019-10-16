using System;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
        // fetches specified period in route from the database and return a json with aggregated information for location.
        [Route("api/get/locationreadings")]
        [ApiController]
        public class LocationReadingsController
        {
            private readonly ILocationReadingsService _service = new LocationReadingsService();
            
            // last day period.
            [Route("location/day")]
            [HttpGet]
            public IActionResult FetchStationDayTemperatureReadingsOverTime(string Province, string City, DateTime Date)
            {
                var answer = _service.FetchLocationDetailDay(Province, City, Date);

                return new JsonResult(answer);
            }
            
            // last week period.
            [Route("location/week")]
            [HttpGet]
            public IActionResult FetchStationWeekTemperatureReadingsOverTime(string Province, string City, DateTime Date)
            {
                var answer = _service.FetchLocationDetailWeek(Province, City, Date);

                return new JsonResult(answer);
            }
            
            // last month period.
            [Route("location/month")]
            [HttpGet]
            public IActionResult FetchStationMonthTemperatureReadingsOverTime(string Province, string City, DateTime Date)
            {
                var answer = _service.FetchLocationDetailMonth(Province, City, Date);

                return new JsonResult(answer);
            }
            
            // last year period.
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