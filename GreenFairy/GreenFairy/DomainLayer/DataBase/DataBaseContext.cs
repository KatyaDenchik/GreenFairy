using GreenFairy.DomainLayer.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenFairy.DomainLayer.DataBase
{
    /// <summary>
    /// Класс контекста бд для работы бд с помощью EntityFramework
    /// </summary>

    public class DataBaseContext : DbContext
    { 
        /// <summary>
        /// Путь к бд
        /// </summary>
        private const string standartPath = "./DataBaseGreenFairy.db";
        /// <summary>
        /// Переменная, указывающая первое ли подключение
        /// </summary>
        private static bool firstConnection = true;

        //Add-Migration SecondMigration
        public DataBaseContext()
        {
            if (firstConnection)
            {
                //Закоментировать перед миграцией
                Database.Migrate();
                firstConnection = false;
            }
        }
        /// <summary>
        /// Коллекции сущностей в виде таблиц
        /// </summary>
        public DbSet<AdminEntity> AdminEntities { get; set; }
        public DbSet<ClientEntity> ClientEntities { get; set; }
        public DbSet<OrderEntity> OrderEntities { get; set; }
        public DbSet<PlantEntity> PlantEntities { get; set; }
        /// <summary>
        /// Метод для настройки бд
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)=>
            options.UseLazyLoadingProxies(). // подключение ленивой загрузки привязаных данных (при запросе сущности будут вытащены все связанные с ней сущности)
            UseSqlite($"Data Source={standartPath}"); 
        
    }
}
