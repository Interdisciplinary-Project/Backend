using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Domain.Interfaces
{
    public interface IScoutRepository
    {
        Task<IEnumerable<Scout>> GetScouts();
        Task<Scout> GetById(int? id);
        Task<Scout> Create(Scout scout);
        Task<Scout> Update(Scout scout);
        Task<Scout> Remove(Scout scout);
    }
}
