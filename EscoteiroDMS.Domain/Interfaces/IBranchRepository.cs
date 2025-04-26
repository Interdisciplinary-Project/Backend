using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Domain.Interfaces
{
    public interface IBranchRepository
    {
        Task<Branch> GetById(int id);
        Task<Branch> Create(Branch branch);
        Task<Branch> Update(Branch branch);
        Task Remove(Branch branch);
    }
}
