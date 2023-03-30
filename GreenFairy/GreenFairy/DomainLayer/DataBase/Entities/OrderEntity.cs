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
            var itself = repository.Get<OrderEntity>(s => s.Id == this.Id);
            if (itself != null)
            {
                repository.Delete(itself);
            }
        }

        public void SaveToDB(Repository repository)
        {
            repository.Create(this);
        }
    }

}
