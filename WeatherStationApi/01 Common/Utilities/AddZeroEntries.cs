using System.Collections.Generic;
using WeatherStationApi._01_Common.Interfaces;

namespace WeatherStationApi._01_Common.Utilities
{
    public class AddZeroEntries<T> where T: IAddZeroEntries, new()
    {
        public static List<T> AddHourZeroEntries(List<T> ReadingsList)
        {
            if (ReadingsList.Count >= 2)
            {
                for (int i = 1; i < ReadingsList.Count; i++)
                {
                    if (ReadingsList[i-1].GetDateTime().AddHours(1).CompareTo(ReadingsList[i].GetDateTime()) != 0)
                    {
                        ReadingsList.Insert(i, new T());
                        ReadingsList[i].SetDateTime(ReadingsList[i-1].GetDateTime().AddHours(1));
                    }
                }
            }
            return ReadingsList;
        }
        
        public static List<T> AddDayZeroEntries(List<T> ReadingsList)
        {
            if (ReadingsList.Count >= 2)
            {
                for (int i = 1; i < ReadingsList.Count; i++)
                {
                    if (ReadingsList[i-1].GetDateTime().AddDays(1).CompareTo(ReadingsList[i].GetDateTime()) != 0)
                    {
                        ReadingsList.Insert(i, new T());
                        ReadingsList[i].SetDateTime(ReadingsList[i-1].GetDateTime().AddDays(1));
                    }
                }
            }
            return ReadingsList;
        }
        
        public static List<T> AddMonthZeroEntries(List<T> ReadingsList)
        {
            if (ReadingsList.Count >= 2)
            {
                for (int i = 1; i < ReadingsList.Count; i++)
                {
                    if (ReadingsList[i-1].GetDateTime().AddMonths(1).CompareTo(ReadingsList[i].GetDateTime()) != 0)
                    {
                        ReadingsList.Insert(i, new T());
                        ReadingsList[i].SetDateTime(ReadingsList[i-1].GetDateTime().AddMonths(1));
                    }
                }
            }
            return ReadingsList;
        }
    }
}