using System.Collections;

namespace GreenFairy.DomainLayer.DataBase.Entities.Abstract
{
    public abstract class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public abstract IEnumerator<object> GetEnumerator();
        public abstract void SaveToDB(Repository repository);

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
