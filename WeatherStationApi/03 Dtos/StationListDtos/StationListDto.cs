namespace WeatherStationApi._03_Dtos
{
    public class StationListDto
    {
        public StationListDto(int StationId, int LocationId, string NickName)
        {
            this.StationId = StationId;
            this.LocationId = LocationId;
            this.NickName = NickName;
        }
        
        public int StationId { get; set; }
        
        public int LocationId { get; set; }
        
        public string NickName { get; set; }
    }
}