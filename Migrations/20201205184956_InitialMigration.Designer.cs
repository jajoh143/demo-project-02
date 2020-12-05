﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using demo_project_01_stream.Models.Data;

namespace demo_project_01_stream.Migrations
{
    [DbContext(typeof(MonsterDataContext))]
    [Migration("20201205184956_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("demo_project_01_stream.Models.Data.Alignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Alignment");
                });

            modelBuilder.Entity("demo_project_01_stream.Models.Data.Monster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AlignmentID")
                        .HasColumnType("int");

                    b.Property<int>("ArmorClass")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AlignmentID");

                    b.ToTable("Monster");
                });

            modelBuilder.Entity("demo_project_01_stream.Models.Data.Monster", b =>
                {
                    b.HasOne("demo_project_01_stream.Models.Data.Alignment", "Alignment")
                        .WithMany("Monsters")
                        .HasForeignKey("AlignmentID");

                    b.Navigation("Alignment");
                });

            modelBuilder.Entity("demo_project_01_stream.Models.Data.Alignment", b =>
                {
                    b.Navigation("Monsters");
                });
#pragma warning restore 612, 618
        }
    }
}
