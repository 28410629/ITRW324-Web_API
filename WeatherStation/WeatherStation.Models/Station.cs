using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherStation.Models
{
    [Table("Stations")]
    public class Station
    {
        public string SerialNumber { get; set; }

    }
}
