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

            migrationBuilder.CreateTable(
                name: "ClmmSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeekStarting = table.Column<DateTime>(nullable: false),
                    OpeningPrayerId = table.Column<int>(nullable: false),
                    ClosingPrayerId = table.Column<int>(nullable: false),
                    ChairmanId = table.Column<int>(nullable: false),
                    TreasuresId = table.Column<int>(nullable: false),
                    GemsId = table.Column<int>(nullable: false),
                    BibleReadingId = table.Column<int>(nullable: false),
                    Demo1PublisherId = table.Column<int>(nullable: false),
                    Demo1HouseholderId = table.Column<int>(nullable: false),
                    Demo2PublisherId = table.Column<int>(nullable: false),
                    Demo2HouseholderId = table.Column<int>(nullable: false),
                    Demo3PublisherId = table.Column<int>(nullable: false),
                    Demo3HouseholderId = table.Column<int>(nullable: false),
                    ApplyYourselfToTheMinistryTalkId = table.Column<int>(nullable: false),
                    LivingAsChristiansPart1Id = table.Column<int>(nullable: false),
                    LivingAsChristiansPart2Id = table.Column<int>(nullable: false),
                    LivingAsChristiansPart3Id = table.Column<int>(nullable: false),
                    CongregationBibleStudyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClmmSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_ApplyYourselfToTheMinistryTalkId",
                        column: x => x.ApplyYourselfToTheMinistryTalkId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_BibleReadingId",
                        column: x => x.BibleReadingId,
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
                        name: "FK_ClmmSchedules_Assignments_CongregationBibleStudyId",
                        column: x => x.CongregationBibleStudyId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo1HouseholderId",
                        column: x => x.Demo1HouseholderId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo1PublisherId",
                        column: x => x.Demo1PublisherId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo2HouseholderId",
                        column: x => x.Demo2HouseholderId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo2PublisherId",
                        column: x => x.Demo2PublisherId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo3HouseholderId",
                        column: x => x.Demo3HouseholderId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_Demo3PublisherId",
                        column: x => x.Demo3PublisherId,
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
                        name: "FK_ClmmSchedules_Assignments_LivingAsChristiansPart1Id",
                        column: x => x.LivingAsChristiansPart1Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_LivingAsChristiansPart2Id",
                        column: x => x.LivingAsChristiansPart2Id,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Assignments_LivingAsChristiansPart3Id",
                        column: x => x.LivingAsChristiansPart3Id,
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
                        name: "FK_ClmmSchedules_Assignments_TreasuresId",
                        column: x => x.TreasuresId,
                        principalTable: "Assignments",
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
                name: "IX_ClmmSchedules_ApplyYourselfToTheMinistryTalkId",
                table: "ClmmSchedules",
                column: "ApplyYourselfToTheMinistryTalkId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_BibleReadingId",
                table: "ClmmSchedules",
                column: "BibleReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_ChairmanId",
                table: "ClmmSchedules",
                column: "ChairmanId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_ClosingPrayerId",
                table: "ClmmSchedules",
                column: "ClosingPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_CongregationBibleStudyId",
                table: "ClmmSchedules",
                column: "CongregationBibleStudyId");

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
                name: "IX_ClmmSchedules_LivingAsChristiansPart1Id",
                table: "ClmmSchedules",
                column: "LivingAsChristiansPart1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_LivingAsChristiansPart2Id",
                table: "ClmmSchedules",
                column: "LivingAsChristiansPart2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_LivingAsChristiansPart3Id",
                table: "ClmmSchedules",
                column: "LivingAsChristiansPart3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_OpeningPrayerId",
                table: "ClmmSchedules",
                column: "OpeningPrayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_TreasuresId",
                table: "ClmmSchedules",
                column: "TreasuresId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailablePeriods_LocalCongregationMemberId",
                table: "UnavailablePeriods",
                column: "LocalCongregationMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClmmSchedules");

            migrationBuilder.DropTable(
                name: "UnavailablePeriods");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "LocalCongregationMembers");

            migrationBuilder.DropTable(
                name: "AssignmentTypes");
        }
    }
}
