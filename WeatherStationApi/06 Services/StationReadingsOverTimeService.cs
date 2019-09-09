using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class TemperatureReadingsOverTimeService : ITemperatureReadingOverTimeService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public StationDetailDays FetchStationDetailDay(int stationID)
        {
            Console.WriteLine("Linq");
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1) && x.StationId == stationID)
                .Select(i => new TemperatureReadingOverTimeDto(
                    i.StationId, i.Temperature.ToString(),i.Humidity.ToString(),i.AirPressure.ToString(),i.AmbientLight.ToString(),i.ReadingDateTime));

            var data = readings.ToList();
            
            Console.WriteLine("Process data");
            
            int currentHour = data[0].ReadingTime.Hour;
            int count = 0;
            double temp = 0;
            double tempMin = double.MaxValue;
            double tempMax = double.MinValue;
            double hum = 0;
            double humMin = double.MaxValue;
            double humMax = double.MinValue;
            double air = 0;
            double airMin = double.MaxValue;
            double airMax = double.MinValue;
            double light = 0;
            double lightMin = double.MaxValue;
            double lightMax = double.MinValue;
            
            var json = new List<StationDetailDay>();
            
            Console.WriteLine("To process: " + data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                if (currentHour == data[i].ReadingTime.Hour)
                {
                    temp += Convert.ToDouble(data[i].TemperatureReading);
                    if (tempMin > Convert.ToDouble(data[i].TemperatureReading))
                    {
                        tempMin = Convert.ToDouble(data[i].TemperatureReading);
                    }

                    if (tempMax < Convert.ToDouble(data[i].TemperatureReading))
                    {
                        tempMax = Convert.ToDouble(data[i].TemperatureReading);
                    }
                    
                    hum += Convert.ToDouble(data[i].HumiditiyReading);
                    if (humMin > Convert.ToDouble(data[i].TemperatureReading))
                    {
                        humMin = Convert.ToDouble(data[i].TemperatureReading);
                    }

                    if (humMax < Convert.ToDouble(data[i].TemperatureReading))
                    {
                        humMax = Convert.ToDouble(data[i].TemperatureReading);
                    }
                    
                    air += Convert.ToDouble(data[i].AirPressureReading);
                    if (airMin > Convert.ToDouble(data[i].TemperatureReading))
                    {
                        airMin = Convert.ToDouble(data[i].TemperatureReading);
                    }

                    if (airMax < Convert.ToDouble(data[i].TemperatureReading))
                    {
                        airMax = Convert.ToDouble(data[i].TemperatureReading);
                    }
                    
                    light += Convert.ToDouble(data[i].AmbientLightReading);
                    if (lightMin > Convert.ToDouble(data[i].TemperatureReading))
                    {
                        lightMin = Convert.ToDouble(data[i].TemperatureReading);
                    }

                    if (lightMax < Convert.ToDouble(data[i].TemperatureReading))
                    {
                        lightMax = Convert.ToDouble(data[i].TemperatureReading);
                    }
                    
                    count++;
                }
                else
                {
                    // add to dto
                    json.Add(new StationDetailDay(
                        data[i].StationId, 
                        (temp / count).ToString(),
                        tempMin.ToString(), 
                        tempMax.ToString(),
                        (hum / count).ToString(), 
                        humMin.ToString(),
                        humMax.ToString(),
                        (air / count).ToString(), 
                        airMin.ToString(),
                        airMax.ToString(),
                        (light / count).ToString(), 
                        lightMin.ToString(), 
                        lightMax.ToString(),
                        new DateTime(data[--i].ReadingTime.Year, data[--i].ReadingTime.Month, data[--i].ReadingTime.Day,data[--i].ReadingTime.Hour, 0, 0)));
                    // reset
                    count = 0;
                    temp = 0;
                    hum = 0;
                    air = 0;
                    light = 0;
                    // start with new value
                    temp += Convert.ToDouble(data[i].TemperatureReading);
                    hum += Convert.ToDouble(data[i].HumiditiyReading);
                    air += Convert.ToDouble(data[i].AirPressureReading);
                    light += Convert.ToDouble(data[i].AmbientLightReading);
                    count++;
                }

            }
            
            return new StationDetailDays()
            {
                StationDetails = json
            };
        }

        public TemperatureReadingsOverTimeDto FetchStationWeekTemperatureReadingsOverTime(int stationID)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == stationID)
                .Select(i => new TemperatureReadingOverTimeDto(
                    i.StationId, i.Temperature.ToString(),i.Humidity.ToString(),i.AirPressure.ToString(),i.AmbientLight.ToString(),i.ReadingDateTime));
            
            /*var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == StationId)
                .Select(x => new TemperatureReadingOverTimeDto(x.StationId, x.Temperature.ToString(),x.ReadingDateTime));*/

            
            return new TemperatureReadingsOverTimeDto
            {
                TemperatureReadingOverTime = readings.ToList()
            };
        }

        public TemperatureReadingsOverTimeDto FetchStationMonthTemperatureReadingsOverTime(int stationID)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-31) && x.StationId == stationID)
                .Select(i => new TemperatureReadingOverTimeDto(
                    i.StationId, i.Temperature.ToString(),i.Humidity.ToString(),i.AirPressure.ToString(),i.AmbientLight.ToString(),i.ReadingDateTime));
            
            /*var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-31) && x.StationId == StationId)
                .Select(x => new TemperatureReadingOverTimeDto(x.StationId, x.Temperature.ToString(),x.ReadingDateTime));*/

            
            return new TemperatureReadingsOverTimeDto
            {
                TemperatureReadingOverTime = readings.ToList()
            };
        }
    }
}