using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ILocationReadingsService
    {
        LocationReadingsDto FetchLocationDetailDay(string Province, string City, DateTime Date);
        LocationReadingsDto FetchLocationDetailWeek(string Province, string City, DateTime Date);
        LocationReadingsDto FetchLocationDetailMonth(string Province, string City, DateTime Date);
        LocationReadingsDto FetchLocationDetailYear(string Province, string ciCityty, DateTime Date);
    }
}
