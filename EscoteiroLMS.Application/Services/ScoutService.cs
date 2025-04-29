using AutoMapper;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Interfaces;

namespace EscoteiroLMS.Application.Services
{
    public class ScoutService : IScoutService
    {
        private readonly IScoutRepository _scoutRepository;
        private readonly IMapper _mapper;

        public ScoutService(IScoutRepository scoutRepository, IMapper mapper)
        {
            _scoutRepository = scoutRepository;
            _mapper = mapper;
        }

        public async Task<Scout> Create(Scout Scout)
        {
            var scoutEntity = _mapper.Map<Scout>(Scout);
            var result = await _scoutRepository.Create(scoutEntity);
            return _mapper.Map<Scout>(result);
        }

        public async Task<IEnumerable<Scout>> GetScout()
        {
            var scoutsEntity = await _scoutRepository.GetScouts();
            return _mapper.Map<IEnumerable<Scout>>(scoutsEntity);
        }

        public async Task<Scout> GetById(int? id)
        {
            var scoutEntity = await _scoutRepository.GetById(id);
            return _mapper.Map<Scout>(scoutEntity);
        }

        public async Task Remove(int? id)
        {
            var scoutEntity = await _scoutRepository.GetById(id);
            await _scoutRepository.Remove(scoutEntity);
        }

        public async Task<Scout> Update(Scout Scout)
        {
            var scoutEntity = _mapper.Map<Scout>(Scout);
            await _scoutRepository.Update(scoutEntity);

            var updatedEntity = await _scoutRepository.GetById(scoutEntity.Id);
            return _mapper.Map<Scout>(updatedEntity);
        }
    }
}
