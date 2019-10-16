using System;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IForecastService
    {
        double[] FetchForecast(int stationId, DateTime Date);
    }
}
