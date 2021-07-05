using AutoMapper;
using CrimeEventAPI.Models;
using CrimeEventAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
