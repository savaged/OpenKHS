﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenKHS.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    ClmmChairman = table.Column<bool>(nullable: false),
                    SecondSchoolCounselor = table.Column<bool>(nullable: false),
                    Treasures = table.Column<bool>(nullable: false),
                    Gems = table.Column<bool>(nullable: false),
                    SchoolBibleReading = table.Column<bool>(nullable: false),
                    SchoolDemo1 = table.Column<bool>(nullable: false),
                    SchoolDemo2 = table.Column<bool>(nullable: false),
                    SchoolDemo3 = table.Column<bool>(nullable: false),
                    SchoolTalk = table.Column<bool>(nullable: false),
                    SchoolDemoHouseholder = table.Column<bool>(nullable: false),
                    SecondSchoolOnly = table.Column<bool>(nullable: false),
                    SchoolMainHallOnly = table.Column<bool>(nullable: false),
                    LacParts = table.Column<bool>(nullable: false),
                    CbsConductor = table.Column<bool>(nullable: false),
                    CbsReader = table.Column<bool>(nullable: false),
                    PublicSpeaker = table.Column<bool>(nullable: false),
                    AwaySpeaker = table.Column<bool>(nullable: false),
                    PmChairman = table.Column<bool>(nullable: false),
                    Prayer = table.Column<bool>(nullable: false),
                    WtReader = table.Column<bool>(nullable: false),
                    Attendant = table.Column<bool>(nullable: false),
                    SoundDesk = table.Column<bool>(nullable: false),
                    Platform = table.Column<bool>(nullable: false),
                    RovingMic = table.Column<bool>(nullable: false),
                    WtConductor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnavailablePeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssigneeId = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnavailablePeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnavailablePeriods_Assignees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssigneeId = table.Column<int>(nullable: false),
                    AssignmentTypeId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignment_Assignees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_AssignmentTypes_AssignmentTypeId",
                        column: x => x.AssignmentTypeId,
                        principalTable: "AssignmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClmmSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeekStarting = table.Column<DateTime>(nullable: false),
                    Attendant1Id = table.Column<int>(nullable: false),
                    Attendant2Id = table.Column<int>(nullable: false),
                    Attendant3Id = table.Column<int>(nullable: false),
                    Attendant4Id = table.Column<int>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false),
                    SoundDeskId = table.Column<int>(nullable: false),
                    RovingMic1Id = table.Column<int>(nullable: false),
                    RovingMic2Id = table.Column<int>(nullable: false),
                    OpeningPrayerId = table.Column<int>(nullable: false),
                    ClosingPrayerId = table.Column<int>(nullable: false),
                    ChairmanId = table.Column<int>(nullable: false),
                    TreasuresId = table.Column<int>(nullable: false),
                    GemsId = table.Column<int>(nullable: false),
                    SchoolBibleReadingId = table.Column<int>(nullable: false),
                    Demo1PublisherId = table.Column<int>(nullable: false),
                    Demo1HouseholderId = table.Column<int>(nullable: false),
                    Demo2PublisherId = table.Column<int>(nullable: false),
                    Demo2HouseholderId = table.Column<int>(nullable: false),
                    Demo3PublisherId = table.Column<int>(nullable: false),
                    Demo3HouseholderId = table.Column<int>(nullable: false),
                    SchoolTalkId = table.Column<int>(nullable: false),
                    LacPart1Id = table.Column<int>(nullable: false),
                    LacPart2Id = table.Column<int>(nullable: false),
                    LacPart3Id = table.Column<int>(nullable: false),
                    CbsConductorId = table.Column<int>(nullable: false),
                    CbsReaderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClmmSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Attendant1Id",
                        column: x => x.Attendant1Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Attendant2Id",
                        column: x => x.Attendant2Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Attendant3Id",
                        column: x => x.Attendant3Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Attendant4Id",
                        column: x => x.Attendant4Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_CbsConductorId",
                        column: x => x.CbsConductorId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_CbsReaderId",
                        column: x => x.CbsReaderId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_ChairmanId",
                        column: x => x.ChairmanId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_ClosingPrayerId",
                        column: x => x.ClosingPrayerId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Demo1HouseholderId",
                        column: x => x.Demo1HouseholderId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Demo1PublisherId",
                        column: x => x.Demo1PublisherId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Demo2HouseholderId",
                        column: x => x.Demo2HouseholderId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Demo2PublisherId",
                        column: x => x.Demo2PublisherId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Demo3HouseholderId",
                        column: x => x.Demo3HouseholderId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_Demo3PublisherId",
                        column: x => x.Demo3PublisherId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_GemsId",
                        column: x => x.GemsId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_LacPart1Id",
                        column: x => x.LacPart1Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_LacPart2Id",
                        column: x => x.LacPart2Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_LacPart3Id",
                        column: x => x.LacPart3Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_OpeningPrayerId",
                        column: x => x.OpeningPrayerId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_RovingMic1Id",
                        column: x => x.RovingMic1Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_RovingMic2Id",
                        column: x => x.RovingMic2Id,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_SchoolBibleReadingId",
                        column: x => x.SchoolBibleReadingId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_SchoolTalkId",
                        column: x => x.SchoolTalkId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_SoundDeskId",
                        column: x => x.SoundDeskId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignment_TreasuresId",
                        column: x => x.TreasuresId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssigneeId",
                table: "Assignment",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignmentTypeId",
                table: "Assignment",
                column: "AssignmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Attendant1Id",
                table: "ClmmSchedules",
                column: "Attendant1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Attendant2Id",
                table: "ClmmSchedules",
                column: "Attendant2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Attendant3Id",
                table: "ClmmSchedules",
                column: "Attendant3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Attendant4Id",
                table: "ClmmSchedules",
                column: "Attendant4Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_CbsConductorId",
                table: "ClmmSchedules",
                column: "CbsConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_CbsReaderId",
                table: "ClmmSchedules",
                column: "CbsReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_ChairmanId",
                table: "ClmmSchedules",
                column: "ChairmanId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_ClosingPrayerId",
                table: "ClmmSchedules",
                column: "ClosingPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo1HouseholderId",
                table: "ClmmSchedules",
                column: "Demo1HouseholderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo1PublisherId",
                table: "ClmmSchedules",
                column: "Demo1PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo2HouseholderId",
                table: "ClmmSchedules",
                column: "Demo2HouseholderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo2PublisherId",
                table: "ClmmSchedules",
                column: "Demo2PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo3HouseholderId",
                table: "ClmmSchedules",
                column: "Demo3HouseholderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo3PublisherId",
                table: "ClmmSchedules",
                column: "Demo3PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_GemsId",
                table: "ClmmSchedules",
                column: "GemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_LacPart1Id",
                table: "ClmmSchedules",
                column: "LacPart1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_LacPart2Id",
                table: "ClmmSchedules",
                column: "LacPart2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_LacPart3Id",
                table: "ClmmSchedules",
                column: "LacPart3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_OpeningPrayerId",
                table: "ClmmSchedules",
                column: "OpeningPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_PlatformId",
                table: "ClmmSchedules",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_RovingMic1Id",
                table: "ClmmSchedules",
                column: "RovingMic1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_RovingMic2Id",
                table: "ClmmSchedules",
                column: "RovingMic2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_SchoolBibleReadingId",
                table: "ClmmSchedules",
                column: "SchoolBibleReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_SchoolTalkId",
                table: "ClmmSchedules",
                column: "SchoolTalkId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_SoundDeskId",
                table: "ClmmSchedules",
                column: "SoundDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_TreasuresId",
                table: "ClmmSchedules",
                column: "TreasuresId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailablePeriods_AssigneeId",
                table: "UnavailablePeriods",
                column: "AssigneeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClmmSchedules");

            migrationBuilder.DropTable(
                name: "UnavailablePeriods");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Assignees");

            migrationBuilder.DropTable(
                name: "AssignmentTypes");
        }
    }
}
