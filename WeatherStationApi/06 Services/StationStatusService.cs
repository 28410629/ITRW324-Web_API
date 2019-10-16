using System;
using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class StationStatusService : IStationStatusService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public StationsStatusesDto FetchStationStatus(string StringStationIds, DateTime Date)
        {
            StationsStatusesDto returnDto = new StationsStatusesDto();
            string[] ListOfStationIds = StringStationIds.Split('-');
            
            foreach (var StringStationId in ListOfStationIds)
            {
                int StationId = Convert.ToInt32(StringStationId);
                
                StationStatusDto newDto = new StationStatusDto();
                newDto.StationName = StationId.ToString();

                var AverageReadings = _readingsRepository
                    .FetchHourStation(StationId, Date)
                    .GroupBy(g => g.StationId)
                    .Select(g => new AverageReadingDto(
                        g.Key,
                        g.Average(x => x.Temperature).ToString(),
                        g.Average(x => x.Humidity).ToString(),
                        g.Average(x => x.AirPressure).ToString(),
                        g.Average(x => x.AmbientLight).ToString())
                    ).ToList();

                try
                {
                    newDto.AverageTemp = AverageReadings.First().AverageTemperature;
                }
                catch (Exception e)
                {
                    newDto.AverageTemp = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }

                try
                {
                    newDto.Humidity = AverageReadings.First().AverageHumidity;
                }
                catch (Exception e)
                {
                    newDto.Humidity = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }

                try
                {
                    newDto.AmbientLight = AverageReadings.First().AverageAmbientLight;
                }
                catch (Exception e)
                {
                    newDto.AmbientLight = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }
                
                var MaxReadings = _readingsRepository
                    .FetchDayStation(StationId, Date)
                    .GroupBy(g => g.StationId)
                    .Select(g => new MaxReadingDto(
                        g.Key,
                        g.Max(x => x.Temperature).ToString(),
                        g.Max(x => x.Humidity).ToString(),
                        g.Max(x => x.AirPressure).ToString(),
                        g.Max(x => x.AmbientLight).ToString())
                    ).ToList();

                try
                {
                    newDto.MaxTemp = MaxReadings.First().MaxTemperature;
                }
                catch (Exception e)
                {
                    newDto.MaxTemp = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }

                var MinReadings = _readingsRepository
                    .FetchDayStation(StationId, Date)
                    .GroupBy(g => g.StationId)
                    .Select(g => new MinReadingDto(
                        g.Key,
                        g.Min(x => x.Temperature).ToString(),
                        g.Min(x => x.Humidity).ToString(),
                        g.Min(x => x.AirPressure).ToString(),
                        g.Min(x => x.AmbientLight).ToString())
                    ).ToList();

                try
                {
                    newDto.MinTemp = MinReadings.First().MinTemperature;
                }
                catch (Exception e)
                {
                    newDto.MinTemp = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }
                
                double[] forecast = new ForecastService().FetchForecast(StationId, Date);
                
                newDto.ForecastDay1 = forecast[0].ToString();
                newDto.ForecastDay2 = forecast[1].ToString();
                newDto.ForecastDay3 = forecast[2].ToString();
                newDto.ForecastDay4 = forecast[3].ToString();
                
                returnDto.Readings.Add(newDto);
            }

            return returnDto;
        }
    }
}