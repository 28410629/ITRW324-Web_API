using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._06_Services;

namespace WeatherStationApi._07_WebApi.Get
{
    [Route("api/get/temperaturereadingsovertime")]
    [ApiController]
    public class TemperatureReadingsOverTimeController
    {
        private readonly ITemperatureReadingOverTimeService _service = new TemperatureReadingsOverTimeService();
        
        [Route("station/day")]
        [HttpGet]
        public IActionResult FetchMaxDayAStationReadings(int StationId)
        {
            var answer = _service.FetchStationDayTemperatureReadingsOverTime(StationId);

            return new JsonResult(answer);
        }
        
        // /api/get/temperaturereadingsovertime/station/week?StationId=
        [Route("station/week")]
        [HttpGet]
        public IActionResult FetchMaxWeekAStationReadings(int StationId)
        {
            var answer = _service.FetchStationWeekTemperatureReadingsOverTime(StationId);

            return new JsonResult(answer);
        }

        // /api/get/temperaturereadingsovertime/station/month?StationId=
        [Route("station/month")]
        [HttpGet]
        public IActionResult FetchMaxMonthAStationReadings(int StationId)
        {
            var answer = _service.FetchStationMonthTemperatureReadingsOverTime(StationId);

            return new JsonResult(answer);
        }
    }
}