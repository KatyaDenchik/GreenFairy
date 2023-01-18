using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using System.Collections;

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
