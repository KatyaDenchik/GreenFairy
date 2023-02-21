namespace GreenFairy.DomainLayer.DataBase.Entities.Abstract
{
    public interface IEntity
    {
        int Id { get; set; }

        void SaveToDB(Repository repository);
        void Delete(Repository repository);
    }
}
