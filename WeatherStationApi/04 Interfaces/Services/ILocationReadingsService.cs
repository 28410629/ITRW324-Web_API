using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ILocationReadingsService
    {
        // interface for accessing FetchLocationDetailDay from LocationReadingsDto.
        LocationReadingsDto FetchLocationDetailDay(string Province, string City, DateTime Date);

        // interface for accessing FetchLocationDetailWeek from LocationReadingsDto.
        LocationReadingsDto FetchLocationDetailWeek(string Province, string City, DateTime Date);

        // interface for accessing FetchLocationDetailMonth from LocationReadingsDto.
        LocationReadingsDto FetchLocationDetailMonth(string Province, string City, DateTime Date);

        // interface for accessing FetchLocationDetailYear from LocationReadingsDto.
        LocationReadingsDto FetchLocationDetailYear(string Province, string ciCityty, DateTime Date);
    }
}
