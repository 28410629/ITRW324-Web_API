using System;
using System.Linq;
using WeatherStationApi._02_Models;
using WeatherStationApi._04_Interfaces.Repositories;

namespace WeatherStationApi._05_Repositories
{
    public class ReadingsRepository : EntityFrameworkRepository<Reading>, IReadingsRepository
    {
        public ReadingsRepository(DataContextFactory factory) : base(factory)
        { }
        
        // fetch readings for last hour.
        public virtual IQueryable<Reading> FetchHour(DateTime Date)
        {
            return Entities.Set<Reading>()
                .Where(x => x.ReadingDateTime >= Date.AddHours(-1))
                .AsQueryable();
        }
        
        // fetch readings for last day.
        public virtual IQueryable<Reading> FetchDay(DateTime Date)
        {
            return Entities.Set<Reading>()
                .Where(x => x.ReadingDateTime >= Date.AddDays(-1))
                .AsQueryable();
        }
        
        // fetch readings for last week.
        public virtual IQueryable<Reading> FetchWeek(DateTime Date)
        {
            return Entities.Set<Reading>()
                .Where(x => x.ReadingDateTime >= Date.AddDays(-7))
                .AsQueryable();
        }
        
        // fetch readings for last month.
        public virtual IQueryable<Reading> FetchMonth(DateTime Date)
        {
            return Entities.Set<Reading>()
                .Where(x => x.ReadingDateTime >= Date.AddMonths(-1))
                .AsQueryable();
        }
        
        // fetch readings for last year.
        public virtual IQueryable<Reading> FetchYear(DateTime Date)
        {
            return Entities.Set<Reading>()
                .Where(x => x.ReadingDateTime >= Date.AddYears(-1))
                .AsQueryable();
        }

        // fetch readings for last hour per station.
        public virtual IQueryable<Reading> FetchHourStation(int StationId, DateTime Date)
        {
            return FetchHour(Date)
                .Where(s => s.StationId == StationId)
                .AsQueryable();
        }
        
        // fetch readings for last day per station.
        public virtual IQueryable<Reading> FetchDayStation(int StationId, DateTime Date)
        {
            return FetchDay(Date)
                .Where(s => s.StationId == StationId)
                .AsQueryable();
        }
        
        // fetch readings for last week per station.
        public virtual IQueryable<Reading> FetchWeekStation(int StationId, DateTime Date)
        {
            return FetchWeek(Date)
                .Where(s => s.StationId == StationId)
                .AsQueryable();
        }
        
        // fetch readings for last month per station.
        public virtual IQueryable<Reading> FetchMonthStation(int StationId, DateTime Date)
        {
            return FetchMonth(Date)
                .Where(s => s.StationId == StationId)
                .AsQueryable();
        }
        
        // fetch readings for last year per station.
        public virtual IQueryable<Reading> FetchYearStation(int StationId, DateTime Date)
        {
            return FetchYear(Date)
                .Where(s => s.StationId == StationId)
                .AsQueryable();
        }

        // fetch readings for last hour per location.
        public virtual IQueryable<Reading> FetchHourLocation(string Province, string City, DateTime Date)
        {
            return FetchHour(Date)
                .Where(l => l.Station.Location.City == City && l.Station.Location.Province == Province)
                .AsQueryable();
        }
        
        // fetch readings for last day per location.
        public virtual IQueryable<Reading> FetchDayLocation(string Province, string City, DateTime Date)
        {
            return FetchDay(Date)
                .Where(l => l.Station.Location.City == City && l.Station.Location.Province == Province)
                .AsQueryable();
        }
        
        // fetch readings for last week per location.
        public virtual IQueryable<Reading> FetchWeekLocation(string Province, string City, DateTime Date)
        {
            return FetchWeek(Date)
                .Where(l => l.Station.Location.City == City && l.Station.Location.Province == Province)
                .AsQueryable();
        }
        
        // fetch readings for last month per location.
        public virtual IQueryable<Reading> FetchMonthLocation(string Province, string City, DateTime Date)
        {
            return FetchMonth(Date)
                .Where(l => l.Station.Location.City == City && l.Station.Location.Province == Province)
                .AsQueryable();
        }
        
        // fetch readings for last year per location.
        public virtual IQueryable<Reading> FetchYearLocation(string Province, string City, DateTime Date)
        {
            return FetchYear(Date)
                .Where(l => l.Station.Location.City == City && l.Station.Location.Province == Province)
                .AsQueryable();
        }
    }
}
