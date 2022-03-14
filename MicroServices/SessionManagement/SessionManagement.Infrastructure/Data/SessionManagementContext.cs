using Microsoft.EntityFrameworkCore;
using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Infrastructure.Data
{
    public class SessionManagementContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }

        public SessionManagementContext( DbContextOptions<SessionManagementContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SessionManagementContext).Assembly);
        }
    }
}
