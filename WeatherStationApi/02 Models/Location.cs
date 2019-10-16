using System.Collections.Generic;

namespace WeatherStationApi._02_Models
{
    public class Location
    {
        // attributes
        public int LocationId { get; set; }
        
        public string Province { get; set; }
        
        public string City { get; set; }

        // relation
        public ICollection<Station> Stations { get; set; }
    }
}