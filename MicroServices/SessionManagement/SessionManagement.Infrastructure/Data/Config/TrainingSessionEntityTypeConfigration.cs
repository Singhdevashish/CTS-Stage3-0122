using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SessionManagement.Core.Entitites;
using SessionManagement.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Infrastructure.Data.Config
{
    public class TrainingSessionEntityTypeConfigration : IEntityTypeConfiguration<TrainingSession>
    {
        public void Configure(EntityTypeBuilder<TrainingSession> builder)
        {
            builder.OwnsOne(p => p.Dates);
            builder.OwnsOne(p => p.Location);
            builder.HasOne<Cohort>().WithMany().HasForeignKey(p => p.CohortId);
            builder.HasOne<Trainer>().WithMany().HasForeignKey(p => p.TrainerId);
        }
    }
}
