using EscoteiroLMS.Communication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Application.Interfaces
{
    public interface IBranchService
    {
        Task<BranchDto> GetById(int? id);
        Task<BranchDto> Create(BranchDto branchDto);
        Task<BranchDto> Update(BranchDto branchDto);
        Task Remove(int? id);
    }
}
