namespace GreenFairy.DomainLayer.DataBase.Entities.Abstract
{
    public abstract class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
