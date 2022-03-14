using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Infrastructure.Data.Config
{
    public class TrainerEntityTypeConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Name).IsUnicode(false).HasMaxLength(30);
        }
    }
}
