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
    public class ReportService : IReportService
    { 
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Report> CreateAsync(Report report)
        {
            return await _reportRepository.CreateAsync(report);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _reportRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _reportRepository.GetAllAsync();
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await _reportRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Report report)
        {
            return await _reportRepository.UpdateAsync(report);
        }
    }
}
