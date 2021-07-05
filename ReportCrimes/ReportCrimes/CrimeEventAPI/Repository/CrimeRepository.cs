using CrimeEventAPI.DbContexts;
using CrimeEventAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrimeEventAPI.Repository
{
    public class CrimeRepository : ICrimeRepository
    {
        private readonly ApplicationDbContext _context;

        public CrimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CrimeEvent> Add(CrimeEvent crime)
        {
            await _context.Crimes.InsertOneAsync(crime);
            return crime;
        }

        public async Task Delete(string id)
        {
            await _context.Crimes.DeleteOneAsync(x => x.CrimeId == id);
        }

        public async Task Edit(CrimeEvent crime)
        {
            await _context.Crimes.ReplaceOneAsync(x => x.CrimeId == crime.CrimeId, crime);
        }

        public async Task<IList<CrimeEvent>> GetAll()
        {
            return await _context.Crimes.Find(e => true).ToListAsync();
        }

        public async Task<CrimeEvent> GetSingle(Expression<Func<CrimeEvent, bool>> condition)
        {
            return await _context.Crimes.Find(condition).FirstOrDefaultAsync();
        }
    }
}
