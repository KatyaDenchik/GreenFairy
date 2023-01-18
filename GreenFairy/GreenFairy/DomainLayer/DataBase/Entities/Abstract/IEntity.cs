namespace GreenFairy.DomainLayer.DataBase.Entities.Abstract
{
    public interface IEntity : IEnumerable<object>
    {
        int Id { get; set; }

        void SaveToDB(Repository repository);
        void Delete(Repository repository);
    }
}
