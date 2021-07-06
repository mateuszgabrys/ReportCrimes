using System.Collections.Generic;


namespace CrimeEventAPI.Models
{
    public class LawEnforcement
    {
        public int LawEnforcementId { get; set; }
        public string RankOfLawEnforcement { get; set; }
        public IEnumerable<CrimeEvent> CrimeEvents { get; set; }
    }
}
