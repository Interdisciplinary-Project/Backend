using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Domain.Interfaces
{
    public interface IResponsibleRepository
    {
        Task<IEnumerable<Responsible>> GetResponsibles();
        Task<Responsible> GetById(int? id);
        Task<Responsible> Create(Responsible responsible);
        Task<Responsible> Update(Responsible responsible);
        Task<Responsible> Remove(Responsible responsible);

    }
}
