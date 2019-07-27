using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/readings")]
    [ApiController]
    public class FetchReadingsController : ControllerBase
    {
        private readonly IFetchReadingsService _service = new FetchReadingsService();

        [HttpGet]
        public IActionResult GetReadings()
        {
            var answer = _service.FetchReadings();

            return new JsonResult(answer);
        }
    }
}
