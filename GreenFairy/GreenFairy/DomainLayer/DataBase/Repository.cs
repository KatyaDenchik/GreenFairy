using GreenFairy.Data.Extensions;
using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GreenFairy.DomainLayer.DataBase
{
    public class Repository
    {
        private DataBaseContext Context = new DataBaseContext();
        public void Create<T>(T entity) where T : class, IEntity
        {
            var dbSet = Context.Set<T>();

            if (dbSet.Contains(entity))
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return;
            }
            dbSet.Add(entity);
            Context.SaveChanges();
        }
        public void Create<T>(params T[] entities) where T : class, IEntity
        {
            foreach (var entity in entities)
            {
                Create(entity);
            }
        }
        public IEnumerable<T> Get<T>(Func<T, bool> specification) where T : class, IEntity
        {
            var dbSet = Context.Set<T>();
            return dbSet.Where(specification);
        }
        public IEnumerable<T> Get<T>() where T : class, IEntity
        {
            return Get<T>(s => true);
        }
        public void Delete<T>(T entity) where T : class, IEntity
        {
            var dbSet = Context.Set<T>();
            dbSet.Remove(entity);
            Context.SaveChanges();
        }
        public void Delete<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            var dbSet = Context.Set<T>();
            dbSet.RemoveRange(entities);
            Context.SaveChanges();
        }
        public async void Delete<T>(Func<T, bool> specification) where T : class, IEntity
        {
            Delete<T>(Get(specification));
        }
        
    }
}
