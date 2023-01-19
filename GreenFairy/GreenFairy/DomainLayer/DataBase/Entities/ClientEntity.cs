using GreenFairy.DomainLayer.DataBase.Entities.Abstract;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class ClientEntity : UserEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Phone { get; set; }

        public override void Delete(Repository repository)
        {
            repository.Delete(this);
        }

        public override IEnumerator<object> GetEnumerator()
        {
            yield return Id;
            yield return Email;
            yield return Password;
            yield return Name;
            yield return Surname;
            yield return Address;
            yield return Phone;
        }

        public override void SaveToDB(Repository repository)
        {
            repository.Create(this);
        }
    }
}
