using AutoMapper;
using CrimeEventAPI.Exceptions;
using CrimeEventAPI.Models;
using CrimeEventAPI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrimeEventAPI.Services
{
    public class CrimeService : ICrimeService
    {
        private readonly ICrimeRepository _repository;
        private readonly IMapper _mapper;

        public CrimeService(ICrimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CrimeEvent> Add(CrimeEvent crimeDto)
        {
            var mappedEntry = _mapper.Map<CrimeEvent>(crimeDto);
            var entry = await _repository.Add(mappedEntry);
            return _mapper.Map<CrimeEvent>(entry);
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var crime = await _repository.GetSingle(x => x.CrimeId == id);
                await _repository.Delete(crime.CrimeId);
                if (crime == null)
                {
                    return true;
                }
                
                return false;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task Edit(CrimeEvent crimeDto)
        {
            var entryInDb = await _repository.GetSingle(x => x.CrimeId == crimeDto.CrimeId);
            if (entryInDb == null)
            {
                throw new NotFoundException("Not Found");
            }
            _mapper.Map(crimeDto, entryInDb);
            await _repository.Edit(entryInDb);
        }

        public async Task<IEnumerable<CrimeEvent>> GetAll()
        {
            var entriesInDb = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CrimeEvent>>(entriesInDb);
        }

        public async Task<CrimeEvent> Get(string id)
        {
            var entryInDb = await _repository.GetSingle(x => x.CrimeId == id);
            return _mapper.Map<CrimeEvent>(entryInDb);
        }
    }
}
