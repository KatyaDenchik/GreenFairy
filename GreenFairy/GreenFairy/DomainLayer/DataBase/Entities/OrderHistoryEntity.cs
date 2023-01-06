using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class OrderHistoryEntity : IEntity
    {
        public ClientEntity Client { get ; set ; }
        public int Id { get ; set; }
        public ICollection<OrderEntity> Orders { get ; set ; }
    }
}
