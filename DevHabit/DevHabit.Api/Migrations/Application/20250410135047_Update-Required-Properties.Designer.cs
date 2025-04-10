﻿// <auto-generated />
using System;
using DevHabit.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DevHabit.Api.Migrations.Application
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250410135047_Update-Required-Properties")]
    partial class UpdateRequiredProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dev-habit")
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DevHabit.Api.Entities.Habit", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at_utc");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean")
                        .HasColumnName("is_archived");

                    b.Property<DateTime?>("LastCompletedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_completed_at_utc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<DateTime?>("UpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at_utc");

                    b.HasKey("Id")
                        .HasName("pk_habits");

                    b.ToTable("habits", "dev-habit");
                });

            modelBuilder.Entity("DevHabit.Api.Entities.Habit", b =>
                {
                    b.OwnsOne("DevHabit.Api.Entities.Frequency", "Frequency", b1 =>
                        {
                            b1.Property<string>("HabitId")
                                .HasColumnType("character varying(500)")
                                .HasColumnName("id");

                            b1.Property<int>("TimesPerPeriod")
                                .HasColumnType("integer")
                                .HasColumnName("frequency_times_per_period");

                            b1.Property<int>("Type")
                                .HasColumnType("integer")
                                .HasColumnName("frequency_type");

                            b1.HasKey("HabitId");

                            b1.ToTable("habits", "dev-habit");

                            b1.WithOwner()
                                .HasForeignKey("HabitId")
                                .HasConstraintName("fk_habits_habits_id");
                        });

                    b.OwnsOne("DevHabit.Api.Entities.MileStone", "Milestone", b1 =>
                        {
                            b1.Property<string>("HabitId")
                                .HasColumnType("character varying(500)")
                                .HasColumnName("id");

                            b1.Property<int>("Current")
                                .HasColumnType("integer")
                                .HasColumnName("milestone_current");

                            b1.Property<int>("Target")
                                .HasColumnType("integer")
                                .HasColumnName("milestone_target");

                            b1.HasKey("HabitId");

                            b1.ToTable("habits", "dev-habit");

                            b1.WithOwner()
                                .HasForeignKey("HabitId")
                                .HasConstraintName("fk_habits_habits_id");
                        });

                    b.OwnsOne("DevHabit.Api.Entities.Target", "Target", b1 =>
                        {
                            b1.Property<string>("HabitId")
                                .HasColumnType("character varying(500)")
                                .HasColumnName("id");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("target_unit");

                            b1.Property<int>("Value")
                                .HasColumnType("integer")
                                .HasColumnName("target_value");

                            b1.HasKey("HabitId");

                            b1.ToTable("habits", "dev-habit");

                            b1.WithOwner()
                                .HasForeignKey("HabitId")
                                .HasConstraintName("fk_habits_habits_id");
                        });

                    b.Navigation("Frequency")
                        .IsRequired();

                    b.Navigation("Milestone");

                    b.Navigation("Target")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
