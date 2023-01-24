using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using System.Collections;
using System.Net;
using System.Numerics;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class PlantEntity : IEntity
    {
        public int Id { get; set; }
        public string Species { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public byte[] Photo { get; set; } = new byte[0];

        public virtual ICollection<OrderEntity> Orders { get; set; }
        public void Delete(Repository repository)
        {
            repository.Delete(this);
        }

        public IEnumerator<object> GetEnumerator()
        {
            yield return Id;
            yield return Species;
            yield return Group;
            yield return Name;
            yield return Amount;
            yield return Price;
            yield return Description;
            yield return Photo;
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
