﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrimeEventAPI.Models.Dto
{
    public class CrimeEventDto
    {
        public string CrimeId { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string TypeOfEvent { get; set; }
        public string Description { get; set; }
        public string PlaceOfEvent { get; set; }
        public string ReportingPersonEmail { get; set; }
        public string Status { get; set; }
        public int LawEnforcementId { get; set; }
    }
}
