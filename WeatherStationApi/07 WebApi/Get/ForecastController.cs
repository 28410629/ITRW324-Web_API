using System;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/forecast")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IForecastService _service = new ForecastService();

        // fetches last three days readings from database and calculates a forecast for the next four days, lastly return a json with information.
        [Route("station/4day")]
        [HttpGet]
        public IActionResult GetForecast(int StationId, DateTime Date)
        {
            var answer = _service.FetchForecast(StationId, Date);

            return new JsonResult(answer);
        }
    }
}
