using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class KnowledgeFormRepository : IKnowledgeFormRepository
    {
        private readonly SystemContext _Context;

        public KnowledgeFormRepository(SystemContext Context)
        {
            _Context = Context;
        }

        public async Task<KnowledgeForm> CreateAsync(KnowledgeForm knowledgeForm)
        {
            _Context.KnowledgeForms.Add(knowledgeForm);

            await _Context.SaveChangesAsync();

            return knowledgeForm;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _Context.KnowledgeForms.FindAsync(id);
            var result = item != null;
            if (result)
            {
                _Context.Entry(item).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<KnowledgeForm>> GetAllAsync(bool isDeleted = false)
        {
            return await _Context.KnowledgeForms.ToListAsync();
        }

        public async Task<KnowledgeForm> GetByIdAsync(int id)
        {
            return await _Context.KnowledgeForms.Where(x =>
                x.KnowledgeFormId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(KnowledgeForm knowledgeForm)
        {
            var item = _Context.KnowledgeForms.Attach(knowledgeForm);
            _Context.Entry(knowledgeForm).State = EntityState.Modified;
            await _Context.SaveChangesAsync();

            return item != null;
        }
    }
}
