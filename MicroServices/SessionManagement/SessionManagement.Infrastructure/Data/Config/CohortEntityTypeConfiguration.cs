using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Infrastructure.Data.Config
{
    public class CohortEntityTypeConfiguration : IEntityTypeConfiguration<Cohort>
    {
        public void Configure(EntityTypeBuilder<Cohort> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.CohortCode).IsUnicode(false).HasMaxLength(30);
        }
    }
}
