using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscoteiroLMS.Application.Interfaces
{
    public interface IResponsibleService
    {
        Task<IEnumerable<ResponsibleDto>> GetResponsibles();
        Task<ResponsibleDto> GetById(int? id);
        Task<Responsible> Create(Responsible responsibleDto);
        Task<ResponsibleDto> Update(ResponsibleDto responsibleDto);
        Task Remove(int id);
    }
}
