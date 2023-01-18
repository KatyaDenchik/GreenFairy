using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using GreenFairy.Enums;
using System.Collections;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class OrderEntity : IEntity
    {
        public int Id { get; set; }
        public ClientEntity Client { get; set; } = new ClientEntity();
        public ICollection<PlantEntity> Plants { get; set; }
        public DeliveryKind DeliveryKind { get; set; }
        public PaymentKind PaymentKind { get; set; }
        public string Comment { get; set; } = string.Empty;

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
