using AutoMapper;
using LawEnforcementAPI.Models;
using LawEnforcementAPI.Models.Dto;

namespace LawEnforcementAPI
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
