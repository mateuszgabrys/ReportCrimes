using ReportCrimes.Web.Models;
using System;
using System.Threading.Tasks;

namespace ReportCrimes.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
