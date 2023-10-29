﻿// <auto-generated />
using System;
using LigaManagerManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LigaManagerManagement.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LigaManagerManagement.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LigaManagerManagement.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBrith")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("LigaManagerManagement.Models.Liga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Absteiger")
                        .HasColumnType("int");

                    b.Property<string>("Aktiv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Erstaustragung")
                        .HasColumnType("datetime2");

                    b.Property<string>("Liganame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Verband")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ligen");
                });

            modelBuilder.Entity("LigaManagerManagement.Models.Saison", b =>
                {
                    b.Property<int>("SaisonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Abgeschlossen")
                        .HasColumnType("bit");

                    b.Property<bool>("Aktuell")
                        .HasColumnType("bit");

                    b.Property<int>("LigaID")
                        .HasColumnType("int");

                    b.Property<string>("Liganame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Saisonname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SaisonID");

                    b.ToTable("Saisonen");
                });

            modelBuilder.Entity("LigaManagerManagement.Models.Spieltag", b =>
                {
                    b.Property<int>("SpieltagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Saison")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpieltagNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tore1_Nr")
                        .HasColumnType("int");

                    b.Property<int>("Tore2_Nr")
                        .HasColumnType("int");

                    b.Property<string>("Verein1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Verein1_Nr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Verein2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Verein2_Nr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpieltagId");

                    b.ToTable("Spieltage");
                });

            modelBuilder.Entity("LigaManagerManagement.Models.Tabelle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gewonnen")
                        .HasColumnType("int");

                    b.Property<string>("Liga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Platz")
                        .HasColumnType("int");

                    b.Property<int>("Punkte")
                        .HasColumnType("int");

                    b.Property<int>("Spiele")
                        .HasColumnType("int");

                    b.Property<string>("Tab_Lig_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tab_Sai_Id")
                        .HasColumnType("int");

                    b.Property<int>("ToreMinus")
                        .HasColumnType("int");

                    b.Property<int>("TorePlus")
                        .HasColumnType("int");

                    b.Property<int>("Untentschieden")
                        .HasColumnType("int");

                    b.Property<string>("Verein")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VereinNr")
                        .HasColumnType("int");

                    b.Property<int>("Verloren")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tabellen");
                });

            modelBuilder.Entity("LigaManagerManagement.Models.Verein", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("VereinNr")
                        .HasColumnType("int");

                    b.Property<string>("Vereinsname1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vereinsname2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vereine");
                });

            modelBuilder.Entity("LigaManagerManagement.Models.Employee", b =>
                {
                    b.HasOne("LigaManagerManagement.Models.Department", "Department")
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
