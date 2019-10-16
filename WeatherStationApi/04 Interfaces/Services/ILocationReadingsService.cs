using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    // explicitly states methods for RawReadingsDto.
    public interface ILocationReadingsService
    {
        LocationReadingsDto FetchLocationDetailDay(string Province, string City, DateTime Date);
        LocationReadingsDto FetchLocationDetailWeek(string Province, string City, DateTime Date);
        LocationReadingsDto FetchLocationDetailMonth(string Province, string City, DateTime Date);
        LocationReadingsDto FetchLocationDetailYear(string Province, string ciCityty, DateTime Date);
    }
}
