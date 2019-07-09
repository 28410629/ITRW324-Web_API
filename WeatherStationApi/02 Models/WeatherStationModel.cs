using System.ComponentModel.DataAnnotations;

namespace WeatherStationApi._02_Models
{
    public class WeatherStationModel
    {
        [Key]
        public long Id { get; set; }
    }
}
