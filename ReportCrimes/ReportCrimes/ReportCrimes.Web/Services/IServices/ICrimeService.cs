using ReportCrimes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportCrimes.Web.Services.IServices
{
    public interface ICrimeService
    {
        Task<T> GetAll<T>();
        Task<T> GetSingle<T>(int id);
        Task<T> Create<T>(CrimeEventDto crimeEventDto);
        Task<T> Update<T>(CrimeEventDto crimeEventDto);
        Task<T> Delete<T>(int id);
    }
}
