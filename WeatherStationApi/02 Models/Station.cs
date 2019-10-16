using System.Collections.Generic;

namespace WeatherStationApi._02_Models
{
    public class Station
    {
        // attributes
        public int StationId { get; set; }
        
        public int UserId { get; set; }
        
        public int LocationId { get; set; }
        
        public string NickName { get; set; }
        
        // relation
        public EndUser EndUser { get; set; }
        
        public Location Location { get; set; }
        
        public ICollection<Reading> Readings { get; set; }
    }
}
