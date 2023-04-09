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

        public void AddPlant(PlantEntity plant)
        {
            plant.Amount = 1;
            if (CurentOrder.Plants.Any(s=>s.Name== plant.Name))
            {
                var oldPlant = CurentOrder.Plants.First(s => s.Name == plant.Name);
                oldPlant.Amount++;
            }
            else
            {
                CurentOrder.Plants.Add(plant);
            }
        }
    }
}
