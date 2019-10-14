
namespace WeatherStationApi._03_Dtos
{
    public class ForecastDto
    {
        public ForecastDto() { }
        
        public ForecastDto(float d)
        {
           this.Day = d;
        }

        public float Day { get; set; }
    }
}