using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly SystemContext _Context;

        public UserRepository(SystemContext Context)
        {
            _Context = Context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _Context.Users.Add(user);

            await _Context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _Context.Users.FindAsync(id);
            var result = item != null;
            if (result)
            {
                _Context.Entry(item).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<User>> GetAllAsync(bool isDeleted = false)
        {
            return await _Context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _Context.Users.Where(x =>
                x.UserId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var item = _Context.Users.Attach(user);
            _Context.Entry(user).State = EntityState.Modified;
            await _Context.SaveChangesAsync();

            return item != null;
        }
        public async Task CreateUserRolesAsync()
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var identityResult = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Manager"
            });
            var identityResult2 = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "User"
            });

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = await userManager.FindAsync("TestUserName", "TestPassword");

            await userManager.AddToRoleAsync(user.Id, "Manager");
        }
    }
}
