using Microsoft.EntityFrameworkCore;
using WeatherStation.Models;

namespace WeatherStation.Repositories.EntityFramework
{
    public class WeatherStationDataContext : DbContext
    {
        public DbSet<Reading> Readings { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<StationReading> StationReadings { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // make settings file for this property, edit this to your dev DB
            optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        }
    }
}
