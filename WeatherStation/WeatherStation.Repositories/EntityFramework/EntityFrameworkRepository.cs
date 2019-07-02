using Microsoft.EntityFrameworkCore;
using System.Linq;
using WeatherStation.Interfaces.Repositories;

namespace WeatherStation.Repositories.EntityFramework
{
    public abstract class EntityFrameworkRepository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        private readonly DataContextFactory _factory = new DataContextFactory();

        protected WeatherStationDataContext Entities
        {
            get { return _factory.Entities; }
        }

        public void Add(TEntity entity)
        {
            Entities.Set<TEntity>().Add(entity);
        }

        public void Edit(TEntity entity)
        {
            Entities.Set<TEntity>().Attach(entity);
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            if (Entities.Entry(entity).State == EntityState.Detached)
            {
                Entities.Set<TEntity>().Attach(entity);
            }
            Entities.Set<TEntity>().Remove(entity);
        }

        public virtual IQueryable<TEntity> FetchAll()
        {
            return Entities.Set<TEntity>().AsQueryable();
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}
