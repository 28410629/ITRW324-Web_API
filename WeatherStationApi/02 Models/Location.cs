using System.Collections.Generic;

namespace WeatherStationApi._02_Models
{
    public class Location
    {
        public int LocationId { get; set; }
        
        public string Province { get; set; }
        
        public string City { get; set; }

        // Relation
        
        public ICollection<Station> Stations { get; set; }
    }
}