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

        [HttpGet]
        public IActionResult GetReadings()
        {
            var answer = _service.FetchLastDayReadings();

            return new JsonResult(answer);
        }
    }
}