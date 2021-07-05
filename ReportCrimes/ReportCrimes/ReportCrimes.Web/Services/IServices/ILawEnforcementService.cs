using ReportCrimes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportCrimes.Web.Services.IServices
{
    public interface ILawEnforcementService : IBaseService
    {
        Task<T> GetAll<T>();
        Task<T> GetSingle<T>(int id);
        Task<T> Create<T>(LawEnforcementDto lawEnforcementDto);
        Task<T> Update<T>(LawEnforcementDto lawEnforcementDto);
        Task<T> Delete<T>(int id);
    }
}
