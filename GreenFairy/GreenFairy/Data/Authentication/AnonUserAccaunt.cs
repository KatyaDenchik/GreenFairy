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

        public void AddPlant(OrderedPlantEntity orderedPlant)
        {
            orderedPlant.Amount = 1;
            if (CurentOrder.Plants.Any(s=>s.Plant.Name== orderedPlant.Plant.Name))
            {
                var oldPlant = CurentOrder.Plants.First(s => s.Plant.Name == orderedPlant.Plant.Name);
                oldPlant.Amount++;
            }
            else
            {
                CurentOrder.Plants.Add(orderedPlant);
            }
        }
    }
}
