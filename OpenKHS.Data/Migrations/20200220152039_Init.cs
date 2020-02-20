using System;
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
                    SchoolDemoAsst = table.Column<bool>(nullable: false),
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
                    RovingMic = table.Column<bool>(nullable: false)
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
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AssigneeId = table.Column<int>(nullable: false),
                    AssignmentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Assignees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentTypes_AssignmentTypeId",
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
                    Demo1PubId = table.Column<int>(nullable: false),
                    Demo1AsstId = table.Column<int>(nullable: false),
                    Demo2PubId = table.Column<int>(nullable: false),
                    Demo2AsstId = table.Column<int>(nullable: false),
                    Demo3PubId = table.Column<int>(nullable: false),
                    Demo3AsstId = table.Column<int>(nullable: false),
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
                        name: "FK_ClmmSchedules_Assignments_Attendant1Id",
                        column: x => x.Attendant1Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Attendant2Id",
                        column: x => x.Attendant2Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Attendant3Id",
                        column: x => x.Attendant3Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Attendant4Id",
                        column: x => x.Attendant4Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_CbsConductorId",
                        column: x => x.CbsConductorId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_CbsReaderId",
                        column: x => x.CbsReaderId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_ChairmanId",
                        column: x => x.ChairmanId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_ClosingPrayerId",
                        column: x => x.ClosingPrayerId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo1AsstId",
                        column: x => x.Demo1AsstId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo1PubId",
                        column: x => x.Demo1PubId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo2AsstId",
                        column: x => x.Demo2AsstId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo2PubId",
                        column: x => x.Demo2PubId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo3AsstId",
                        column: x => x.Demo3AsstId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo3PubId",
                        column: x => x.Demo3PubId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_GemsId",
                        column: x => x.GemsId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_LacPart1Id",
                        column: x => x.LacPart1Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_LacPart2Id",
                        column: x => x.LacPart2Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_LacPart3Id",
                        column: x => x.LacPart3Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_OpeningPrayerId",
                        column: x => x.OpeningPrayerId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_RovingMic1Id",
                        column: x => x.RovingMic1Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_RovingMic2Id",
                        column: x => x.RovingMic2Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_SchoolBibleReadingId",
                        column: x => x.SchoolBibleReadingId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_SchoolTalkId",
                        column: x => x.SchoolTalkId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_SoundDeskId",
                        column: x => x.SoundDeskId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_TreasuresId",
                        column: x => x.TreasuresId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PmSchedules",
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
                    WtReaderId = table.Column<int>(nullable: false),
                    Speaker = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_Attendant1Id",
                        column: x => x.Attendant1Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_Attendant2Id",
                        column: x => x.Attendant2Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_Attendant3Id",
                        column: x => x.Attendant3Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_Attendant4Id",
                        column: x => x.Attendant4Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_ChairmanId",
                        column: x => x.ChairmanId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_ClosingPrayerId",
                        column: x => x.ClosingPrayerId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_OpeningPrayerId",
                        column: x => x.OpeningPrayerId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_RovingMic1Id",
                        column: x => x.RovingMic1Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_RovingMic2Id",
                        column: x => x.RovingMic2Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_SoundDeskId",
                        column: x => x.SoundDeskId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Assignments_WtReaderId",
                        column: x => x.WtReaderId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssigneeId",
                table: "Assignments",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentTypeId",
                table: "Assignments",
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
                name: "IX_ClmmSchedules_Demo1AsstId",
                table: "ClmmSchedules",
                column: "Demo1AsstId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo1PubId",
                table: "ClmmSchedules",
                column: "Demo1PubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo2AsstId",
                table: "ClmmSchedules",
                column: "Demo2AsstId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo2PubId",
                table: "ClmmSchedules",
                column: "Demo2PubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo3AsstId",
                table: "ClmmSchedules",
                column: "Demo3AsstId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_Demo3PubId",
                table: "ClmmSchedules",
                column: "Demo3PubId");

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
                name: "IX_PmSchedules_Attendant1Id",
                table: "PmSchedules",
                column: "Attendant1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_Attendant2Id",
                table: "PmSchedules",
                column: "Attendant2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_Attendant3Id",
                table: "PmSchedules",
                column: "Attendant3Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_Attendant4Id",
                table: "PmSchedules",
                column: "Attendant4Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_ChairmanId",
                table: "PmSchedules",
                column: "ChairmanId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_ClosingPrayerId",
                table: "PmSchedules",
                column: "ClosingPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_OpeningPrayerId",
                table: "PmSchedules",
                column: "OpeningPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_PlatformId",
                table: "PmSchedules",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_RovingMic1Id",
                table: "PmSchedules",
                column: "RovingMic1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_RovingMic2Id",
                table: "PmSchedules",
                column: "RovingMic2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_SoundDeskId",
                table: "PmSchedules",
                column: "SoundDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_WtReaderId",
                table: "PmSchedules",
                column: "WtReaderId");

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
                name: "PmSchedules");

            migrationBuilder.DropTable(
                name: "UnavailablePeriods");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Assignees");

            migrationBuilder.DropTable(
                name: "AssignmentTypes");
        }
    }
}
