using GreenFairy.DomainLayer.DataBase;
using GreenFairy.DomainLayer.DataBase.Entities;
using GreenFairy.DomainLayer.DataBase.Entities.Abstract;

namespace GreenFairy.Data
{
    public class EntityService
    {
        private Repository repository;
        public EntityService(Repository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<IEntity> GetEntities(Type type)
        {
            return type.Name switch
            {
                "AdminEntity" => repository.Get<AdminEntity>(),
                "ClientEntity" => repository.Get<ClientEntity>(),
                "OrderEntity" => repository.Get<OrderEntity>(),
                "PlantEntity" => repository.Get<PlantEntity>(),
            };
        }
    }
}
