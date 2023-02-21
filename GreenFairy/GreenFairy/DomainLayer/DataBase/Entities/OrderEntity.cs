using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using GreenFairy.Enums;
using Microsoft.VisualBasic;
using System.Collections;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class OrderEntity : IEntity
    {
        public int Id { get; set; }
        public virtual ClientEntity Client { get; set; }
        public virtual ICollection<PlantEntity> Plants { get; set; }
        public DeliveryKind DeliveryKind { get; set; }
        public PaymentKind PaymentKind { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int PlantsCount { get; set; }
        public DateTime DateAndTime { get; set; }

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
