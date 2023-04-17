using GreenFairy.DomainLayer.DataBase.Entities;

namespace GreenFairy.Data.Authentication
{
    public class AnonUserAccaunt : UserAccount
    {
        public OrderEntity CurentOrder { get; } = new();
        public AnonUserAccaunt()
        {
            Role = "Anon";
        }

        public void AddPlant(OrderedPlantEntity orderedPlantOnStorage)
        {
            var orderedPlant = new OrderedPlantEntity 
            {
                Id = orderedPlantOnStorage.Id,
                Plant = orderedPlantOnStorage.Plant, 
                OrderingKind = Enums.OrderingKind.Ordered
            };
            orderedPlant.Amount = 1;
            if (CurentOrder.OrderedPlant.Any(s=>s.Plant.Name== orderedPlant.Plant.Name))
            {
                var oldPlant = CurentOrder.OrderedPlant.First(s => s.Plant.Name == orderedPlant.Plant.Name);
                oldPlant.Amount++;
            }
            else
            {
                CurentOrder.OrderedPlant.Add(orderedPlant);
            }
        }
    }
}
