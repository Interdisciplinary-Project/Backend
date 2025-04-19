using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscoteiroLMS.Application.Interfaces
{
    public interface IScoutService
    {
        Task<IEnumerable<ScoutDto>> GetScout();
        Task<ScoutDto> GetById(int? id);
        Task<Scout> Create(Scout scoutDto);
        Task<ScoutDto> Update(ScoutDto scoutDto);
        Task Remove(int id);
    }
}
