using System;
using MiniShopApi.Database.Entitites;

namespace MiniShopApi.Database.Repositories
{
	public class UserRepository
	{
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
		{
            this.applicationDbContext = applicationDbContext;
        }

        public User GetUserById(string id)
        {
            return applicationDbContext.Users.Where(x => x.Id == id).SingleOrDefault();
        }

        public void CreateUser(string name, string surename)
        {
            var newUser = new User
            {
                Name = name,
                Surname = surename
            };

            applicationDbContext.Users.Add(newUser);
            applicationDbContext.SaveChanges();
        }
        
        public void UpdateUser(string id,string name, string surename)
        {
            var userToUpdate = applicationDbContext.Users.Where(x => x.Id == id).SingleOrDefault();

            if(userToUpdate == null)
            {
                return;
            }

            userToUpdate.Name = name;
            userToUpdate.Surname = surename;

            applicationDbContext.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var userToDelete = applicationDbContext.Users.SingleOrDefault(x => x.Id == id);

            if(userToDelete is null)
            {
                return;
            }

            applicationDbContext.Users.Remove(userToDelete);
            applicationDbContext.SaveChanges();
        }

    }
}

