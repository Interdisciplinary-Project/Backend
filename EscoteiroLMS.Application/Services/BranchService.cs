using AutoMapper;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Interfaces;

namespace EscoteiroLMS.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<Branch> Create(Branch branch)
        {
            var result = await _branchRepository.Create(branch);
            return result;
        }

        public async Task<Branch> GetById(int id)
        {
            return await _branchRepository.GetById(id);
        }

        public async Task<Branch> Update(Branch branch)
        {
            await _branchRepository.Update(branch);
            return await _branchRepository.GetById(branch.Id.Value);
        }

        public async Task<Branch> Remove(int id)
        {
            var branchEntity = await _branchRepository.GetById(id);
            if (branchEntity != null)
            {
                await _branchRepository.Remove(branchEntity);
            }
            return branchEntity;
        }
    }
}
