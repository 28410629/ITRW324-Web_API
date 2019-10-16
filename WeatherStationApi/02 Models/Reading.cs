using System;
using System.Numerics;

namespace WeatherStationApi._02_Models
{
    public class Reading
    {
        // attributes
        public int ReadingId { get; set; }
        
        public int StationId { get; set; }
        
        public DateTime ReadingDateTime { get; set; }
        
        public double Temperature { get; set; }
        
        public double Humidity { get; set; }
        
        public double AirPressure { get; set; }
        
        public double AmbientLight { get; set; }
        
        // relation
        public Station Station { get; set; }
    }
}