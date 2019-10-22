namespace WeatherStationApi._03_Dtos
{
    public class StationListDto
    {
        public StationListDto(int StationId, int LocationId, string NickName, string City, string Province)
        {
            this.StationId = StationId;
            this.LocationId = LocationId;
            this.NickName = NickName;
            this.City = City;
            this.Province = Province;
        }
        
        public int StationId { get; set; }
        
        public int LocationId { get; set; }
        
        public string NickName { get; set; }
        
        public string Province { get; set; }
        
        public string City { get; set; }
    }
}