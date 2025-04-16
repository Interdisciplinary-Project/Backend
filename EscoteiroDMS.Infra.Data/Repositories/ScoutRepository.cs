using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EscoteiroLMS.Infra.Data.Repositories
{
    public class ScoutRepository
    {
        private ApplicationDBContext _scoutContext;

        public ScoutRepository(ApplicationDBContext context)
        {
            _scoutContext = context;
        }

        public async Task<Scout> Create(Scout scout)
        {
            _scoutContext.Add(scout);
            await _scoutContext.SaveChangesAsync();
            return scout;
        }

        public async Task<Scout> GetById(int? id)
        {
            var scout = await _scoutContext.Scouts.FindAsync(id);
            return scout;
        }

        public async Task<IEnumerable<Scout>> GetScouts()
        {
            return await _scoutContext.Scouts.OrderBy(s => s.Id).ToListAsync();
        }

        public async Task<Scout> Update(Scout scout)
        {
            _scoutContext.Update(scout);
            await _scoutContext.SaveChangesAsync();
            return scout;
        }

        public async Task<Scout> Remove(Scout scout)
        {
            _scoutContext.Remove(scout);
            await _scoutContext.SaveChangesAsync();
            return scout;
        }
    }
}
