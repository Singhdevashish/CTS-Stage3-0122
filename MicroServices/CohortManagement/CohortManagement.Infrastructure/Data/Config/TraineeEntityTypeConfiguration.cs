using System;
using System.Collections.Generic;
using System.Text;
using CohortManagement.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CohortManagement.Infrastructure.Data.Config
{
    public class TraineeEntityTypeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                   .ValueGeneratedNever();
            builder.Property(p => p.Name)
                   .IsUnicode(false)
                   .HasMaxLength(30);
            builder.Property(p => p.DateOfJoining)
                   .HasColumnType("date");
            builder.Property(p => p.Email)
                   .IsUnicode(false)
                   .HasMaxLength(50);

        }
    }
}
