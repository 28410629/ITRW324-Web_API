using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Post
{
    [Route("api/post/reading")]
    [ApiController]
    public class SaveReadingController : ControllerBase
    {
        private readonly ISaveReadingService _service = new SaveReadingService();
        
        [HttpPost]
        public void Post([FromBody] ReadingDto reading)
        {
            _service.CreateNewReading(reading);
        }
    }
}