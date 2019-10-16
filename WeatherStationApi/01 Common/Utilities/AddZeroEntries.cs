using System.Collections.Generic;

namespace WeatherStationApi._01_Common.Utilities
{
    public class AddZeroEntries
    {
        public static void AddHourZeroEntries(List<> ReadingsList)
        {
            for (int i = 1; i < ReadingsList.Count(); i++)
            {
                if (ReadingsList[i-1].ReadingTime.AddHours(1).CompareTo(ReadingsList[i].ReadingTime) != 0)
                {
                    ReadingsList.Insert(i, new StationDetailDay(
                        ReadingsList[i].StationId,
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        ReadingsList[i-1].ReadingTime.AddHours(1)));
                    --i;
                }
            }
        }
        
        public static void AddDayZeroEntries(List<> ReadingsList)
        {
            for (int i = 1; i < ReadingsList.Count(); i++)
            {
                if (ReadingsList[i-1].ReadingTime.AddHours(1).CompareTo(ReadingsList[i].ReadingTime) != 0)
                {
                    ReadingsList.Insert(i, new StationDetailDay(
                        ReadingsList[i].StationId,
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        ReadingsList[i-1].ReadingTime.AddHours(1)));
                    --i;
                }
            }
        }
        
        public static void AddMonthZeroEntries(List<> ReadingsList)
        {
            for (int i = 1; i < ReadingsList.Count(); i++)
            {
                if (ReadingsList[i-1].ReadingTime.AddHours(1).CompareTo(ReadingsList[i].ReadingTime) != 0)
                {
                    ReadingsList.Insert(i, new StationDetailDay(
                        ReadingsList[i].StationId,
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        0.ToString(),
                        ReadingsList[i-1].ReadingTime.AddHours(1)));
                    --i;
                }
            }
        }
    }
}