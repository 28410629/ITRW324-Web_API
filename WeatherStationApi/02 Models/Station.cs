using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherStationApi._02_Models
{
    [Table("Stations")]
    public class Station
    {
        [Key]
        public int Id { get; set; }
        
        public Reading Reading { get; set; }
    }
}
