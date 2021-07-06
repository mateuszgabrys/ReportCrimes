using System.Threading.Tasks;

namespace LawEnforcementAPI.Services
{
    public interface ILawEnforcementService
    {
        Task<T> GetAll<T>();
    }
}
