using System;

namespace WeatherStationApi._04_Interfaces.Services
{
    // explicitly states methods for ForecastDto.
    public interface IForecastService
    {
        // interface to access ForecastDtos.
        double[] FetchForecast(int StationId, DateTime Date);
    }
}
