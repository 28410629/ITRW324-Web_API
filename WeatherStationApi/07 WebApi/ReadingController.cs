using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces;
using WeatherStationApi._06_Services;

namespace WeatherStationApi
{
    public class ReadingController
    {
        [Route("api/reading")]
        [ApiController]
        public class FaqDashboardController : ControllerBase
        {
            [HttpGet]
            public IActionResult GetFaqDashboard()
            {
                //return new JsonResult();
            }
            
            [HttpPost]
            public void Post([FromBody] ReadingDto reading)
            {
                ISaveReading _service = new SaveReading();
                _service.CreateNewReading(reading);
            }
        }
    }
}