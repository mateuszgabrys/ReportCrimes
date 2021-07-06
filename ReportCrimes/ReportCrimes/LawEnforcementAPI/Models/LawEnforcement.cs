using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LawEnforcementAPI.Models
{
    public class LawEnforcement
    {
        [Key]
        public int LawEnforcementId { get; set; }
        public string RankOfLawEnforcement { get; set; }
        public IEnumerable<CrimeEvent> CrimeEvents { get; set; }
    }
}
