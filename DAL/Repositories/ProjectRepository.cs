using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SystemContext _Context;

        public ProjectRepository(SystemContext Context)
        {
            _Context = Context;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            _Context.Projects.Add(project);

            await _Context.SaveChangesAsync();

            return project;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _Context.Projects.FindAsync(id);
            var result = item != null;
            if (result)
            {
                _Context.Entry(item).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Project>> GetAllAsync(bool isDeleted = false)
        {
            return await _Context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _Context.Projects.Where(x =>
                x.ProjectId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Project project)
        {
            var item = _Context.Projects.Attach(project);
            _Context.Entry(project).State = EntityState.Modified;
            await _Context.SaveChangesAsync();

            return item != null;
        }
    }
}
