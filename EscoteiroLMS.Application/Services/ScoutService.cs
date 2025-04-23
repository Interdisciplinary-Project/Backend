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

        public async Task<ScoutDto> Create(ScoutDto scoutDto)
        {
            var scoutEntity = _mapper.Map<Scout>(scoutDto);
            var result = await _scoutRepository.Create(scoutEntity);
            return _mapper.Map<ScoutDto>(result);
        }

        public async Task<IEnumerable<ScoutDto>> GetScout()
        {
            var scoutsEntity = await _scoutRepository.GetScouts();
            return _mapper.Map<IEnumerable<ScoutDto>>(scoutsEntity);
        }

        public async Task<ScoutDto> GetById(int? id)
        {
            var scoutEntity = await _scoutRepository.GetById(id);
            return _mapper.Map<ScoutDto>(scoutEntity);
        }

        public async Task Remove(int? id)
        {
            var scoutEntity = await _scoutRepository.GetById(id);
            await _scoutRepository.Remove(scoutEntity);
        }

        public async Task<ScoutDto> Update(ScoutDto scoutDto)
        {
            var scoutEntity = _mapper.Map<Scout>(scoutDto);
            await _scoutRepository.Update(scoutEntity);

            var updatedEntity = await _scoutRepository.GetById(scoutEntity.Id);
            return _mapper.Map<ScoutDto>(updatedEntity);
        }
    }
}
