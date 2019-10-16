using System;

namespace WeatherStationApi._01_Common.Interfaces
{
    public interface IAddZeroEntries
    {
        DateTime GetDateTime();
        void SetDateTime(DateTime ReadingTime);
    }
}