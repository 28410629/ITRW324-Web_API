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

        // fetches status information for a group of stations for station status cards.
        public StationsStatusesDto FetchStationStatus(string StringStationIds, DateTime Date)
        {
            StationsStatusesDto ReturnDto = new StationsStatusesDto();
            string[] ListOfStationIds = StringStationIds.Split('-');
            
            foreach (var StringStationId in ListOfStationIds)
            {
                int StationId = Convert.ToInt32(StringStationId);
                
                StationStatusDto NewDto = new StationStatusDto();
                NewDto.StationName = StationId.ToString();
                // get average readings.
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
                try {
                    NewDto.AverageTemp = AverageReadings.First().AverageTemperature;
                }
                catch (Exception e) {
                    NewDto.AverageTemp = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }

                try {
                    NewDto.Humidity = AverageReadings.First().AverageHumidity;
                }
                catch (Exception e) {
                    NewDto.Humidity = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }
                try {
                    NewDto.AmbientLight = AverageReadings.First().AverageAmbientLight;
                }
                catch (Exception e) {
                    NewDto.AmbientLight = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }
                // get max readings for past day.
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
                try {
                    NewDto.MaxTemp = MaxReadings.First().MaxTemperature;
                }
                catch (Exception e) {
                    NewDto.MaxTemp = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }
                // get min readings for past day.
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
                try {
                    NewDto.MinTemp = MinReadings.First().MinTemperature;
                }
                catch (Exception e) {
                    NewDto.MinTemp = "0";
                    Console.WriteLine(e.Source + " : " + e.Message);
                }
                Console.WriteLine("[  OK!  ] Successfully got status for " + StationId + ", getting forecast.");
                double[] Forecast = new ForecastService().FetchForecast(StationId, Date);
                NewDto.ForecastDay1 = Forecast[0].ToString();
                NewDto.ForecastDay2 = Forecast[1].ToString();
                NewDto.ForecastDay3 = Forecast[2].ToString();
                NewDto.ForecastDay4 = Forecast[3].ToString();
                ReturnDto.Readings.Add(NewDto);
            }

            return ReturnDto;
        }
    }
}