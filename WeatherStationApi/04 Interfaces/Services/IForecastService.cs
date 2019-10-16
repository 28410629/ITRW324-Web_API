using System;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IForecastService
    {
        double[] FetchForecast(int StationId, DateTime Date);
    }
}
