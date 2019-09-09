using System;
using System.Collections.Generic;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._01_Common.Utilities
{
    public class TimeRangeDataProcessing
    {
        public static List<StationDetailDay> ProcessDayReadings(List<StationDetail> data)
        {
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
            var begin = DateTime.Now;

            for (int i = 0; i < data.Count; i++)
            {
                if (currentHour == data[i].ReadingTime.Hour)
                {
                    temp += data[i].TemperatureReading;
                    if (tempMin > data[i].TemperatureReading)
                    {
                        tempMin = data[i].TemperatureReading;
                    }

                    if (tempMax < data[i].TemperatureReading)
                    {
                        tempMax = data[i].TemperatureReading;
                    }
                    
                    hum += data[i].HumiditiyReading;
                    if (humMin > data[i].TemperatureReading)
                    {
                        humMin = data[i].TemperatureReading;
                    }

                    if (humMax < data[i].TemperatureReading)
                    {
                        humMax = data[i].TemperatureReading;
                    }

                    air += data[i].AirPressureReading;
                    if (airMin > data[i].TemperatureReading)
                    {
                        airMin = data[i].TemperatureReading;
                    }

                    if (airMax < data[i].TemperatureReading)
                    {
                        airMax = data[i].TemperatureReading;
                    }

                    light += data[i].AmbientLightReading;
                    if (lightMin > data[i].TemperatureReading)
                    {
                        lightMin = data[i].TemperatureReading;
                    }

                    if (lightMax < data[i].TemperatureReading)
                    {
                        lightMax = data[i].TemperatureReading;
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
                        new DateTime(data[i - 1].ReadingTime.Year, data[i - 1].ReadingTime.Month, data[i - 1].ReadingTime.Day,data[i - 1].ReadingTime.Hour, 0, 0)));
                    // reset
                    count = 0;
                    temp = 0;
                    hum = 0;
                    air = 0;
                    light = 0;
                    currentHour = data[i].ReadingTime.Hour;
                    // start with new value
                    temp += data[i].TemperatureReading;
                    hum += data[i].HumiditiyReading;
                    air += data[i].AirPressureReading;
                    light += data[i].AmbientLightReading;
                    count++;
                }

                Console.Write("Processing: " + i + "/" + data.Count + "\r");
            }
            
            Console.WriteLine();
            Console.WriteLine("Completion time: " + (DateTime.Now - begin).Seconds);

            return json;
        }
        
        public static List<StationDetailDay> ProcessWeekReadings(List<StationDetail> data)
        {
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
            var begin = DateTime.Now;

            for (int i = 0; i < data.Count; i++)
            {
                if (currentHour == data[i].ReadingTime.Hour)
                {
                    temp += data[i].TemperatureReading;
                    if (tempMin > data[i].TemperatureReading)
                    {
                        tempMin = data[i].TemperatureReading;
                    }

                    if (tempMax < data[i].TemperatureReading)
                    {
                        tempMax = data[i].TemperatureReading;
                    }
                    
                    hum += data[i].HumiditiyReading;
                    if (humMin > data[i].TemperatureReading)
                    {
                        humMin = data[i].TemperatureReading;
                    }

                    if (humMax < data[i].TemperatureReading)
                    {
                        humMax = data[i].TemperatureReading;
                    }

                    air += data[i].AirPressureReading;
                    if (airMin > data[i].TemperatureReading)
                    {
                        airMin = data[i].TemperatureReading;
                    }

                    if (airMax < data[i].TemperatureReading)
                    {
                        airMax = data[i].TemperatureReading;
                    }

                    light += data[i].AmbientLightReading;
                    if (lightMin > data[i].TemperatureReading)
                    {
                        lightMin = data[i].TemperatureReading;
                    }

                    if (lightMax < data[i].TemperatureReading)
                    {
                        lightMax = data[i].TemperatureReading;
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
                        new DateTime(data[i - 1].ReadingTime.Year, data[i - 1].ReadingTime.Month, data[i - 1].ReadingTime.Day,data[i - 1].ReadingTime.Hour, 0, 0)));
                    // reset
                    count = 0;
                    temp = 0;
                    hum = 0;
                    air = 0;
                    light = 0;
                    currentHour = data[i].ReadingTime.Hour;
                    // start with new value
                    temp += data[i].TemperatureReading;
                    hum += data[i].HumiditiyReading;
                    air += data[i].AirPressureReading;
                    light += data[i].AmbientLightReading;
                    count++;
                }

                Console.Write("Processing: " + i + "/" + data.Count + "\r");
            }
            
            Console.WriteLine();
            Console.WriteLine("Completion time: " + (DateTime.Now - begin).Seconds);

            return json;
        }
        
        public static List<StationDetailDay> ProcessMonthReadings(List<StationDetail> data)
        {
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
            var begin = DateTime.Now;

            for (int i = 0; i < data.Count; i++)
            {
                if (currentHour == data[i].ReadingTime.Hour)
                {
                    temp += data[i].TemperatureReading;
                    if (tempMin > data[i].TemperatureReading)
                    {
                        tempMin = data[i].TemperatureReading;
                    }

                    if (tempMax < data[i].TemperatureReading)
                    {
                        tempMax = data[i].TemperatureReading;
                    }
                    
                    hum += data[i].HumiditiyReading;
                    if (humMin > data[i].TemperatureReading)
                    {
                        humMin = data[i].TemperatureReading;
                    }

                    if (humMax < data[i].TemperatureReading)
                    {
                        humMax = data[i].TemperatureReading;
                    }

                    air += data[i].AirPressureReading;
                    if (airMin > data[i].TemperatureReading)
                    {
                        airMin = data[i].TemperatureReading;
                    }

                    if (airMax < data[i].TemperatureReading)
                    {
                        airMax = data[i].TemperatureReading;
                    }

                    light += data[i].AmbientLightReading;
                    if (lightMin > data[i].TemperatureReading)
                    {
                        lightMin = data[i].TemperatureReading;
                    }

                    if (lightMax < data[i].TemperatureReading)
                    {
                        lightMax = data[i].TemperatureReading;
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
                        new DateTime(data[i - 1].ReadingTime.Year, data[i - 1].ReadingTime.Month, data[i - 1].ReadingTime.Day,data[i - 1].ReadingTime.Hour, 0, 0)));
                    // reset
                    count = 0;
                    temp = 0;
                    hum = 0;
                    air = 0;
                    light = 0;
                    currentHour = data[i].ReadingTime.Hour;
                    // start with new value
                    temp += data[i].TemperatureReading;
                    hum += data[i].HumiditiyReading;
                    air += data[i].AirPressureReading;
                    light += data[i].AmbientLightReading;
                    count++;
                }

                Console.Write("Processing: " + i + "/" + data.Count + "\r");
            }
            
            Console.WriteLine();
            Console.WriteLine("Completion time: " + (DateTime.Now - begin).Seconds);

            return json;
        }
        
        public static List<StationDetailDay> ProcessYearReadings(List<StationDetail> data)
        {
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
            var begin = DateTime.Now;

            for (int i = 0; i < data.Count; i++)
            {
                if (currentHour == data[i].ReadingTime.Hour)
                {
                    temp += data[i].TemperatureReading;
                    if (tempMin > data[i].TemperatureReading)
                    {
                        tempMin = data[i].TemperatureReading;
                    }

                    if (tempMax < data[i].TemperatureReading)
                    {
                        tempMax = data[i].TemperatureReading;
                    }
                    
                    hum += data[i].HumiditiyReading;
                    if (humMin > data[i].TemperatureReading)
                    {
                        humMin = data[i].TemperatureReading;
                    }

                    if (humMax < data[i].TemperatureReading)
                    {
                        humMax = data[i].TemperatureReading;
                    }

                    air += data[i].AirPressureReading;
                    if (airMin > data[i].TemperatureReading)
                    {
                        airMin = data[i].TemperatureReading;
                    }

                    if (airMax < data[i].TemperatureReading)
                    {
                        airMax = data[i].TemperatureReading;
                    }

                    light += data[i].AmbientLightReading;
                    if (lightMin > data[i].TemperatureReading)
                    {
                        lightMin = data[i].TemperatureReading;
                    }

                    if (lightMax < data[i].TemperatureReading)
                    {
                        lightMax = data[i].TemperatureReading;
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
                        new DateTime(data[i - 1].ReadingTime.Year, data[i - 1].ReadingTime.Month, data[i - 1].ReadingTime.Day,data[i - 1].ReadingTime.Hour, 0, 0)));
                    // reset
                    count = 0;
                    temp = 0;
                    hum = 0;
                    air = 0;
                    light = 0;
                    currentHour = data[i].ReadingTime.Hour;
                    // start with new value
                    temp += data[i].TemperatureReading;
                    hum += data[i].HumiditiyReading;
                    air += data[i].AirPressureReading;
                    light += data[i].AmbientLightReading;
                    count++;
                }

                Console.Write("Processing: " + i + "/" + data.Count + "\r");
            }
            
            Console.WriteLine();
            Console.WriteLine("Completion time: " + (DateTime.Now - begin).Seconds);

            return json;
        }
    }
}