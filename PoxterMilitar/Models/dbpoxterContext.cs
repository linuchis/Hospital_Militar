﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PoxterMilitar.Models;

public partial class dbpoxterContext : DbContext
{
    public dbpoxterContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(Settings.Default.ConnectionString, new MySqlServerVersion(new Version(Settings.Default.VersionMajor, Settings.Default.VersionMinor, Settings.Default.VersionBuild)));
        }
    }


    public dbpoxterContext(DbContextOptions<dbpoxterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<patients_poxter> patients_poxter { get; set; }
    public virtual DbSet<surveys_patients> surveys_patients { get; set; }
    public virtual DbSet<users_poxter> users_poxter { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<patients_poxter>(entity =>
        {
            entity.HasKey(e => e.id_p).HasName("patients_poxter_pkey");

            entity.ToTable(tb => tb.HasComment("usuarios pacientes"));

            entity.Property(e => e.id_p).ValueGeneratedNever();

            entity.Property(e => e.gender_p)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.lastname_p)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.name_p)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.amp_first)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.amp_sec)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(e => e.Surveys)
                  .WithOne(e => e.Patient)
                  .HasForeignKey(e => e.id_p)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_survey_patients_patients_poxter");
        });


        modelBuilder.Entity<surveys_patients>(entity =>
        {
            entity.HasKey(e => e.id_survey).HasName("surveys_patients_pkey");

            entity.Property(e => e.id_survey)
                .ValueGeneratedOnAdd()
                .HasColumnType("bigint");

            entity.Property(e => e.hour_survey)
                .IsRequired()
                .HasColumnType("datetime");

            entity.Property(e => e._1_survey)
                .HasMaxLength(255)
                .HasColumnName("1_survey");

            entity.Property(e => e._2_survey)
                .HasMaxLength(255)
                .HasColumnName("2_survey");

            entity.Property(e => e._3_survey)
                .HasMaxLength(255)
                .HasColumnName("3_survey");

            entity.Property(e => e._4_survey)
                .HasMaxLength(255)
                .HasColumnName("4_survey");

            entity.Property(e => e._5_survey)
                .HasMaxLength(255)
                .HasColumnName("5_survey");

            entity.Property(e => e._6_survey)
                .HasMaxLength(255)
                .HasColumnName("6_survey");

            entity.Property(e => e._7_survey)
                .HasMaxLength(255)
                .HasColumnName("7_survey");

            entity.Property(e => e._8_survey)
                .HasMaxLength(255)
                .HasColumnName("8_survey");

            entity.Property(e => e._9_survey)
                .HasMaxLength(255)
                .HasColumnName("9_survey");

            entity.Property(e => e._10_survey)
                .HasMaxLength(255)
                .HasColumnName("10_survey");

            entity.Property(e => e.id_p)
                .IsRequired()
                .HasColumnName("id_p")
                .HasColumnType("bigint");

            entity.HasOne(e => e.Patient)
                  .WithMany(p => p.Surveys)
                  .HasForeignKey(e => e.id_p)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_survey_patients_patients_poxter");
        });


        modelBuilder.Entity<users_poxter>(entity =>
        {
            entity.HasKey(e => e.id_u).HasName("users_pkey");

            entity.ToTable(tb => tb.HasComment("datos de usuarios"));

            entity.Property(e => e.id_u).ValueGeneratedNever();
            entity.Property(e => e.area_u)
                .IsRequired()
                .HasMaxLength(100);


            entity.Property(e => e.email_u)
                .IsRequired()
                .HasMaxLength(100);


            entity.Property(e => e.lastname_u).HasMaxLength(100);


            entity.Property(e => e.name_u)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.telephone_u)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.password_u)
                .IsRequired()
                .HasColumnName("password_u") // Mapeo a la columna password_u
                .HasMaxLength(255);

            entity.Property(e => e.username_u)
                .IsRequired()
                .HasColumnName("username_u") // Mapeo a la columna username_u
                .HasMaxLength(50);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}