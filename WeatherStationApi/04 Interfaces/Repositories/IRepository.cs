using System.Linq;

namespace WeatherStationApi._04_Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Add(TEntity entity);

        void Edit(TEntity entity);

        void Remove(TEntity entity);

        IQueryable<TEntity> FetchAll();

        void Save();
    }
}