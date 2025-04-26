using AutoMapper;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EscoteiroLMS.Api.Controllers
{
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleService _responsibleService;
        private readonly IMapper _mapper;

        public ResponsibleController(IResponsibleService responsibleService, IMapper mapper)
        {
            _responsibleService = responsibleService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetResponsibles")]
        [ResponseCache(CacheProfileName = "Default30")]
        public async Task<ActionResult<IEnumerable<ResponsibleDto>>> Get()
        {
            var responsibles = await _responsibleService.GetResponsibles();
            if (responsibles == null)
            {
                return NotFound("Responsibles not found");
            }
            return Ok(responsibles);
        }

        [HttpPost(Name = "Create Responsible")]
        public async Task<ActionResult> Post([FromBody] ResponsibleDto responsibleDto)
        {
            if (responsibleDto == null)
            {
                return BadRequest("Invalid Data");
            }

            var responsibleEntity = _mapper.Map<Responsible>(responsibleDto);

            var responsible = await _responsibleService.Create(responsibleEntity);

            return new CreatedAtRouteResult("GetResponsible",
                new { id = responsible.Id }, responsibleDto);
        }
    }
}
