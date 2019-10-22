using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._01_Common.Utilities;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/readings")]
    [ApiController]
    public class FetchReadingsController : ControllerBase
    {
        private readonly IFetchReadingsService _service = new FetchReadingsService();

        // fetches all readings from the database and return a json with information.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetReadings()
        {
            try
            {
                var answer = _service.FetchReadings();
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
