using AutoMapper;
using LawEnforcementAPI.DbContexts;
using LawEnforcementAPI.Models;
using LawEnforcementAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcementAPI.Repository
{
    public class LawEnforcementRepository : ILawEnforcementRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public LawEnforcementRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<LawEnforcementDto> CreateUpdate(LawEnforcementDto lawEnforcementDto)
        {
            LawEnforcement lawEnforcement = _mapper.Map<LawEnforcementDto, LawEnforcement>(lawEnforcementDto);
            if(lawEnforcement.LawEnforcementId > 0)
            {
                _db.LawEnforcements.Update(lawEnforcement);
            }
            else
            {
                _db.LawEnforcements.Add(lawEnforcement);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<LawEnforcement, LawEnforcementDto>(lawEnforcement);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                LawEnforcement lawEnforcement = await _db.LawEnforcements.FirstOrDefaultAsync(u => u.LawEnforcementId == id);
                if(lawEnforcement == null)
                {
                    return false;
                }
                _db.LawEnforcements.Remove(lawEnforcement);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<LawEnforcementDto>> GetAll()
        {
            IEnumerable<LawEnforcement> list = await _db.LawEnforcements.ToListAsync();
            return _mapper.Map<List<LawEnforcementDto>>(list);
        }

        public async Task<LawEnforcementDto> GetSingle(int id)
        {
            LawEnforcement lawEnforcement = await _db.LawEnforcements.Where(x=> x.LawEnforcementId == id).FirstOrDefaultAsync();
            return _mapper.Map<LawEnforcementDto>(lawEnforcement);
        }
    }
}
