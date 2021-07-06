using LawEnforcementAPI.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawEnforcementAPI.Repository
{
    public interface ILawEnforcementRepository
    {
        Task<IEnumerable<LawEnforcementDto>> GetAll();
        Task<LawEnforcementDto> GetSingle(int id);
        Task<LawEnforcementDto> CreateUpdate(LawEnforcementDto lawEnforcementDto);
        Task<bool> Delete(int id);
    }
}
