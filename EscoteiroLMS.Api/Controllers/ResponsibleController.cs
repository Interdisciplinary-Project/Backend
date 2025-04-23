using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Interfaces;
using EscoteiroLMS.Application.Interfaces;

namespace EscoteiroLMS.Api.Controllers
{
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleService _responsibleService;

        public ResponsibleController(IResponsibleService responsibleService)
        {
            _responsibleService = responsibleService;
        }

        [HttpGet(Name = "GetResponsibles")]
        [ResponseCache(CacheProfileName = "Default30")]
        public async Task<ActionResult<IEnumerable<ResponsibleDto>>> Get()
        {
            var responsibles = await _responsibleService.GetResponsibles();
            if(responsibles == null)
            {
                return NotFound("Responsibles not found");
            }
            return Ok(responsibles);
        }
    }
}
