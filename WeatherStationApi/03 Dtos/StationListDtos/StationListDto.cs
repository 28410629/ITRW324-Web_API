namespace WeatherStationApi._03_Dtos
{
    public class StationListDto
    {
        public StationListDto(int StationId, int UserId, int LocationId, string NickName)
        {
            this.StationId = StationId;
            this.UserId = UserId;
            this.LocationId = LocationId;
            this.NickName = NickName;
        }
        
        public int StationId { get; set; }
        
        public int UserId { get; set; }
        
        public int LocationId { get; set; }
        
        public string NickName { get; set; }
    }
}