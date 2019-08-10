using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/lastdayreadings")]
    [ApiController]
    public class LastDayReadingsController : ControllerBase
    {
        private readonly IFetchLastDayReadingsService _service = new LastDayReadingsService();

        [Route("all")]
        [HttpGet]
        public IActionResult GetReadings()
        {
            var answer = _service.FetchLastDayReadings();

            return new JsonResult(answer);
        }
        
        [Route("station")]
        [HttpGet]
        public IActionResult GetReadings(int StationId)
        {
            var answer = _service.FetchLastDayReadingsByStation(StationId);

            return new JsonResult(answer);
        }
    }
}