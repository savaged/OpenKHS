﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenKHS.Data;

namespace OpenKHS.Data.Migrations
{
    [DbContext(typeof(OpenKHSContext))]
    partial class OpenKHSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("OpenKHS.Models.Assignee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Attendant")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AwaySpeaker")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CbsConductor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CbsReader")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ClmmChairman")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Gems")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LacParts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Platform")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PmChairman")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Prayer")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PublicSpeaker")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RovingMic")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SchoolBibleReading")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SchoolDemo1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SchoolDemo2")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SchoolDemo3")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SchoolDemoHouseholder")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SchoolMainHallOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SchoolTalk")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SecondSchoolCounselor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SecondSchoolOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SoundDesk")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Treasures")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WtConductor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WtReader")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Assignees");
                });

            modelBuilder.Entity("OpenKHS.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssigneeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssignmentTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("AssignmentTypeId");

                    b.ToTable("Assignments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Assignment");
                });

            modelBuilder.Entity("OpenKHS.Models.AssignmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AssignmentTypes");
                });

            modelBuilder.Entity("OpenKHS.Models.ClmmSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendant1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendant2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendant3Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendant4Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CbsConductorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CbsReaderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChairmanId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClosingPrayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Demo1HouseholderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Demo1PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Demo2HouseholderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Demo2PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Demo3HouseholderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Demo3PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GemsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LacPart1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LacPart2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LacPart3Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OpeningPrayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlatformId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RovingMic1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RovingMic2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchoolBibleReadingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchoolTalkId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoundDeskId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TreasuresId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WeekStarting")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Attendant1Id");

                    b.HasIndex("Attendant2Id");

                    b.HasIndex("Attendant3Id");

                    b.HasIndex("Attendant4Id");

                    b.HasIndex("CbsConductorId");

                    b.HasIndex("CbsReaderId");

                    b.HasIndex("ChairmanId");

                    b.HasIndex("ClosingPrayerId");

                    b.HasIndex("Demo1HouseholderId");

                    b.HasIndex("Demo1PublisherId");

                    b.HasIndex("Demo2HouseholderId");

                    b.HasIndex("Demo2PublisherId");

                    b.HasIndex("Demo3HouseholderId");

                    b.HasIndex("Demo3PublisherId");

                    b.HasIndex("GemsId");

                    b.HasIndex("LacPart1Id");

                    b.HasIndex("LacPart2Id");

                    b.HasIndex("LacPart3Id");

                    b.HasIndex("OpeningPrayerId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("RovingMic1Id");

                    b.HasIndex("RovingMic2Id");

                    b.HasIndex("SchoolBibleReadingId");

                    b.HasIndex("SchoolTalkId");

                    b.HasIndex("SoundDeskId");

                    b.HasIndex("TreasuresId");

                    b.ToTable("ClmmSchedules");
                });

            modelBuilder.Entity("OpenKHS.Models.PmSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendant1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendant2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendant3Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attendant4Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChairmanId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClosingPrayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OpeningPrayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlatformId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RovingMic1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RovingMic2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoundDeskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Speaker")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("WeekStarting")
                        .HasColumnType("TEXT");

                    b.Property<int>("WtConductorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WtReaderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Attendant1Id");

                    b.HasIndex("Attendant2Id");

                    b.HasIndex("Attendant3Id");

                    b.HasIndex("Attendant4Id");

                    b.HasIndex("ChairmanId");

                    b.HasIndex("ClosingPrayerId");

                    b.HasIndex("OpeningPrayerId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("RovingMic1Id");

                    b.HasIndex("RovingMic2Id");

                    b.HasIndex("SoundDeskId");

                    b.HasIndex("WtConductorId");

                    b.HasIndex("WtReaderId");

                    b.ToTable("PmSchedules");
                });

            modelBuilder.Entity("OpenKHS.Models.UnavailablePeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AssigneeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.ToTable("UnavailablePeriods");
                });

            modelBuilder.Entity("OpenKHS.Models.ClmmAssignment", b =>
                {
                    b.HasBaseType("OpenKHS.Models.Assignment");

                    b.HasDiscriminator().HasValue("ClmmAssignment");
                });

            modelBuilder.Entity("OpenKHS.Models.PmAssignment", b =>
                {
                    b.HasBaseType("OpenKHS.Models.Assignment");

                    b.HasDiscriminator().HasValue("PmAssignment");
                });

            modelBuilder.Entity("OpenKHS.Models.Assignment", b =>
                {
                    b.HasOne("OpenKHS.Models.Assignee", "Assignee")
                        .WithMany("Assignments")
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.AssignmentType", "AssignmentType")
                        .WithMany()
                        .HasForeignKey("AssignmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpenKHS.Models.ClmmSchedule", b =>
                {
                    b.HasOne("OpenKHS.Models.Assignment", "Attendant1")
                        .WithMany()
                        .HasForeignKey("Attendant1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Attendant2")
                        .WithMany()
                        .HasForeignKey("Attendant2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Attendant3")
                        .WithMany()
                        .HasForeignKey("Attendant3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Attendant4")
                        .WithMany()
                        .HasForeignKey("Attendant4Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "CbsConductor")
                        .WithMany()
                        .HasForeignKey("CbsConductorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "CbsReader")
                        .WithMany()
                        .HasForeignKey("CbsReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Chairman")
                        .WithMany()
                        .HasForeignKey("ChairmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "ClosingPrayer")
                        .WithMany()
                        .HasForeignKey("ClosingPrayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Demo1Householder")
                        .WithMany()
                        .HasForeignKey("Demo1HouseholderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Demo1Publisher")
                        .WithMany()
                        .HasForeignKey("Demo1PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Demo2Householder")
                        .WithMany()
                        .HasForeignKey("Demo2HouseholderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Demo2Publisher")
                        .WithMany()
                        .HasForeignKey("Demo2PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Demo3Householder")
                        .WithMany()
                        .HasForeignKey("Demo3HouseholderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Demo3Publisher")
                        .WithMany()
                        .HasForeignKey("Demo3PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Gems")
                        .WithMany()
                        .HasForeignKey("GemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "LacPart1")
                        .WithMany()
                        .HasForeignKey("LacPart1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "LacPart2")
                        .WithMany()
                        .HasForeignKey("LacPart2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "LacPart3")
                        .WithMany()
                        .HasForeignKey("LacPart3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "OpeningPrayer")
                        .WithMany()
                        .HasForeignKey("OpeningPrayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "RovingMic1")
                        .WithMany()
                        .HasForeignKey("RovingMic1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "RovingMic2")
                        .WithMany()
                        .HasForeignKey("RovingMic2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "SchoolBibleReading")
                        .WithMany()
                        .HasForeignKey("SchoolBibleReadingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "SchoolTalk")
                        .WithMany()
                        .HasForeignKey("SchoolTalkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "SoundDesk")
                        .WithMany()
                        .HasForeignKey("SoundDeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Treasures")
                        .WithMany()
                        .HasForeignKey("TreasuresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpenKHS.Models.PmSchedule", b =>
                {
                    b.HasOne("OpenKHS.Models.Assignment", "Attendant1")
                        .WithMany()
                        .HasForeignKey("Attendant1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Attendant2")
                        .WithMany()
                        .HasForeignKey("Attendant2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Attendant3")
                        .WithMany()
                        .HasForeignKey("Attendant3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Attendant4")
                        .WithMany()
                        .HasForeignKey("Attendant4Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Chairman")
                        .WithMany()
                        .HasForeignKey("ChairmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "ClosingPrayer")
                        .WithMany()
                        .HasForeignKey("ClosingPrayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "OpeningPrayer")
                        .WithMany()
                        .HasForeignKey("OpeningPrayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "RovingMic1")
                        .WithMany()
                        .HasForeignKey("RovingMic1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "RovingMic2")
                        .WithMany()
                        .HasForeignKey("RovingMic2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "SoundDesk")
                        .WithMany()
                        .HasForeignKey("SoundDeskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "WtConductor")
                        .WithMany()
                        .HasForeignKey("WtConductorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenKHS.Models.Assignment", "WtReader")
                        .WithMany()
                        .HasForeignKey("WtReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpenKHS.Models.UnavailablePeriod", b =>
                {
                    b.HasOne("OpenKHS.Models.Assignee", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
