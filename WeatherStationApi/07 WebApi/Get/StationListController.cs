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
        
        // /api/get/stationlist/all
        [Route("all")]
        [HttpGet]
        public IActionResult FetchStations()
        {
            var answer = _service.FetchStations();

            return new JsonResult(answer);
        }
    }
}