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
            var itself = repository.Get<AdminEntity>(s => s.Id == this.Id);
            if (itself != null)
            {
                repository.Delete(itself);
            }
        }
    }
}
