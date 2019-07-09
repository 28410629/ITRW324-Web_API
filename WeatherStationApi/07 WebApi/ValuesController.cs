using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hello", "World", "!" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ReadingDto reading)
        {
            Console.WriteLine("Received JSON:");
            Console.WriteLine("Station: " + reading.Station);
            Console.WriteLine("AirPressure: " + reading.AirPressure);
            Console.WriteLine("Humidity: " + reading.Humidity);
            Console.WriteLine("Light: " + reading.Light);
            Console.WriteLine("Temperature: " + reading.Temperature);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
