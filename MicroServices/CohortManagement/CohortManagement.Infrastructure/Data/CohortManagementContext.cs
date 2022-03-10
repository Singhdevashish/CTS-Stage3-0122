using CohortManagement.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CohortManagement.Infrastructure.Data
{
    public class CohortManagementContext : DbContext
    {
        public CohortManagementContext(DbContextOptions<CohortManagementContext> options) : base(options)
        {
        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CohortManagementContext).Assembly);
        }
    }
}
