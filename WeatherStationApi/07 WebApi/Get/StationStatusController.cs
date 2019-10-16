using System;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/stationstatus")]
    [ApiController]
    public class StationStatusController : ControllerBase
    {
        private readonly IStationStatusService _service = new StationStatusService();
        
        [Route("station")]
        [HttpGet]
        public IActionResult FetchStationStatus(string StationIds, DateTime Date)
        {
            var answer = _service.FetchStationStatus(StationIds, Date);

            return new JsonResult(answer);
        }
    }
}