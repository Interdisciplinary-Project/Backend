using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Application.Interfaces
{
    public interface IResponsibleService
    {
        Task<IEnumerable<ResponsibleDto>> GetResponsibles();
        Task<ResponsibleDto> GetById(int? id);
        Task<ResponsibleDto> Create(ResponsibleDto responsibleDto);
        Task Update(ResponsibleDto responsibleDto);
        Task Remove(int? id);
    }
}
