using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WeatherStationApi._01_Common.Utilities;

namespace WeatherStationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception e)
            {
                LogErrorEmail.SendError(e);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureKestrel((context, options) =>
                {
                    options.Listen(IPAddress.Any, 8000);
                    options.Listen(IPAddress.Any, 8001, listenOptions =>
                    {
                        listenOptions.UseHttps("certificate.pfx","Olideadsykes1");
                    });
                });

    }
}