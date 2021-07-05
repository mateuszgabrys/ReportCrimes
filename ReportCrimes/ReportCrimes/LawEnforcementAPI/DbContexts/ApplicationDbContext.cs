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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LawEnforcement>().HasData(new LawEnforcement
            {
                LawEnforcementId = 1,
                RankOfLawEnforcement = "Police"
            });
            modelBuilder.Entity<LawEnforcement>().HasData(new LawEnforcement
            {
                LawEnforcementId = 2,
                RankOfLawEnforcement = "Officer"
            });
            modelBuilder.Entity<LawEnforcement>().HasData(new LawEnforcement
            {
                LawEnforcementId = 3,
                RankOfLawEnforcement = "Sherif"
            });
        }

    }
}
