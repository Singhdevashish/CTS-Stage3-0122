using CohortManagement.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;

namespace CohortManagement.Infrastructure.Data
{
    public class CohortManagementContext : DbContext
    {
        private readonly IMediator mediator;
        public CohortManagementContext(DbContextOptions<CohortManagementContext> options, IMediator mediator) : base(options)
        {
            this.mediator = mediator;
        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CohortManagementContext).Assembly);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int Rows = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var EntitiesWithEvents = ChangeTracker.Entries().Select(e => e.Entity as BaseEntity).ToArray();
            foreach (var entity in EntitiesWithEvents)
            {
                var events = entity.DomainEvents;
                foreach (var ev in events)
                    await mediator.Publish(ev).ConfigureAwait(false);
                entity.DomainEvents.Clear();
            }
            return Rows;
        }

    }
}
