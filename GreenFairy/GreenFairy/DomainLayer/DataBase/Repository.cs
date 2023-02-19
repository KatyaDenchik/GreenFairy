using GreenFairy.Data.Extensions;
using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GreenFairy.DomainLayer.DataBase
{
    /// <summary>
    /// Класс для инкапсуляции роботы с контекстом бд и предстовление CRUD интерфейса для доступа к сущностям в бд
    /// </summary>
    public class Repository
    {
        private DataBaseContext Context = new DataBaseContext();
        /// <summary>
        /// Метод для добавления или обновления сущности
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        public void Create<T>(T entity) where T : class, IEntity
        {
            /// Получаем ссылку на таблицу с указанной сущностю
            var dbSet = Context.Set<T>();
            //Если таблица содержит эту сущность, то обновляем сущность
            if (dbSet.Contains(entity))
            {   // Entry - метод для получения состояния сущности внутри бд
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return;
            }
            dbSet.Add(entity);
            Context.SaveChanges();
        }
        /// <summary>
        /// Метод для сохранения коллекции сущностей
        /// </summary>
        /// <typeparam name="T">Тип сущностей</typeparam>
        /// <param name="entities">Сущности</param>
        public void Create<T>(params T[] entities) where T : class, IEntity
        {
            foreach (var entity in entities)
            {
                Create(entity);
            }
        }
        /// <summary>
        /// Метод, который возвращает коллекцию сущностей, которые соответсвуют условию 
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="specification">Условие, которому должна ссответсвовать сущность</param>
        /// <returns>Коллекция сущностей, соответсвующие условию</returns>
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
