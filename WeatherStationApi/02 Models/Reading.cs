using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherStationApi._02_Models
{
    [Table("Readings")]
    public class Reading : WeatherStationModel
    {
        [ForeignKey("StationId")]
        public int StationId { get; set; }
        
        public string Temperature { get; set; }
        
        public string Humidity { get; set; }
        
        public string AirPressure { get; set; }
        
        public string Light { get; set; }

        public Station Station { get; set; }
        
        //public ICollection<Station> Stations { get; set; }
    }
}