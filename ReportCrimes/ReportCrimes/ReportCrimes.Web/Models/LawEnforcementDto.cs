using System.Collections.Generic;

namespace ReportCrimes.Web.Models
{
    public class LawEnforcementDto
    {
        public int LawEnforcementId { get; set; }
        public string RankOfLawEnforcement { get; set; }
        public IEnumerable<CrimeEventDto> CrimeEvents { get; set; }
    }
}
