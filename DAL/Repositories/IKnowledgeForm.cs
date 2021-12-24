using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IKnowledgeFormRepository
    {
        Task<KnowledgeForm> CreateAsync(KnowledgeForm knowledgeForm);
        Task<IEnumerable<KnowledgeForm>> GetAllAsync(bool isDeleted = false);
        Task<KnowledgeForm> GetByIdAsync(int id);
        Task<bool> UpdateAsync(KnowledgeForm knowledgeForm);
        Task<bool> DeleteAsync(int id);
    }
}
