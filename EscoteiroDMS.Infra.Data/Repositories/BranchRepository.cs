using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Interfaces;
using EscoteiroLMS.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EscoteiroLMS.Infra.Data.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private ApplicationDBContext _branchContext;

        public BranchRepository(ApplicationDBContext context)
        {
            _branchContext = context;
        }

        public async Task<BranchDto> Create(BranchDto branch)
        {
            _branchContext.Add(branch);
            await _branchContext.SaveChangesAsync();
            return branch;
        }

        public async Task<BranchDto> GetById(int? id)
        {
            var branch = await _branchContext.Branches.FindAsync(id);
            return branch;
        }

        public async Task<BranchDto> Update(BranchDto branch)
        {
            _branchContext.Update(branch);
            await _branchContext.SaveChangesAsync();
            return branch;
        }

        public async Task<BranchDto> Remove(BranchDto branch)
        {
            _branchContext.Remove(branch);
            await _branchContext.SaveChangesAsync();
            return branch;
        }
    }
}