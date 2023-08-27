using System;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetUserById(string id)
        {
            return await applicationDbContext.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await applicationDbContext.Users.ToListAsync();
        }

        public async Task<User> CreateUser(string name, string surename)
        {
            var newUser = new User
            {
                Name = name,
                Surname = surename
            };

            var addedUser = applicationDbContext.Users.Add(newUser);
            await applicationDbContext.SaveChangesAsync();

            return addedUser.Entity;
        }
        
        public async Task UpdateUser(string id,string name, string surename)
        {
            var userToUpdate = applicationDbContext.Users.Where(x => x.Id == id).SingleOrDefault();

            if(userToUpdate == null)
            {
                return;
            }

            userToUpdate.Name = name;
            userToUpdate.Surname = surename;

            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(string id)
        {
            var userToDelete = applicationDbContext.Users.SingleOrDefault(x => x.Id == id);

            if(userToDelete is null)
            {
                return;
            }

            applicationDbContext.Users.Remove(userToDelete);
            await applicationDbContext.SaveChangesAsync();
        }

    }
}

