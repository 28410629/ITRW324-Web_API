using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ILocationReadingsService
    {
        // interface for accessing FetchLocationDetailDay in LocationReadingsDto.
        LocationReadingsDto FetchLocationDetailDay(string Province, string City, DateTime Date);

        // interface for accessing FetchLocationDetailWeek in LocationReadingsDto.
        LocationReadingsDto FetchLocationDetailWeek(string Province, string City, DateTime Date);

        // interface for accessing FetchLocationDetailMonth in LocationReadingsDto.
        LocationReadingsDto FetchLocationDetailMonth(string Province, string City, DateTime Date);

        // interface for accessing FetchLocationDetailYear in LocationReadingsDto.
        LocationReadingsDto FetchLocationDetailYear(string Province, string ciCityty, DateTime Date);
    }
}
