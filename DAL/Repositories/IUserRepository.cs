using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> CreateManagerAsync(User user);
        Task<User> CreateAdminAsync(User user);
        Task<IEnumerable<User>> GetAllAsync(bool isDeleted = false);
        Task<User> GetByIdAsync(int id);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<string> GetRoleAsync(User user);
    }
}
