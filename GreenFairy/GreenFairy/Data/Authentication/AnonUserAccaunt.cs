using GreenFairy.DomainLayer.DataBase.Entities;

namespace GreenFairy.Data.Authentication
{
    public class AnonUserAccaunt: UserAccount
    {
        public List<PlantEntity> Plants { get; } = new List<PlantEntity>();
        public AnonUserAccaunt()
        {
            Role = "Anon";
        }
    }
}
