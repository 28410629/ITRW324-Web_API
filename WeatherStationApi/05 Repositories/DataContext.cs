using Microsoft.EntityFrameworkCore;
using System;
using WeatherStationApi._02_Models;

namespace WeatherStationApi._05_Repositories
{
    public class WeatherStationDbContext : DbContext
    {
        public WeatherStationDbContext() { }
        
        public DbSet<Location> Location { get; set; }

        public DbSet<Station> Station { get; set; }

        public DbSet<Reading> Reading { get; set; }
        
        public DbSet<EndUser> EndUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseMySQL(
                    "server=localhost;database=WeatherDB;user=weather;password=Olideadsykes1");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error with DB connection string. Check DbContext.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tables
            modelBuilder.Entity<EndUser>(entity =>
            {
                entity.ToTable("ENDUSERS");
                
                entity.HasKey(e => e.UserId);
                
                entity.Property(e => e.UserId).HasColumnName("USERID").IsRequired();

                entity.Property(e => e.FirstName).HasColumnName("FIRSTNAME").IsRequired();

                entity.Property(e => e.LastName).HasColumnName("LASTNAME").IsRequired();

                entity.Property(e => e.Email).HasColumnName("EMAIL").IsRequired();
                
                entity.Property(e => e.Username).HasColumnName("USERNAME").IsRequired();
                
                entity.Property(e => e.Password).HasColumnName("PASSWORD").IsRequired();
                
            });
            
            
            
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("LOCATIONS");
                
                entity.HasKey(e => e.LocationId);

                entity.Property(e => e.LocationId).HasColumnName("LOCATIONID").IsRequired();

                entity.Property(e => e.LocationName).HasColumnName("LOCATIONNAME").IsRequired();
                
            });
            
            modelBuilder.Entity<Reading>(entity =>
            {
                entity.ToTable("STATIONS");
                
                entity.HasKey(e => e.ReadingId);

                entity.HasIndex(e => e.StationId);
                
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
            
            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("READINGS");
                
                entity.HasKey(e => e.StationId);

                entity.HasIndex(e => e.UserId);
                
                entity.HasIndex(e => e.LocationId);

                entity.Property(e => e.StationId).HasColumnName("STATIONID").IsRequired();

                entity.Property(e => e.UserId).HasColumnName("USERID").IsRequired();

                entity.Property(e => e.LocationId).HasColumnName("LOCATIONID");
                
                entity.Property(e => e.NickName).HasColumnName("NICKNAME");

                entity.HasOne(d => d.EndUser)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.UserId);
                
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.LocationId);
            });
            
        }
    }
}
