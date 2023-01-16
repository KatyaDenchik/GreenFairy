using GreenFairy.DomainLayer.DataBase.Entities.Abstract;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class AdminEntity : UserEntity
    {
        public override IEnumerator<object> GetEnumerator()
        {
            yield return Email;
            yield return Password;
        }

        public override void SaveToDB(Repository repository)
        {
            repository.Create(this);
        }
    }
}
