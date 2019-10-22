using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._01_Common.Utilities;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetForecast(int StationId, DateTime Date)
        {
            try
            {
                var answer = _service.FetchForecast(StationId, Date);
                return Ok(answer);
            }
            catch (Exception e)
            {
                LogErrorEmail.SendError(e);
                return NotFound();
            }
        }
    }
}
