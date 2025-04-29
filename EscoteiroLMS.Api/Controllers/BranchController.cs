using AutoMapper;
using EscoteiroLMS.Application.Interfaces;
using EscoteiroLMS.Application.Services;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EscoteiroLMS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public BranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetBranchById")]
        public async Task<ActionResult<BranchDto>> GetById(int id)
        {
            var branch = await _branchService.GetById(id);
            if (branch == null)
                return NotFound();

            var branchDto = _mapper.Map<BranchDto>(branch);
            return Ok(branchDto);
        }

        [HttpPost(Name = "Createbranch")]
        public async Task<ActionResult> Post([FromBody] BranchDto branchDto)
        {
            if (branchDto == null)
            {
                return BadRequest("Invalid Data");
            }

            var branchEntity = _mapper.Map<Branch>(branchDto);
            var branch = await _branchService.Create(branchEntity);
            var createdDto = _mapper.Map<BranchDto>(branch);

            return new CreatedAtRouteResult("GetbranchById",
                new { id = branch.Id }, createdDto);
        }
        [HttpPut(Name = "Updatebranch")]
        public async Task<ActionResult> Put(int id, [FromBody] BranchDto branchDto)
        {
            if (branchDto == null)
            {
                return BadRequest("Update Invalid Data");
            }

            var branchEntity = _mapper.Map<Branch>(branchDto);
            await _branchService.Update(branchEntity);
            return Ok(branchDto);
        }

        [HttpDelete("{id:int}", Name = "Deletebranch")]
        public async Task<ActionResult<BranchDto>> Delete(int id)
        {
            var branch = await _branchService.GetById(id);
            if (branch == null)
            {
                return BadRequest("Remove Invalid Data");
            }

            await _branchService.Remove(id);
            return Ok(branch);
        }
    }
}
