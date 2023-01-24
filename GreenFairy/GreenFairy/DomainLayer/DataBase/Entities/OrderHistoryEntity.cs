using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using System.Collections;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class OrderHistoryEntity : IEntity
    {
        public int Id { get; set; }
        public virtual ClientEntity Client { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }

        public void Delete(Repository repository)
        {
            repository.Delete(this);
        }

        public IEnumerator<object> GetEnumerator()
        {
            yield return Id;
            yield return Client;
            yield return Orders;

        }

        public void SaveToDB(Repository repository)
        {
            repository.Create(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
