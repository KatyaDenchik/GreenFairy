using GreenFairy.DomainLayer.DataBase.Entities.Abstract;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class AdminEntity : UserEntity
    {
        public override void SaveToDB(Repository repository)
        {
            repository.Create(this);
        }
        public override void Delete(Repository repository)
        {
            repository.Delete(this);
        }
    }
}
