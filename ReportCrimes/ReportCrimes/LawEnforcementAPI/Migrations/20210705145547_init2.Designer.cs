﻿// <auto-generated />
using System;
using LawEnforcementAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LawEnforcementAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210705145547_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LawEnforcementAPI.Models.CrimeEvent", b =>
                {
                    b.Property<int>("CrimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LawEnforcementId")
                        .HasColumnType("int");

                    b.Property<string>("PlaceOfEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportingPersonEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfEvent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrimeId");

                    b.HasIndex("LawEnforcementId");

                    b.ToTable("CrimeEvents");
                });

            modelBuilder.Entity("LawEnforcementAPI.Models.LawEnforcement", b =>
                {
                    b.Property<int>("LawEnforcementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RankOfLawEnforcement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LawEnforcementId");

                    b.ToTable("LawEnforcements");

                    b.HasData(
                        new
                        {
                            LawEnforcementId = 1,
                            RankOfLawEnforcement = "Police"
                        },
                        new
                        {
                            LawEnforcementId = 2,
                            RankOfLawEnforcement = "Officer"
                        },
                        new
                        {
                            LawEnforcementId = 3,
                            RankOfLawEnforcement = "Sherif"
                        });
                });

            modelBuilder.Entity("LawEnforcementAPI.Models.CrimeEvent", b =>
                {
                    b.HasOne("LawEnforcementAPI.Models.LawEnforcement", "LawEnforcement")
                        .WithMany("CrimeEvents")
                        .HasForeignKey("LawEnforcementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LawEnforcement");
                });

            modelBuilder.Entity("LawEnforcementAPI.Models.LawEnforcement", b =>
                {
                    b.Navigation("CrimeEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
