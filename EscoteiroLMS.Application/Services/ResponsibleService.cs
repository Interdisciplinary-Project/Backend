using AutoMapper;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscoteiroLMS.Application.Services
{
    public class ResponsibleService : IResponsibleService
    {
        private readonly IResponsibleRepository _responsibleRepository;
        private readonly IMapper _mapper;

        public ResponsibleService(IResponsibleRepository responsibleRepository, IMapper mapper)
        {
            _responsibleRepository = responsibleRepository;
            _mapper = mapper;
        }

        public async Task<ResponsibleDto> Create(ResponsibleDto responsibleDto)
        {
            var responsibleEntity = _mapper.Map<Responsible>(responsibleDto);
            var result = await _responsibleRepository.Create(responsibleEntity);
            return _mapper.Map<ResponsibleDto>(result);
        }

        public async Task<IEnumerable<ResponsibleDto>> GetResponsibles()
        {
            var responsiblesEntity = await _responsibleRepository.GetResponsibles();
            return _mapper.Map<IEnumerable<ResponsibleDto>>(responsiblesEntity);
        }

        public async Task<ResponsibleDto> GetById(int? id)
        {
            var responsibleEntity = await _responsibleRepository.GetById(id);
            return _mapper.Map<ResponsibleDto>(responsibleEntity);
        }

        public async Task Remove(int? id)
        {
            var responsibleEntity = await _responsibleRepository.GetById(id);
            await _responsibleRepository.Remove(responsibleEntity);
        }

        public async Task Update(ResponsibleDto responsibleDto)
        {
            var responsibleEntity = _mapper.Map<Responsible>(responsibleDto);
            await _responsibleRepository.Update(responsibleEntity);
        }
    }
}
