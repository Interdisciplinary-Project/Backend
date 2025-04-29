using AutoMapper;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EscoteiroLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("{id:int}", Name = "GetResponsible")]
        public async Task<ActionResult<ResponsibleDto>> GetById(int id)
        {
            var responsible = await _responsibleService.GetById(id);
            if (responsible == null)
                return NotFound();

            var responsibleDto = _mapper.Map<ResponsibleDto>(responsible);
            return Ok(responsibleDto);
        }

        [HttpPost(Name = "CreateResponsible")]
        public async Task<ActionResult> Post([FromBody] ResponsibleDto responsibleDto)
        {
            if (responsibleDto == null)
            {
                return BadRequest("Invalid Data");
            }

            var responsibleEntity = _mapper.Map<Responsible>(responsibleDto);
            var responsible = await _responsibleService.Create(responsibleEntity);
            var createdDto = _mapper.Map<ResponsibleDto>(responsible);

            return new CreatedAtRouteResult("GetResponsible", new { id = responsible.Id }, createdDto);
        }

        [HttpPut(Name = "UpdateResponsible")]
        public async Task<ActionResult> Put(int id, [FromBody] ResponsibleDto responsibleDto)
        {
            if (responsibleDto == null)
            {
                return BadRequest("Update Invalid Data");
            }

            var responsibleEntity = _mapper.Map<Responsible>(responsibleDto);
            await _responsibleService.Update(responsibleEntity);
            return Ok(responsibleDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteResponsible")]
        public async Task<ActionResult<ResponsibleDto>> Delete(int id)
        {
            var responsible = await _responsibleService.GetById(id);
            if (responsible == null)
            {
                return BadRequest("Remove Invalid Data");
            }

            await _responsibleService.Remove(id);
            return Ok(responsible);
        }
    }
}
