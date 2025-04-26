using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Application.Interfaces
{
    public interface IResponsibleService
    {
        Task<IEnumerable<Responsible>> GetResponsibles();
        Task<Responsible> Create(Responsible responsible);
        Task<Responsible> GetById(int id);
        Task<Responsible> Update(Responsible responsible);
        Task<Responsible> Remove(int id);
    }
}
