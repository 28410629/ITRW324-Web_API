using System;

namespace WeatherStationApi._02_Models
{
    public class Reading
    {
        public Int64 ReadingId { get; set; }
        
        public int StationId { get; set; }
        
        public DateTime ReadingDateTime { get; set; }
        
        public string Temperature { get; set; }
        
        public string Humidity { get; set; }
        
        public string AirPressure { get; set; }
        
        public string AmbientLight { get; set; }
        
        // Relation
        
        public Station Station { get; set; }
    }
}