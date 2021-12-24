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
    public class KnowledgeFormService : IKnowledgeFormService
    {
        private readonly IKnowledgeFormRepository _knowledgeFormRepository;

        public KnowledgeFormService(IKnowledgeFormRepository knowledgeForm)
        {
            _knowledgeFormRepository = knowledgeForm;
        }

        public async Task<KnowledgeForm> CreateAsync(KnowledgeForm knowledgeForm)
        {
            return await _knowledgeFormRepository.CreateAsync(knowledgeForm);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _knowledgeFormRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<KnowledgeForm>> GetAllAsync()
        {
            return await _knowledgeFormRepository.GetAllAsync();
        }

        public async Task<KnowledgeForm> GetByIdAsync(int id)
        {
            return await _knowledgeFormRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(KnowledgeForm knowledgeForm)
        {
            return await _knowledgeFormRepository.UpdateAsync(knowledgeForm);
        }
    }
}
