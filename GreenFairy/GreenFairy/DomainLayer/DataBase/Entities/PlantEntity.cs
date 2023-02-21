using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using System.Collections;
using System.Net;
using System.Numerics;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class PlantEntity : IEntity
    {
        public int Id { get; set; }
        public string Species { get; set; } = string.Empty; // Представляет пустую строку, чтобы в бд не писался NULL
        public string Group { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public byte[] Photo { get; set; } = new byte[0];

        public virtual ICollection<OrderEntity> Orders { get; set; }

        // Каждая сущность сама себя удаляет или сохраняет, ибо в админской часте не ясно какой тип сущности
        public void Delete(Repository repository)
        {
            repository.Delete(this);
        }

        public void SaveToDB(Repository repository)
        {
            repository.Create(this);
        }
    }
}
