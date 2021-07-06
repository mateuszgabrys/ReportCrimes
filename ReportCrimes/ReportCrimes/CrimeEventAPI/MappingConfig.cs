using AutoMapper;
using CrimeEventAPI.Models;
using CrimeEventAPI.Models.Dto;

namespace CrimeEventAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<LawEnforcement, LawEnforcementDto>();
                config.CreateMap<LawEnforcementDto, LawEnforcement>();
                config.CreateMap<CrimeEvent, CrimeEventDto>();
                config.CreateMap<CrimeEventDto, CrimeEvent>();
            });
            return mappingConfig;
        }
    }
}
