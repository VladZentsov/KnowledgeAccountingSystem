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
        public async Task CreateUserRolesAsync(User user,string role)
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            if (!roleManager.RoleExists(role))
            {
                var identityResult = await roleManager.CreateAsync(new IdentityRole
                {
                    Name = role
                });
            }
            var identityUser = new IdentityUser()
            {
                UserName = user.Name,
            };
            IdentityResult result = await userManager.CreateAsync(identityUser, user.Pass);

            await userManager.AddToRoleAsync(identityUser.Id, role);

        }
        public async Task<User> CreateUserAsync(User user)
        {


            _Context.Users.Add(user);

            await _Context.SaveChangesAsync();

            await CreateUserRolesAsync(user, "User");

            return user;
        }
        public async Task<User> CreateManagerAsync(User user)
        {
            _Context.Users.Add(user);

            await _Context.SaveChangesAsync();

            await CreateUserRolesAsync(user, "Manager");

            return user;
        }
        public async Task<User> CreateAdminAsync(User user)
        {
            _Context.Users.Add(user);

            await _Context.SaveChangesAsync();

            await CreateUserRolesAsync(user, "Admin");

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
        public async Task<string> GetRoleAsync(User user)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var IdentityUser = await userManager.FindAsync(user.Name, user.Pass);
            string roleName = userManager.GetRoles(IdentityUser.Id).FirstOrDefault();
            return roleName;
        }
    }
}
