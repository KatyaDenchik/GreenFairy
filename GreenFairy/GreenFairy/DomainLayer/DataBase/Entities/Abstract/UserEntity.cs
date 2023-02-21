using System.Collections;

namespace GreenFairy.DomainLayer.DataBase.Entities.Abstract
{
    public abstract class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public abstract void Delete(Repository repository);
        public abstract void SaveToDB(Repository repository);

        // Можем передавать ID юзера в заказы, вместо указания имени и фамилии
        public override string ToString()
        {
            return Id.ToString();
        } 
    }
}
