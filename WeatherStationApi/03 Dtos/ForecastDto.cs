
namespace WeatherStationApi._03_Dtos
{
    public class ForecastDto
    {
        public ForecastDto() { }
        
        public ForecastDto(string d)
        {
           this.Day = d;
        }

        public string Day { get; set; }
    }
}