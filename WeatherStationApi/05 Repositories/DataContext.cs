using Microsoft.EntityFrameworkCore;
using System;
using WeatherStationApi._02_Models;

namespace WeatherStationApi._05_Repositories
{
    public class WeatherStationDbContext : DbContext
    {
        // tables on database.
        public WeatherStationDbContext() { }
        
        public DbSet<Location> Location { get; set; }

        public DbSet<Station> Station { get; set; }

        public DbSet<Reading> Reading { get; set; }
        
        // constructor
        public WeatherStationDbContext(DbContextOptions options) : base(options) { }
        
        // connection configuration to database.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
               if (!optionsBuilder.IsConfigured)
               {
                   optionsBuilder.UseMySql("server=localhost;database=WeatherDB;user=weather;password=Olideadsykes1;");
               }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error with DB connection string. Check DbContext.");
            }
        }

        // map the database to models.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // location table
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("LOCATIONS");
                
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.Province).HasColumnName("PROVINCE").IsRequired();
                
                entity.Property(e => e.City).HasColumnName("CITY").IsRequired();
            });
            
            // reading table
            modelBuilder.Entity<Reading>(entity =>
            {
                entity.ToTable("READINGS");
                
                entity.HasKey(e => e.ReadingId).HasName("READINGID");

                entity.HasIndex(e => e.StationId).HasName("STATIONID");
                
                entity.Property(e => e.ReadingId).HasColumnName("READINGID").IsRequired();

                entity.Property(e => e.StationId).HasColumnName("STATIONID").IsRequired();

                entity.Property(e => e.ReadingDateTime).HasColumnName("RDATETIME").HasDefaultValue(new DateTime());

                entity.Property(e => e.Temperature).HasColumnName("TEMPERATURE");

                entity.Property(e => e.AirPressure).HasColumnName("AIRPRESSURE");
                
                entity.Property(e => e.AmbientLight).HasColumnName("AMBIENTLIGHT");

                entity.Property(e => e.Humidity).HasColumnName("HUMIDITY");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Readings)
                    .HasForeignKey(d => d.StationId);
            });
            
            // station table
            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("STATIONS");
                
                entity.HasKey(e => e.StationId);

                entity.HasIndex(e => e.UserId);
                
                entity.HasIndex(e => e.LocationId);

                entity.Property(e => e.StationId).HasColumnName("STATIONID").IsRequired();

                entity.Property(e => e.LocationId).HasColumnName("LOCATIONID");
                
                entity.Property(e => e.NickName).HasColumnName("NICKNAME");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.LocationId);
            });
        }
    }
}
