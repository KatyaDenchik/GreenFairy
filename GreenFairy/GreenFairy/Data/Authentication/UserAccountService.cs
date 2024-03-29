﻿using GreenFairy.DomainLayer.DataBase;
using GreenFairy.DomainLayer.DataBase.Entities;

namespace GreenFairy.Data.Authentication
{
    public class UserAccountService
    {
        public static AnonUserAccaunt CurrentUser = new AnonUserAccaunt { Name = "TEST", Role = "Anon" };
        private List<UserAccount> users = new List<UserAccount>();
        private readonly Repository repository;

        public UserAccountService(Repository repository)
        {
            this.repository = repository;
        }

        private void Update()
        {
            var admins = repository.Get<AdminEntity>();
            users.AddRange(admins.Select(admin => new UserAccount { Name = admin.Email, Password = admin.Password, Role = "Admin" }));

            var clients = repository.Get<ClientEntity>();
            users.AddRange(clients.Select(client => new UserAccount { Name = client.Email, Password = client.Password, Role = "Client" }));

            users.Add(new UserAccount { Name = "BigAdmin", Password = "Admin", Role = "Admin" });
        }

        public UserAccount? GetUserByName(string name)
        {
            users.Clear();
            Update();
            var user = users.FirstOrDefault(s => s.Name == name);
            if (user == null)
            {
                var anon =new  AnonUserAccaunt();
                anon.Name = name;
                users.Add(anon);
                return anon;
            }
            return user;
        }

    }
}
