using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using System.Collections;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class OrderHistoryEntity : IEntity
    {
        public ClientEntity Client { get; set; } = new ClientEntity();
        public int Id { get; set; }
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

        public void Delete(Repository repository)
        {
            throw new NotImplementedException();
        }

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
