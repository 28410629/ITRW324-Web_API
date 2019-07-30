using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._01_Common.Utilities;

namespace WeatherStationApi.Controllers
{
    [Route("api/test/log-error-email")]
    [ApiController]
    public class TestLogErrorEmailController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetReadings()
        {
            LogErrorEmail.SendErrorTest();
            return "Initiated utility on new thread. Trying to send test email now.";
        }
    }
}
