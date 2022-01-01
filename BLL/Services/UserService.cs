using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Enums;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _usersRepository;

        public UserService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _usersRepository.CreateUserAsync(user);
        }
        public async Task<User> CreateManagerAsync(User user)
        {
            return await _usersRepository.CreateManagerAsync(user);
        }
        public async Task<User> CreateAdminAsync(User user)
        {
            return await _usersRepository.CreateAdminAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _usersRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usersRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _usersRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(User newuser)
        {
            var user = await GetByIdAsync(newuser.UserId);
            if (user.ProjectId != null)
                user.ProjectId = newuser.ProjectId;
            if (user.KnowledgeFormId != null)
                user.KnowledgeFormId = newuser.KnowledgeFormId;
            if (user.Pass != null)
                user.Pass = newuser.Pass;
            if (user.Login != null)
                user.Login = newuser.Login;
            user.Role = newuser.Role;
            return await _usersRepository.UpdateAsync(user);
        }

        public async Task<bool> UpdateRoleAsync(int id, Role role)
        {
            var user = await GetByIdAsync(id);
            user.Role = role;
            return await _usersRepository.UpdateAsync(user);
        }

        public async Task<string> GetRoleAsync(User user)
        {
           return await _usersRepository.GetRoleAsync(user);

        }

        public async Task<List<User>> GetUsersWithRoleAsync(string role)
        {
            List<User> resultUsers = new List<User>();
            foreach (var user in await _usersRepository.GetAllAsync())
            {
                if(await _usersRepository.GetRoleAsync(user) == role)
                    resultUsers.Add(user);
            }
            return resultUsers;
        }

    }
}
