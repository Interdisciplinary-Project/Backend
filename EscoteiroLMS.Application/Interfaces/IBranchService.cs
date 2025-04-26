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
        Task<Branch> Create(Branch branch);
        Task<Branch> GetById(int id);
        Task<Branch> Update(Branch branch);
        Task<Branch> Remove(int id);
    }
}
