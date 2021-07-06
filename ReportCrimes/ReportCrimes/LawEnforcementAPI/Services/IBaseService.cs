using LawEnforcementAPI.Models;
using LawEnforcementAPI.Models.Dto;
using System.Threading.Tasks;

namespace LawEnforcementAPI.Services
{
    public interface IBaseService
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
