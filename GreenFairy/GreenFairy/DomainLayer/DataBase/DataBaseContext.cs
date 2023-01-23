using GreenFairy.DomainLayer.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenFairy.DomainLayer.DataBase
{
    public class DataBaseContext : DbContext
    {
        private const string standartPath = "./DataBaseGreenFairy.db";
        private static bool firstConnection = true;
        public DataBaseContext()
        {
            if (firstConnection)
            {
                Database.Migrate();
                firstConnection = false;
            }
        }
        public DbSet<AdminEntity> AdminEntities { get; set; }
        public DbSet<ClientEntity> ClientEntities { get; set; }
        public DbSet<OrderEntity> OrderEntities { get; set; }
        public DbSet<OrderHistoryEntity> OrderHistoryEntities { get; set; }
        public DbSet<PlantEntity> PlantEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={standartPath}");
    }
}
