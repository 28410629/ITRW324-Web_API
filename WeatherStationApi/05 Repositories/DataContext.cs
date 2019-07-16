using Microsoft.EntityFrameworkCore;
using System;
using WeatherStationApi._02_Models;

namespace WeatherStationApi._05_Repositories
{
    public class WeatherStationDbContext : DbContext
    {
        public WeatherStationDbContext() { }

        public DbSet<Station> Station { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Example: 
            // optionsBuilder.UseSqlServer("Data Source=COENRAADHUM-PC\\SQLEXPRESS;Initial Catalog=dbEuropcar_DEV;Integrated Security=True;");
            try
            {
                optionsBuilder.UseMySQL("server=localhost;database=WeatherSystemDB;user=backend;password=Olideadsykes1");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Error with DB connection string. Check DbContext.");
            } 
        }
    }
}
