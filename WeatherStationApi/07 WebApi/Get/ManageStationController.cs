using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._03_Dtos.ManageStationDtos;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/managestations")]
    [ApiController]
    public class SaveStationController : ControllerBase
    {
        private readonly IManageStationService _service = new ManageStationService();

        // creates a station based on given information.
        [Route("create")]
        [HttpGet]
        public IActionResult CreateStation(string Province, string City, int StationId, string Nickname)
        {
            var answer = _service.CreateStation(Province, City, StationId, Nickname);

            return new JsonResult(new ManageStationDto()
            {
                Success = answer
            });
        }
        
        // deletes station based on given information.
        [Route("delete")]
        [HttpGet]
        public IActionResult DeleteStation(string Province, string City, int StationId, string Nickname)
        {
            var answer = _service.DeleteStation(Province, City, StationId, Nickname);

            return new JsonResult(new ManageStationDto()
            {
                Success = answer
            });
        }
        
        // edits station based on given information.
        [Route("edit")]
        [HttpGet]
        public IActionResult EditStation(string Province, string City, int StationId, string Nickname)
        {
            var answer = _service.EditStation(Province, City, StationId, Nickname);

            return new JsonResult(new ManageStationDto()
            {
                Success = answer
            });
        }
    }
}
