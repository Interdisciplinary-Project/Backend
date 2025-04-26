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

        public async Task<IEnumerable<Responsible>> GetResponsibles()
        {
            return await _responsibleRepository.GetResponsibles();
        }

        public async Task<Responsible> Create(Responsible responsible)
        {
            var result = await _responsibleRepository.Create(responsible);
            return result;
        }

        public async Task<Responsible> GetById(int id)
        {
            return await _responsibleRepository.GetById(id);
        }

        public async Task<Responsible> Update(Responsible responsible)
        {
            await _responsibleRepository.Update(responsible);
            return await _responsibleRepository.GetById(responsible.Id);
        }

        public async Task<Responsible> Remove(int id)
        {
            var responsibleEntity = await _responsibleRepository.GetById(id);
            if (responsibleEntity != null)
            {
                await _responsibleRepository.Remove(responsibleEntity);
            }
            return responsibleEntity;
        }
    }
}
