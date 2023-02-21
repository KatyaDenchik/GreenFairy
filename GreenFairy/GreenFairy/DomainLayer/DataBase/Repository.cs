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
        /// <param name="specification">Условие, которому должна соответсвовать сущность</param>
        /// <returns>Коллекция сущностей, соответсвующие условию</returns>
        public IEnumerable<T> Get<T>(Func<T, bool> specification) where T : class, IEntity
        {
            var dbSet = Context.Set<T>();
            return dbSet.Where(specification);
        }
        
        /// <summary>
        /// Метод, который возвращает коллекцию сущностей определенного типа
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <returns>Коллекцию сущностей </returns>
        public IEnumerable<T> Get<T>() where T : class, IEntity
        {
            return Get<T>(s => true);
        }

        /// <summary>
        /// Метод, который удаляет конкретную сущность
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Конкретная сущность</param>
        public void Delete<T>(T entity) where T : class, IEntity
        {
            //получаем ссылку на таблицу
            var dbSet = Context.Set<T>();
            dbSet.Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Метод, который удаляет коллекцию сущностей
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entities">Конкретные сущности</param>
        public void Delete<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            var dbSet = Context.Set<T>();
            dbSet.RemoveRange(entities);
            Context.SaveChanges();
        }

        /// <summary>
        /// Метод, который удаляет коллекцию сущностей, которые соответсвуют условию
        /// </summary>
        /// <typeparam name="T">Тип сущностей</typeparam>
        /// <param name="specification">Условие</param>
        public async void Delete<T>(Func<T, bool> specification) where T : class, IEntity
        {
            Delete<T>(Get(specification));
        }
        
    }
}
