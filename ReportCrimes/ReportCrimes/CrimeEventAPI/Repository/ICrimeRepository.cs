using CrimeEventAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrimeEventAPI.Repository
{
    public interface ICrimeRepository
    {
        Task<IList<CrimeEvent>> GetAll();
        Task<CrimeEvent> GetSingle(Expression<Func<CrimeEvent, bool>> condition);
        Task<CrimeEvent> Add(CrimeEvent crime);
        Task Edit(CrimeEvent crime);
        Task Delete(string id);
    }
}
