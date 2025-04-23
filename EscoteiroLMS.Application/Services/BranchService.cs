using AutoMapper;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Communication.Dto;
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

        public async Task<BranchDto> Create(BranchDto branchDto)
        {
            var branchesEntity = _mapper.Map<Branch>(branchDto);
            var result = await _branchRepository.Create(branchesEntity);
            return _mapper.Map<BranchDto>(result);
        }

        public async Task<BranchDto> GetById(int? id)
        {
            var branchEntity = await _branchRepository.GetById(id);
            return _mapper.Map<BranchDto>(branchEntity);
        }

        public async Task Remove(int? id)
        {
            var branchEntity = await _branchRepository.GetById(id);
            await _branchRepository.Remove(branchEntity);
        }

        public async Task<BranchDto> Update(BranchDto branchDto)
        {
            var branchEntity = _mapper.Map<Branch>(branchDto);
            await _branchRepository.Update(branchEntity);

            var updatedEntity = await _branchRepository.GetById(branchEntity.Id);
            return _mapper.Map<BranchDto>(updatedEntity);
        }
    }
}
