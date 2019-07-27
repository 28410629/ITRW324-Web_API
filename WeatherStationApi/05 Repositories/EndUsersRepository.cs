using WeatherStationApi._02_Models;
using WeatherStationApi._04_Interfaces.Repositories;

namespace WeatherStationApi._05_Repositories
{
    public class EndUsersRepository : EntityFrameworkRepository<EndUser>, IEndUsersRepository
    {
        public EndUsersRepository(DataContextFactory factory) : base(factory)
        { }

    }
}