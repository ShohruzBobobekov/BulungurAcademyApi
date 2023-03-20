﻿// <auto-generated />
using System;
using BulungurAcademy.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BulungurAcademy.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BulungurAcademy.Domain.Entities.ExamApplicant", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uuid");

                    b.Property<int?>("AttendanceStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("FirstSubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool?>("IsArrived")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsPayed")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("SecondSubjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId", "ExamId");

                    b.HasIndex("ExamId");

                    b.HasIndex("FirstSubjectId");

                    b.HasIndex("SecondSubjectId");

                    b.ToTable("ExamApplicant");
                });

            modelBuilder.Entity("BulungurAcademy.Domain.Entities.Exams.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ExamName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("BulungurAcademy.Domain.Entities.Subjects.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("BulungurAcademy.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long?>("TelegramId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TelegramId")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ExamSubject", b =>
                {
                    b.Property<Guid>("ExamsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uuid");

                    b.HasKey("ExamsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("ExamSubject");
                });

            modelBuilder.Entity("BulungurAcademy.Domain.Entities.ExamApplicant", b =>
                {
                    b.HasOne("BulungurAcademy.Domain.Entities.Exams.Exam", "Exam")
                        .WithMany("ExamApplicants")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulungurAcademy.Domain.Entities.Subjects.Subject", "FirstSubject")
                        .WithMany()
                        .HasForeignKey("FirstSubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BulungurAcademy.Domain.Entities.Subjects.Subject", "SecondSubject")
                        .WithMany()
                        .HasForeignKey("SecondSubjectId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BulungurAcademy.Domain.Entities.Users.User", "User")
                        .WithMany("ExamApplicants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("FirstSubject");

                    b.Navigation("SecondSubject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExamSubject", b =>
                {
                    b.HasOne("BulungurAcademy.Domain.Entities.Exams.Exam", null)
                        .WithMany()
                        .HasForeignKey("ExamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulungurAcademy.Domain.Entities.Subjects.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BulungurAcademy.Domain.Entities.Exams.Exam", b =>
                {
                    b.Navigation("ExamApplicants");
                });

            modelBuilder.Entity("BulungurAcademy.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("ExamApplicants");
                });
#pragma warning restore 612, 618
        }
    }
}
