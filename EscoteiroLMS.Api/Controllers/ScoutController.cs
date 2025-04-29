using AutoMapper;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Application.Services;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EscoteiroLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoutController : ControllerBase
    {
        private readonly IScoutService _scoutService;
        private readonly IMapper _mapper;

        public ScoutController(IScoutService scoutService, IMapper mapper)
        {
            _scoutService = scoutService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetScouts")]
        [ResponseCache(CacheProfileName = "Default30")]
        public async Task<ActionResult<IEnumerable<ScoutDto>>> Get()
        {
            var scouts = await _scoutService.GetScout();
            if (scouts == null)
            {
                return NotFound("Scout not found");
            }
            return Ok(scouts);
        }

        [HttpGet("{id}", Name = "GetScoutById")]
        public async Task<ActionResult<ScoutDto>> GetById(int id)
        {
            var scout = await _scoutService.GetById(id);
            if (scout == null)
                return NotFound();

            var scoutDto = _mapper.Map<ScoutDto>(scout);
            return Ok(scoutDto);
        }

        [HttpPost(Name = "CreateScout")]
        public async Task<ActionResult> Post([FromBody] ScoutDto scoutDto)
        {
            if (scoutDto == null)
            {
                return BadRequest("Invalid Data");
            }

            var scoutEntity = _mapper.Map<Scout>(scoutDto);
            var scout = await _scoutService.Create(scoutEntity);
            var createdDto = _mapper.Map<ScoutDto>(scout);

            return new CreatedAtRouteResult("GetScoutById",
                new { id = scout.Id }, createdDto);
        }
        [HttpPut(Name = "UpdateScout")]
        public async Task<ActionResult> Put(int id, [FromBody] ScoutDto scoutDto)
        {
            if (scoutDto == null)
            {
                return BadRequest("Update Invalid Data");
            }

            var scoutEntity = _mapper.Map<Scout>(scoutDto);
            await _scoutService.Update(scoutEntity);
            return Ok(scoutDto);
        }

        [HttpDelete("{id:int}", Name = "DeleteScout")]
        public async Task<ActionResult<ScoutDto>> Delete(int id)
        {
            var scout = await _scoutService.GetById(id);
            if (scout == null)
            {
                return BadRequest("Remove Invalid Data");
            }

            await _scoutService.Remove(id);
            return Ok(scout);
        }
    }
}
