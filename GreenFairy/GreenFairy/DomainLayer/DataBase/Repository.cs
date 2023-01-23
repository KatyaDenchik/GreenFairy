using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GreenFairy.DomainLayer.DataBase
{
    public class Repository
    {
        private DataBaseContext Context = new DataBaseContext();
        public async void Create<T>(T entity) where T : class, IEntity
        {
            Context.ChangeTracker.Clear();
            var dbSet = Context.Set<T>();

            if (dbSet.Contains(entity))
            {
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return;
            }
            dbSet.Add(entity);
            await Context.SaveChangesAsync();
        }
        public async void Create<T>(params T[] entities) where T : class, IEntity
        {
            foreach (var entity in entities)
            {
                Create(entity);
            }
        }
        public IEnumerable<T> Get<T>(Func<T, bool> specification) where T : class, IEntity
        {
            Context.ChangeTracker.Clear();
            var dbSet = Context.Set<T>();
            return dbSet.AsNoTracking().Where(specification);
        }
        public IEnumerable<T> Get<T>() where T : class, IEntity
        {
            return Get<T>(s => true);
        }
        public async void Delete<T>(T entity) where T : class, IEntity
        {
            Context.ChangeTracker.Clear();
            var dbSet = Context.Set<T>();
            dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
        public async void Delete<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            Context.ChangeTracker.Clear();
            var dbSet = Context.Set<T>();
            dbSet.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
        public async void Delete<T>(Func<T, bool> specification) where T : class, IEntity
        {
            Delete<T>(Get(specification));
        }
    }
}
