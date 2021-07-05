using CrimeEventAPI.Models;
using CrimeEventAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeEventAPI.Services
{
    public interface ICrimeService
    {
        Task<IEnumerable<CrimeEvent>> GetAll();
        Task<CrimeEvent> Get(string id);
        Task<CrimeEvent> Add(CrimeEvent crimeDto);
        Task Edit(CrimeEvent crimeDto);
        Task<bool> Delete(string id);
    }
}
