
namespace WeatherStationApi._03_Dtos
{
    public class ForecastDto
    {
        public ForecastDto() { }
        
        public ForecastDto(double d)
        {
           this.Day = d;
        }

        public double Day { get; set; }
    }
}