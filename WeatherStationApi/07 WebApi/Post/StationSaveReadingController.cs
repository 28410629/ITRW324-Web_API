using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Post
{
    [Route("api/post/reading")]
    [ApiController]
    public class StationSaveReadingController : ControllerBase
    {
        private readonly IStationSaveReadingService _service = new StationSaveReadingService();
        
        [HttpPost]
        public void Post([FromBody] ReadingDto reading)
        {
            _service.CreateNewReading(reading);
        }
    }
}