using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/stationlist")]
    [ApiController]
    public class StationListController : ControllerBase
    {
        private readonly IStationListService _service = new StationListService();
        
        // returns a json containing all registered stations on the system.
        [Route("all")]
        [HttpGet]
        public IActionResult FetchStations()
        {
            var answer = _service.FetchStations();

            return new JsonResult(answer);
        }
    }
}