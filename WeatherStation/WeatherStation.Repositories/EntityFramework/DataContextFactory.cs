namespace WeatherStation.Repositories.EntityFramework
{
    class DataContextFactory
    {
        private WeatherStationDataContext _context;

        public DataContextFactory()
        {
        }

        public WeatherStationDataContext Entities
        {
            get
            {
                if (_context == null)
                {
                    _context = new WeatherStationDataContext();
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
