using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherStationApi._02_Models
{
    [Table("Readings")]
    public class Reading : WeatherStationModel
    {
        [ForeignKey("StationId")]
        public Int32 StationId { get; set; }
        
        public string Temperature { get; set; }
        
        public string Humidity { get; set; }
        
        public string AirPressure { get; set; }
        
        public string Light { get; set; }
    }
}