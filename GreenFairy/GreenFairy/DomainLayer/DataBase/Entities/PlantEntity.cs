using GreenFairy.DomainLayer.DataBase.Entities.Abstract;
using System.Drawing;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class PlantEntity : IEntity
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
    }
}
