
namespace WeatherStationApi._03_Dtos
{
    public class ForecastDto
    {
        public ForecastDto() { }
        
        public ForecastDto(string d1, string d2, string d3)
        {
           this.Day1 = d1;
           this.Day2 = d2;
           this.Day3 = d3; 
        }

        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
    }
}