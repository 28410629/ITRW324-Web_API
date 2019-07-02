using System.ComponentModel.DataAnnotations;

namespace WeatherStation.Models
{
    public abstract class WeatherStationModel
    {
        [Key]
        public long Id { get; set; }
    }
}
