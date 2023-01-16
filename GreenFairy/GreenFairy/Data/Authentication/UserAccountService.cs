using GreenFairy.DomainLayer.DataBase;
using GreenFairy.DomainLayer.DataBase.Entities;

namespace GreenFairy.Data.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> users = new List<UserAccount>();
        public UserAccountService(Repository repository)
        {
            var admins = repository.Get<AdminEntity>();
            users.AddRange(admins.Select(admin => new UserAccount { Name = admin.Email, Password = admin.Password, Role = "Admin" }));

            var clients = repository.Get<ClientEntity>();
            users.AddRange(clients.Select(client => new UserAccount { Name = client.Name, Password = client.Password, Role = "Client" }));

            users.Add(new UserAccount { Name = "BigAdmin", Password = "Admin", Role = "Admin" });
        }

        public UserAccount? GetUserByName(string name)
        {
            return users.FirstOrDefault(s => s.Name == name);
        }
    }
}
