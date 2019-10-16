using System.Collections.Generic;

namespace WeatherStationApi._02_Models
{
    public class EndUser
    {
        // attributes
        public int UserId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        // relation
        public ICollection<Station> Stations { get; set; }
    }
}