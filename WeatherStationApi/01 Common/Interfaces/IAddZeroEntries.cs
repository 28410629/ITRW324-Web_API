using System;

namespace WeatherStationApi._01_Common.Interfaces
{
    public interface IAddZeroEntries
    {
        // method to get datetime from dto.
        DateTime GetDateTime();
        
        // method to set datetime on dto.
        void SetDateTime(DateTime ReadingTime);
    }
}