using System.Linq;

namespace WeatherStationApi._04_Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        // add entity to database.
        void Add(TEntity entity);

        // edit entity on database.
        void Edit(TEntity entity);

        // remove entity from database.
        void Remove(TEntity entity);

        // fetch all entities from database.
        IQueryable<TEntity> FetchAll();

        // commit changes of entities to database.
        void Save();
    }
}
