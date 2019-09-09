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
                    if (humMin > data[i].HumiditiyReading)
                    {
                        humMin = data[i].HumiditiyReading;
                    }

                    if (humMax < data[i].HumiditiyReading)
                    {
                        humMax = data[i].HumiditiyReading;
                    }

                    air += data[i].AirPressureReading;
                    if (airMin > data[i].AirPressureReading)
                    {
                        airMin = data[i].AirPressureReading;
                    }

                    if (airMax < data[i].AirPressureReading)
                    {
                        airMax = data[i].AirPressureReading;
                    }

                    light += data[i].AmbientLightReading;
                    if (lightMin > data[i].AmbientLightReading)
                    {
                        lightMin = data[i].AmbientLightReading;
                    }

                    if (lightMax < data[i].AmbientLightReading)
                    {
                        lightMax = data[i].AmbientLightReading;
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
                    currentHour = data[i].ReadingTime.Hour;
                    count = 0;
                    temp = 0;
                    tempMin = double.MaxValue;
                    tempMax = double.MinValue;
                    hum = 0;
                    humMin = double.MaxValue;
                    humMax = double.MinValue;
                    air = 0;
                    airMin = double.MaxValue;
                    airMax = double.MinValue;
                    light = 0;
                    lightMin = double.MaxValue;
                    lightMax = double.MinValue;
                    // start with new value
                    temp += data[i].TemperatureReading;
                    hum += data[i].HumiditiyReading;
                    air += data[i].AirPressureReading;
                    light += data[i].AmbientLightReading;
                    count++;
                }

                Console.Write("Processing: " + (i +1) + "/" + data.Count + "\r");
            }
            
            Console.WriteLine();
            Console.WriteLine("Completion time: " + (DateTime.Now - begin).Seconds);

            return json;
        }
        
        public static List<StationDetailDay> ProcessWeekReadings(List<StationDetail> data)
        {
            Console.WriteLine("Process data");
            
            int currentHour = data[0].ReadingTime.Day;
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
                if (currentHour == data[i].ReadingTime.Day)
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
                    if (humMin > data[i].HumiditiyReading)
                    {
                        humMin = data[i].HumiditiyReading;
                    }

                    if (humMax < data[i].HumiditiyReading)
                    {
                        humMax = data[i].HumiditiyReading;
                    }

                    air += data[i].AirPressureReading;
                    if (airMin > data[i].AirPressureReading)
                    {
                        airMin = data[i].AirPressureReading;
                    }

                    if (airMax < data[i].AirPressureReading)
                    {
                        airMax = data[i].AirPressureReading;
                    }

                    light += data[i].AmbientLightReading;
                    if (lightMin > data[i].AmbientLightReading)
                    {
                        lightMin = data[i].AmbientLightReading;
                    }

                    if (lightMax < data[i].AmbientLightReading)
                    {
                        lightMax = data[i].AmbientLightReading;
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
                    currentHour = data[i].ReadingTime.Day;
                    count = 0;
                    temp = 0;
                    tempMin = double.MaxValue;
                    tempMax = double.MinValue;
                    hum = 0;
                    humMin = double.MaxValue;
                    humMax = double.MinValue;
                    air = 0;
                    airMin = double.MaxValue;
                    airMax = double.MinValue;
                    light = 0;
                    lightMin = double.MaxValue;
                    lightMax = double.MinValue;
                    // start with new value
                    temp += data[i].TemperatureReading;
                    hum += data[i].HumiditiyReading;
                    air += data[i].AirPressureReading;
                    light += data[i].AmbientLightReading;
                    count++;
                }

                Console.Write("Processing: " + (i +1) + "/" + data.Count + "\r");
            }
            
            Console.WriteLine();
            Console.WriteLine("Completion time: " + (DateTime.Now - begin).Seconds);

            return json;
        }
        
        public static List<StationDetailDay> ProcessMonthReadings(List<StationDetail> data)
        {
            Console.WriteLine("Process data");
            
            int currentHour = data[0].ReadingTime.Day;
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
                if (currentHour == data[i].ReadingTime.Day)
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
                    if (humMin > data[i].HumiditiyReading)
                    {
                        humMin = data[i].HumiditiyReading;
                    }

                    if (humMax < data[i].HumiditiyReading)
                    {
                        humMax = data[i].HumiditiyReading;
                    }

                    air += data[i].AirPressureReading;
                    if (airMin > data[i].AirPressureReading)
                    {
                        airMin = data[i].AirPressureReading;
                    }

                    if (airMax < data[i].AirPressureReading)
                    {
                        airMax = data[i].AirPressureReading;
                    }

                    light += data[i].AmbientLightReading;
                    if (lightMin > data[i].AmbientLightReading)
                    {
                        lightMin = data[i].AmbientLightReading;
                    }

                    if (lightMax < data[i].AmbientLightReading)
                    {
                        lightMax = data[i].AmbientLightReading;
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
                    currentHour = data[i].ReadingTime.Day;
                    count = 0;
                    temp = 0;
                    tempMin = double.MaxValue;
                    tempMax = double.MinValue;
                    hum = 0;
                    humMin = double.MaxValue;
                    humMax = double.MinValue;
                    air = 0;
                    airMin = double.MaxValue;
                    airMax = double.MinValue;
                    light = 0;
                    lightMin = double.MaxValue;
                    lightMax = double.MinValue;
                    // start with new value
                    temp += data[i].TemperatureReading;
                    hum += data[i].HumiditiyReading;
                    air += data[i].AirPressureReading;
                    light += data[i].AmbientLightReading;
                    count++;
                }

                Console.Write("Processing: " + (i +1) + "/" + data.Count + "\r");
            }
            
            Console.WriteLine();
            Console.WriteLine("Completion time: " + (DateTime.Now - begin).Seconds);

            return json;
        }
        
        public static List<StationDetailDay> ProcessYearReadings(List<StationDetail> data)
        {
            Console.WriteLine("Process data");
            
            int currentHour = data[0].ReadingTime.Month;
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
                if (currentHour == data[i].ReadingTime.Month)
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
                    if (humMin > data[i].HumiditiyReading)
                    {
                        humMin = data[i].HumiditiyReading;
                    }

                    if (humMax < data[i].HumiditiyReading)
                    {
                        humMax = data[i].HumiditiyReading;
                    }

                    air += data[i].AirPressureReading;
                    if (airMin > data[i].AirPressureReading)
                    {
                        airMin = data[i].AirPressureReading;
                    }

                    if (airMax < data[i].AirPressureReading)
                    {
                        airMax = data[i].AirPressureReading;
                    }

                    light += data[i].AmbientLightReading;
                    if (lightMin > data[i].AmbientLightReading)
                    {
                        lightMin = data[i].AmbientLightReading;
                    }

                    if (lightMax < data[i].AmbientLightReading)
                    {
                        lightMax = data[i].AmbientLightReading;
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
                    currentHour = data[i].ReadingTime.Month;
                    count = 0;
                    temp = 0;
                    tempMin = double.MaxValue;
                    tempMax = double.MinValue;
                    hum = 0;
                    humMin = double.MaxValue;
                    humMax = double.MinValue;
                    air = 0;
                    airMin = double.MaxValue;
                    airMax = double.MinValue;
                    light = 0;
                    lightMin = double.MaxValue;
                    lightMax = double.MinValue;
                    // start with new value
                    temp += data[i].TemperatureReading;
                    hum += data[i].HumiditiyReading;
                    air += data[i].AirPressureReading;
                    light += data[i].AmbientLightReading;
                    count++;
                }

                Console.Write("Processing: " + (i +1) + "/" + data.Count + "\r");
            }
            
            Console.WriteLine();
            Console.WriteLine("Completion time: " + (DateTime.Now - begin).Seconds);

            return json;
        }
    }
}