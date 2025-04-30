using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Interfaces;
using System.Threading.Tasks;

namespace EscoteiroLMS.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<Branch> Create(Branch branch)
        {
            return await _branchRepository.Create(branch);
        }

        public async Task<Branch> GetById(int id)
        {
            return await _branchRepository.GetById(id);
        }

        public async Task<IEnumerable<Branch>> GetBranches()
        {
            return await _branchRepository.GetBranches();
        }

        public async Task<Branch> Remove(int id)
        {
            var branch = await _branchRepository.GetById(id);
            if (branch != null)
            {
                await _branchRepository.Remove(branch);
            }
            return branch;
        }

        public async Task<Branch> Update(Branch branch)
        {
            return await _branchRepository.Update(branch);
        }
    }
}
