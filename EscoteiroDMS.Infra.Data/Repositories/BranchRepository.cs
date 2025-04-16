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

        public async Task<Branch> Create(Branch branch)
        {
            _branchContext.Add(branch);
            await _branchContext.SaveChangesAsync();
            return branch;
        }

        public async Task<Branch> GetById(int? id)
        {
            var branch = await _branchContext.Branches.FindAsync(id);
            return branch;
        }

        public async Task<Branch> Update(Branch branch)
        {
            _branchContext.Update(branch);
            await _branchContext.SaveChangesAsync();
            return branch;
        }

        public async Task<Branch> Remove(Branch branch)
        {
            _branchContext.Remove(branch);
            await _branchContext.SaveChangesAsync();
            return branch;
        }
    }
}