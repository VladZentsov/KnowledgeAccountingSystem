using DAL.Models;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> CreateManagerAsync(User user);
        Task<User> CreateAdminAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<bool> UpdateAsync(User user);
        Task<bool> UpdateRoleAsync(int id, Role role);
        Task<bool> DeleteAsync(int id);
        Task<string> GetRoleAsync(User user);
        Task<List<User>> GetUsersWithRoleAsync(string role);
    }
}
