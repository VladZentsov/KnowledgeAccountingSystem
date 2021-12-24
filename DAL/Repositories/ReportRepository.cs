using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly SystemContext _Context;

        public ReportRepository(SystemContext Context)
        {
            _Context = Context;
        }

        public async Task<Report> CreateAsync(Report report)
        {
            _Context.Reports.Add(report);

            await _Context.SaveChangesAsync();

            return report;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _Context.Reports.FindAsync(id);
            var result = item != null;
            if (result)
            {
                _Context.Entry(item).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Report>> GetAllAsync(bool isDeleted = false)
        {
            return await _Context.Reports.ToListAsync();
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await _Context.Reports.Where(x =>
                x.ReportId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Report report)
        {
            var item = _Context.Reports.Attach(report);
            _Context.Entry(report).State = EntityState.Modified;
            await _Context.SaveChangesAsync();

            return item != null;
        }
    }
}
