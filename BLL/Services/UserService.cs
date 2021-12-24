using DAL.Models;
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

        public async Task<User> CreateAsync(User user)
        {
            return await _usersRepository.CreateAsync(user);
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

        public async Task<bool> UpdateAsync(User user)
        {
            return await _usersRepository.UpdateAsync(user);
        }
    }
}
