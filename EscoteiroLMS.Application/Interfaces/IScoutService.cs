using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Application.Interfaces
{
    public interface IScoutService
    {
        Task<IEnumerable<Scout>> GetScout();
        Task<Scout> GetById(int? id);
        Task<Scout> Create(Scout scout);
        Task<Scout> Update(Scout scout);
        Task Remove(int? id);
    }
}
