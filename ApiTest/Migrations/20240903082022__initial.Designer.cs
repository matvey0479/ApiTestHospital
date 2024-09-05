﻿// <auto-generated />
using System;
using ApiTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiTest.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20240903082022__initial")]
    partial class _initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiTest.Domain.Entites.Cabinet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cabinets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8ac8d4f1-c991-47f4-bf46-978183c9142e"),
                            Number = 1
                        },
                        new
                        {
                            Id = new Guid("e6af2999-da92-4373-9416-d0ba65b78dbe"),
                            Number = 2
                        },
                        new
                        {
                            Id = new Guid("5bd4ee57-7742-4d78-8f1e-7580068cab3d"),
                            Number = 3
                        },
                        new
                        {
                            Id = new Guid("16e11064-6191-4071-be7d-75df802fad63"),
                            Number = 4
                        });
                });

            modelBuilder.Entity("ApiTest.Domain.Entites.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1ef530e9-c513-4350-850b-03d09febd21f"),
                            Number = 1
                        },
                        new
                        {
                            Id = new Guid("52f3a9bb-af35-4f50-83bb-b47d853a3699"),
                            Number = 2
                        },
                        new
                        {
                            Id = new Guid("5e718002-a929-4eb3-a1f8-fdc33c7d8820"),
                            Number = 3
                        });
                });

            modelBuilder.Entity("ApiTest.Domain.Entites.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CabinetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CabinetId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ApiTest.Domain.Entites.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ApiTest.Domain.Entites.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6f3ab9f-00ea-43e5-8fd7-698d1d3d211e"),
                            Name = "Терапевт"
                        },
                        new
                        {
                            Id = new Guid("d9fe1b73-849d-443a-800a-9f4ee502b38d"),
                            Name = "Хирург"
                        },
                        new
                        {
                            Id = new Guid("03fa870e-d2d9-4ae3-89ac-5eb2cff4254a"),
                            Name = "Стоматолог"
                        });
                });

            modelBuilder.Entity("ApiTest.Domain.Entites.Doctor", b =>
                {
                    b.HasOne("ApiTest.Domain.Entites.Cabinet", "Cabinet")
                        .WithMany()
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiTest.Domain.Entites.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("ApiTest.Domain.Entites.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");

                    b.Navigation("Department");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("ApiTest.Domain.Entites.Patient", b =>
                {
                    b.HasOne("ApiTest.Domain.Entites.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
