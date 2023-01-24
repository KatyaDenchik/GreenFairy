using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using GreenFairy.Enums;
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

        public void Delete(Repository repository)
        {
            repository.Delete(this);
        }

        public IEnumerator<object> GetEnumerator()
        {
            yield return Id;
            yield return Client;
            yield return Plants;
            yield return DeliveryKind;
            yield return PaymentKind;
            yield return Comment;
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
