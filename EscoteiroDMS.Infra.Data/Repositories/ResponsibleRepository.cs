using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Interfaces;
using EscoteiroLMS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EscoteiroLMS.Infra.Data.Repositories
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        private ApplicationDBContext _responsibleContext;

        public ResponsibleRepository(ApplicationDBContext context)
        {
            _responsibleContext = context;
        }

        public async Task<Responsible> Create(Responsible responsible)
        {
            _responsibleContext.Add(responsible);
            await _responsibleContext.SaveChangesAsync();
            return responsible;
        }

        public async Task<Responsible> GetById(int id)
        {
            var responsible = await _responsibleContext.Responsibles.FindAsync(id);
            return responsible;
        }

        public async Task<IEnumerable<Responsible>> GetResponsibles()
        {
            return await _responsibleContext.Responsibles.OrderBy(r => r.Id).ToListAsync();
        }

        public async Task<Responsible> Update(Responsible responsible)
        {
            _responsibleContext.Update(responsible);
            await _responsibleContext.SaveChangesAsync();
            return responsible;
        }

        public async Task<Responsible> Remove(Responsible responsible)
        {
            _responsibleContext.Remove(responsible);
            await _responsibleContext.SaveChangesAsync();
            return responsible;
        }
    }
}
