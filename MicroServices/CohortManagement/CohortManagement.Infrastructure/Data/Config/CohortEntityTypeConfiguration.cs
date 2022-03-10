using CohortManagement.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CohortManagement.Infrastructure.Data.Config
{
    public class CohortEntityTypeConfiguration : IEntityTypeConfiguration<Cohort>
    {
        public void Configure(EntityTypeBuilder<Cohort> builder)
        {
            builder.Ignore(p => p.TraineeCount);
            builder.Property(p => p.Coach)
                .IsUnicode(false)
                   .HasMaxLength(30);
            builder.Property(p => p.CohortCode)
                   .IsUnicode(false)
                   .HasMaxLength(10);
            builder.Property(p => p.TechnologyStack)
                   .IsUnicode(false)
                   .HasMaxLength(10);
        }
    }
}
