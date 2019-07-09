﻿using System;

namespace WeatherStationApi._05_Repositories
{
    public class DataContextFactory : IDisposable
    {
        private WeatherStationDbContext _context;

        public WeatherStationDbContext Entities
        {
            get
            {
                if (_context == null)
                {
                    _context = new WeatherStationDbContext();
                }

                return _context;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
