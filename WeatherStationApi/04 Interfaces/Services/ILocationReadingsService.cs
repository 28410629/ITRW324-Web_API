using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ILocationReadingsService
    {
        LocationReadingsDto FetchLocationDetailDay(string province, string city, DateTime Date);
        LocationReadingsDto FetchLocationDetailWeek(string province, string city, DateTime Date);
        LocationReadingsDto FetchLocationDetailMonth(string province, string city, DateTime Date);
        LocationReadingsDto FetchLocationDetailYear(string province, string city, DateTime Date);
    }
}