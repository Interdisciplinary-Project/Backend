using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Interfaces;

namespace EscoteiroLMS.Api.Controllers
{
    public class ResponsibleController : Controller
    {
        private readonly IResponsibleService responsibleService;
    }
}
