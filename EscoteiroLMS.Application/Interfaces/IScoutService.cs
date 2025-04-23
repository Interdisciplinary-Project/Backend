using EscoteiroLMS.Communication.Dto;

namespace EscoteiroLMS.Application.Interfaces
{
    public interface IScoutService
    {
        Task<IEnumerable<ScoutDto>> GetScout();
        Task<ScoutDto> GetById(int? id);
        Task<ScoutDto> Create(ScoutDto scoutDto);
        Task<ScoutDto> Update(ScoutDto scoutDto);
        Task Remove(int? id);
    }
}
