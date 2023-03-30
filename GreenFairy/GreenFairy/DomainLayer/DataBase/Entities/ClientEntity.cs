using GreenFairy.DomainLayer.DataBase.Entities.Abstract;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class ClientEntity : UserEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Phone { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
        public override void Delete(Repository repository)
        {
            var itself = repository.Get<ClientEntity>(s=>s.Id == this.Id);
            if (itself != null)
            {
                repository.Delete(itself);
            }
        }

        public override void SaveToDB(Repository repository)
        {
            repository.Create(this);
        }
    }
}
