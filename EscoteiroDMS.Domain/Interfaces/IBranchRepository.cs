using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Domain.Interfaces
{
    public interface IBranchRepository
    {
        Task<Branch> GetById(int? id);
        Task<Branch> Create(Branch branchDto);
        Task<Branch> Update(Branch branchDto);
        Task<Branch> Remove(int id);

    }
}
