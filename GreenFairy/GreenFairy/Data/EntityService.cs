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

        public IEnumerable<string> GetEntityHeaders(Type type)
        {
            var properties = type.GetProperties();
            var result = properties.Select(p => p.Name).ToList();
            result.Remove(result.FirstOrDefault(s=>s.Equals("Id", StringComparison.InvariantCultureIgnoreCase)));
            return result;
        }

        public IEnumerable<IEnumerable<string>> GetEntitiesString(IEnumerable<IEntity> entities)
        {
            List<List<string>> result = new List<List<string>>();
            foreach (var entity in entities)
            {
                var stringEntity = entity.GetType().GetProperties().Select(s => s.GetValue(entity)?.ToString());
                result.Add(stringEntity.ToList());
            }
            return result;
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
