using System.Linq;
using Microsoft.EntityFrameworkCore;
using WeatherStationApi._04_Interfaces;

namespace WeatherStationApi._05_Repositories
{
    // generic class for use by repositories to provide basic functionality.
    public abstract class EntityFrameworkRepository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        private readonly DataContextFactory _factory;
        
        public EntityFrameworkRepository(DataContextFactory factory)
        {
            _factory = factory;
        }

        // return entities in database for queries.
        protected WeatherStationDbContext Entities
        {
            get { return _factory.Entities; }
        }

        // add new entity to a table.
        public void Add(TEntity entity)
        {
            Entities.Set<TEntity>().Add(entity);
        }

        // edit an entity on a table.
        public void Edit(TEntity entity)
        {
            Entities.Set<TEntity>().Attach(entity);
            Entities.Entry(entity).State = EntityState.Modified;
        }

        // remove an entity from a table.
        public void Remove(TEntity entity)
        {
            if (Entities.Entry(entity).State == EntityState.Detached)
            {
                Entities.Set<TEntity>().Attach(entity);
            }
            Entities.Set<TEntity>().Remove(entity);
        }

        // gets all entities from a table.
        public virtual IQueryable<TEntity> FetchAll()
        {
            return Entities.Set<TEntity>().AsQueryable();
        }

        // commit entity changes to table.
        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}