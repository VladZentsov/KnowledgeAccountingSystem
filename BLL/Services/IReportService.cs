using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IReportService
    {
        Task<Report> CreateAsync(Report report);
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Report report);
        Task<bool> DeleteAsync(int id);
    }
}
