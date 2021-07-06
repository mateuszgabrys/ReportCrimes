using ReportCrimes.Web.Models;
using System.Threading.Tasks;

namespace ReportCrimes.Web.Services.IServices
{
    public interface ICrimeService
    {
        Task<T> GetAll<T>();
        Task<T> GetSingle<T>(string id);
        Task<T> Create<T>(CrimeEventDto crimeEventDto);
        Task<T> Update<T>(CrimeEventDto crimeEventDto);
        Task<T> Delete<T>(string id);
        Task<T> GetAllEnv<T>();
    }
}
