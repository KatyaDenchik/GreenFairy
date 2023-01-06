using GreenFairy.DomainLayer.DataBase.Entities;
using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFairy.DomainLayer.DataBase
{
    public class Repository
    {
        private DataBaseContext context = new DataBaseContext();
        public async void Create<T>(T entity) where T : class, IEntity
        {
            var dbSet = context.Set<T>();

            if (dbSet.Contains(entity))
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return;
            }
            dbSet.Add(entity);
            await context.SaveChangesAsync();
        }
        public async void Create<T>(params T[] entities) where T: class, IEntity
        {
            foreach (var entity in entities)
            {
                Create(entity);
            }
        }
        public IEnumerable<T> Get<T>(Func<T, bool> specification) where T:class, IEntity
        {
            var dbSet = context.Set<T>();
            return dbSet.AsNoTracking().Where(specification);
        }
        public async void Delete<T>(T entity) where T: class, IEntity
        {
            var dbSet = context.Set<T>();
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
        public async void Delete<T>(Func<T, bool> specification) where T: class, IEntity
        {
            var dbSet = context.Set<T>();
            dbSet.RemoveRange(Get(specification));
            await context.SaveChangesAsync();
        }
    }
}
