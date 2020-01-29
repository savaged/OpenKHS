using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenKHS.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "LocalCongregationMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    ClmmChairman = table.Column<bool>(nullable: false),
                    ClmmSecondSchoolCounselor = table.Column<bool>(nullable: false),
                    ClmmTreasures = table.Column<bool>(nullable: false),
                    ClmmGems = table.Column<bool>(nullable: false),
                    ClmmBibleReading = table.Column<bool>(nullable: false),
                    ClmmSchoolInitialCall = table.Column<bool>(nullable: false),
                    ClmmSchoolReturnVisit = table.Column<bool>(nullable: false),
                    ClmmSchoolBibleStudy = table.Column<bool>(nullable: false),
                    ClmmSchoolTalk = table.Column<bool>(nullable: false),
                    ClmmSchoolAssistant = table.Column<bool>(nullable: false),
                    ClmmSecondSchoolOnly = table.Column<bool>(nullable: false),
                    ClmmMainHallOnly = table.Column<bool>(nullable: false),
                    ClmmLacParts = table.Column<bool>(nullable: false),
                    ClmmCbsConductor = table.Column<bool>(nullable: false),
                    ClmmCbsReader = table.Column<bool>(nullable: false),
                    PublicSpeaker = table.Column<bool>(nullable: false),
                    AwaySpeaker = table.Column<bool>(nullable: false),
                    PmChairman = table.Column<bool>(nullable: false),
                    Prayer = table.Column<bool>(nullable: false),
                    WtReader = table.Column<bool>(nullable: false),
                    Attendant = table.Column<bool>(nullable: false),
                    Security = table.Column<bool>(nullable: false),
                    SoundDesk = table.Column<bool>(nullable: false),
                    Platform = table.Column<bool>(nullable: false),
                    RovingMic = table.Column<bool>(nullable: false),
                    WtConductor = table.Column<bool>(nullable: false),
                    MainWtConductor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalCongregationMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssigneeId = table.Column<int>(nullable: false),
                    DueWeekStarting = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_LocalCongregationMembers_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "LocalCongregationMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssignmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnavailablePeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocalCongregationMemberId = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnavailablePeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnavailablePeriods_LocalCongregationMembers_LocalCongregationMemberId",
                        column: x => x.LocalCongregationMemberId,
                        principalTable: "LocalCongregationMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssigneeId",
                table: "Assignments",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TypeId",
                table: "Assignments",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailablePeriods_LocalCongregationMemberId",
                table: "UnavailablePeriods",
                column: "LocalCongregationMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "UnavailablePeriods");

            migrationBuilder.DropTable(
                name: "AssignmentTypes");

            migrationBuilder.DropTable(
                name: "LocalCongregationMembers");
        }
    }
}
