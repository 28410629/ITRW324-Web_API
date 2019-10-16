
namespace WeatherStationApi._03_Dtos
{
    public class ForecastDto
    {
        public ForecastDto() { }
        
        public ForecastDto(double d)
        {
           Day = d;
        }

        public double Day { get; set; }
    }
}