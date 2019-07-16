using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi
{
    [Route("api/fetch/reading")]
    [ApiController]
    public class FetchReadingController : ControllerBase
    {
        private IFetchReadingService _service = new FetchReadingService();

        [HttpGet]
        public IActionResult GetReading(long id)
        {
            var answer = _service.FetchReading(id);

            return new JsonResult(answer);
        }
    }
}
