﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SessionManagement.Infrastructure.Data;

namespace SessionManagement.Infrastructure.Data.Migrations
{
    [DbContext(typeof(SessionManagementContext))]
    partial class SessionManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SessionManagement.Core.Entitites.Cohort", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("CohortCode")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Cohorts");
                });

            modelBuilder.Entity("SessionManagement.Core.Entitites.Trainer", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("SessionManagement.Core.Entitites.TrainingSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CohortId")
                        .HasColumnType("bigint");

                    b.Property<long>("TrainerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CohortId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainingSessions");
                });

            modelBuilder.Entity("SessionManagement.Core.Entitites.TrainingSession", b =>
                {
                    b.HasOne("SessionManagement.Core.Entitites.Cohort", null)
                        .WithMany()
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SessionManagement.Core.Entitites.Trainer", null)
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SessionManagement.Core.ValueObjects.TrainingDates", "Dates", b1 =>
                        {
                            b1.Property<long>("TrainingSessionId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("FromDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("ToDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("TrainingSessionId");

                            b1.ToTable("TrainingSessions");

                            b1.WithOwner()
                                .HasForeignKey("TrainingSessionId");
                        });

                    b.OwnsOne("SessionManagement.Core.ValueObjects.TrainingLocation", "Location", b1 =>
                        {
                            b1.Property<long>("TrainingSessionId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<bool>("IsVirtual")
                                .HasColumnType("bit");

                            b1.Property<string>("Location")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TrainingSessionId");

                            b1.ToTable("TrainingSessions");

                            b1.WithOwner()
                                .HasForeignKey("TrainingSessionId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
