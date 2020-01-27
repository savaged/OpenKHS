using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenKHS.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignmentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CongregationMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ClmmChairman = table.Column<bool>(nullable: true),
                    ClmmSecondSchoolCounselor = table.Column<bool>(nullable: true),
                    ClmmTreasures = table.Column<bool>(nullable: true),
                    ClmmGems = table.Column<bool>(nullable: true),
                    ClmmBibleReading = table.Column<bool>(nullable: true),
                    ClmmSchoolInitialCall = table.Column<bool>(nullable: true),
                    ClmmSchoolReturnVisit = table.Column<bool>(nullable: true),
                    ClmmSchoolBibleStudy = table.Column<bool>(nullable: true),
                    ClmmSchoolTalk = table.Column<bool>(nullable: true),
                    ClmmSchoolAssistant = table.Column<bool>(nullable: true),
                    ClmmSecondSchoolOnly = table.Column<bool>(nullable: true),
                    ClmmMainHallOnly = table.Column<bool>(nullable: true),
                    ClmmLacParts = table.Column<bool>(nullable: true),
                    ClmmCbsConductor = table.Column<bool>(nullable: true),
                    ClmmCbsReader = table.Column<bool>(nullable: true),
                    PublicSpeaker = table.Column<bool>(nullable: true),
                    AwaySpeaker = table.Column<bool>(nullable: true),
                    PmChairman = table.Column<bool>(nullable: true),
                    Prayer = table.Column<bool>(nullable: true),
                    WtReader = table.Column<bool>(nullable: true),
                    Attendant = table.Column<bool>(nullable: true),
                    Security = table.Column<bool>(nullable: true),
                    SoundDesk = table.Column<bool>(nullable: true),
                    Platform = table.Column<bool>(nullable: true),
                    RovingMic = table.Column<bool>(nullable: true),
                    WtConductor = table.Column<bool>(nullable: true),
                    MainWtConductor = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongregationMember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssigneeId = table.Column<int>(nullable: false),
                    Due = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_CongregationMember_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "CongregationMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AssignmentType",
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
                        name: "FK_UnavailablePeriods_CongregationMember_LocalCongregationMemberId",
                        column: x => x.LocalCongregationMemberId,
                        principalTable: "CongregationMember",
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
                name: "AssignmentType");

            migrationBuilder.DropTable(
                name: "CongregationMember");
        }
    }
}
