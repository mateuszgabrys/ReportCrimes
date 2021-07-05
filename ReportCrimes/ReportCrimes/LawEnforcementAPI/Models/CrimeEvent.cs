using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcementAPI.Models
{
    public class CrimeEvent
    {
        [Key]
        public int CrimeId { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string TypeOfEvent { get; set; }
        public string Description { get; set; }
        public string PlaceOfEvent { get; set; }
        public string ReportingPersonEmail { get; set; }
        public string Status { get; set; }
        public int LawEnforcementId { get; set; }
        [ForeignKey("LawEnforcementId")]
        public virtual LawEnforcement LawEnforcement { get; set; }
    }
}
