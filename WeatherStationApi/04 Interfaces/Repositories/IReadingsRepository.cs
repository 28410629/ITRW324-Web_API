using System;
using System.Linq;
using WeatherStationApi._02_Models;

namespace WeatherStationApi._04_Interfaces.Repositories
{
    public interface IReadingsRepository : IRepository<Reading>
    {
         // fetch readings for last hour.
        IQueryable<Reading> FetchHour(DateTime Date);

        // fetch readings for last day.
        IQueryable<Reading> FetchDay(DateTime Date);

        // fetch readings for last week.
        IQueryable<Reading> FetchWeek(DateTime Date);

        // fetch readings for last month.
        IQueryable<Reading> FetchMonth(DateTime Date);

        // fetch readings for last year.
        IQueryable<Reading> FetchYear(DateTime Date);
        // fetch readings for last hour per station.
        IQueryable<Reading> FetchHourStation(int StationId, DateTime Date);

        // fetch readings for last day per station.
        IQueryable<Reading> FetchDayStation(int StationId, DateTime Date);

        // fetch readings for last week per station.
        IQueryable<Reading> FetchWeekStation(int StationId, DateTime Date);

        // fetch readings for last month per station.
        IQueryable<Reading> FetchMonthStation(int StationId, DateTime Date);

        // fetch readings for last year per station.
        IQueryable<Reading> FetchYearStation(int StationId, DateTime Date);

        // fetch readings for last hour per location.
        IQueryable<Reading> FetchHourLocation(string Province, string City, DateTime Date);

        // fetch readings for last day per location.
        IQueryable<Reading> FetchDayLocation(string Province, string City, DateTime Date);

        // fetch readings for last week per location.
        IQueryable<Reading> FetchWeekLocation(string Province, string City, DateTime Date);

        // fetch readings for last month per location.
        IQueryable<Reading> FetchMonthLocation(string Province, string City, DateTime Date);

        // fetch readings for last year per location.
        IQueryable<Reading> FetchYearLocation(string Province, string City, DateTime Date);
    }
}
