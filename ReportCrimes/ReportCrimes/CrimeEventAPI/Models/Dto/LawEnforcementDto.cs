using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeEventAPI.Models.Dto
{
    public class LawEnforcementDto
    {
        public int LawEnforcementId { get; set; }
        public string RankOfLawEnforcement { get; set; }
        public IEnumerable<CrimeEventDto> CrimeEvents { get; set; }
    }
}
