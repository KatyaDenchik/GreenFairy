using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using GreenFairy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class OrderEntity : IEntity
    {
        public int Id { get; set; }
        public ClientEntity Client { get; set; }
        public ICollection<PlantEntity> Plants { get; set; }
        public DeliveryKind DeliveryKind { get; set; }
        public PaymentKind PaymentKind { get; set; }
        public string Comment { get; set; }
    }

}
