using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/averagereadings")]
    [ApiController]
    public class AverageReadingsController : ControllerBase
    {
        private readonly IAverageReadingsService _service = new AverageReadingsService();

        // /api/get/averagereadings/all/day
        [Route("all/day")]
        [HttpGet]
        public IActionResult FetchAverageDayAllStationsReadings()
        {
            var answer = _service.FetchAverageDayAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/averagereadings/all/week
        [Route("all/week")]
        [HttpGet]
        public IActionResult FetchAverageWeekAllStationsReadings()
        {
            var answer = _service.FetchAverageWeekAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/averagereadings/all/month
        [Route("all/month")]
        [HttpGet]
        public IActionResult FetchAverageMonthAllStationsReadings()
        {
            var answer = _service.FetchAverageMonthAllStationsReadings();

            return new JsonResult(answer);
        }
        
        // /api/get/averagereadings/station/day?StationId=
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchAverageDayAStationReadings(int StationId)
        {
            var answer = _service.FetchAverageDayAStationReadings(StationId);

            return new JsonResult(answer);
        }
        
        // /api/get/averagereadings/station/week?StationId=
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchAverageWeekAStationReadings(int StationId)
        {
            var answer = _service.FetchAverageWeekAStationReadings(StationId);

            return new JsonResult(answer);
        }

        // /api/get/averagereadings/station/month?StationId=
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchAverageMonthAStationReadings(int StationId)
        {
            var answer = _service.FetchAverageMonthAStationReadings(StationId);

            return new JsonResult(answer);
        }
    }
}