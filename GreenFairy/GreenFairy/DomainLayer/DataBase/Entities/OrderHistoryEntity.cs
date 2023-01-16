﻿using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using System.Collections;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class OrderHistoryEntity : IEntity
    {
        public ClientEntity Client { get; set; }
        public int Id { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }

        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void SaveToDB(Repository repository)
        {
            repository.Create(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
