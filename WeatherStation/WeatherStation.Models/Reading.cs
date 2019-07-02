using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherStation.Models
{
    [Table("Readings")]
    public class Reading : WeatherStationModel
    {
        public string AirPressure { get; set; }

        public string Humidity { get; set; }

        public string LightPercentage { get; set; }

        public string Temperature { get; set; }
    }
}
