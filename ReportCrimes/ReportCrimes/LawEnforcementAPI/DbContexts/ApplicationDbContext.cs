using LawEnforcementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcementAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CrimeEvent> CrimeEvents { get; set; }
        public DbSet<LawEnforcement> LawEnforcements { get; set; }

    }
}
