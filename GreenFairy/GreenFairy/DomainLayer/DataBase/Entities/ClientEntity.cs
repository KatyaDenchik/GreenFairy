using GreenFairy.DomainLayer.DataBase.Entities.Abstract;

namespace GreenFairy.DomainLayer.DataBase.Entities
{
    public class ClientEntity : UserEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }


    }
}
