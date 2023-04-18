using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using GreenFairy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class OrderedPlantEntity : IEntity
    {
        public int Id { get; set; }
        public virtual PlantEntity Plant { get; set; }
        public int Amount { get; set; }
        public OrderingKind OrderingKind { get; set; }
        public virtual OrderEntity Order { get; set; }
        public void Delete(Repository repository)
        {
            var itself = repository.Get<OrderedPlantEntity>(s => s.Id == this.Id);
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
