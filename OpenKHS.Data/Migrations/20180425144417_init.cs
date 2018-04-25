using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OpenKHS.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignmentTally = table.Column<int>(nullable: false),
                    Attendant = table.Column<bool>(nullable: false),
                    AwaySpeaker = table.Column<bool>(nullable: false),
                    ClmmBibleReading = table.Column<bool>(nullable: false),
                    ClmmCbsConductor = table.Column<bool>(nullable: false),
                    ClmmCbsReader = table.Column<bool>(nullable: false),
                    ClmmChairman = table.Column<bool>(nullable: false),
                    ClmmGems = table.Column<bool>(nullable: false),
                    ClmmLacParts = table.Column<bool>(nullable: false),
                    ClmmMainHallOnly = table.Column<bool>(nullable: false),
                    ClmmPrayer = table.Column<bool>(nullable: false),
                    ClmmSchoolAssistant = table.Column<bool>(nullable: false),
                    ClmmSchoolBibleStudy = table.Column<bool>(nullable: false),
                    ClmmSchoolInitialCall = table.Column<bool>(nullable: false),
                    ClmmSchoolMonthPresentations = table.Column<bool>(nullable: false),
                    ClmmSchoolReturnVisit = table.Column<bool>(nullable: false),
                    ClmmSchoolTalk = table.Column<bool>(nullable: false),
                    ClmmSecondSchoolCounselor = table.Column<bool>(nullable: false),
                    ClmmSecondSchoolOnly = table.Column<bool>(nullable: false),
                    ClmmTreasures = table.Column<bool>(nullable: false),
                    MainWtConductor = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Platform = table.Column<bool>(nullable: false),
                    PmChairman = table.Column<bool>(nullable: false),
                    PublicSpeaker = table.Column<bool>(nullable: false),
                    RovingMic = table.Column<bool>(nullable: false),
                    Security = table.Column<bool>(nullable: false),
                    SoundDesk = table.Column<bool>(nullable: false),
                    WtConductor = table.Column<bool>(nullable: false),
                    WtReader = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingPart",
                columns: table => new
                {
                    AssistantId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Discriminator = table.Column<string>(nullable: false),
                    FriendId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TalkNumber = table.Column<int>(nullable: true),
                    CounselPoint = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingPart_Friends_AssistantId",
                        column: x => x.AssistantId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingPart_Friends_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingPart_Friends_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnavailablePeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    End = table.Column<DateTime>(nullable: false),
                    FriendId = table.Column<int>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnavailablePeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnavailablePeriods_Friends_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClmmSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AYttMBibleStudyId = table.Column<int>(nullable: true),
                    AYttMPart1Id = table.Column<int>(nullable: true),
                    AYttMPart2Id = table.Column<int>(nullable: true),
                    AYttMSchoolTalkId = table.Column<int>(nullable: true),
                    AttendantId = table.Column<int>(nullable: true),
                    BibleReadingId = table.Column<int>(nullable: true),
                    CbsConductorId = table.Column<int>(nullable: true),
                    CbsReaderId = table.Column<int>(nullable: true),
                    ChairmanId = table.Column<int>(nullable: true),
                    ClosingPrayerId = table.Column<int>(nullable: true),
                    GemsId = table.Column<int>(nullable: true),
                    LacPart1Id = table.Column<int>(nullable: true),
                    LacPart2Id = table.Column<int>(nullable: true),
                    LacPart3Id = table.Column<int>(nullable: true),
                    OpeningPrayerId = table.Column<int>(nullable: true),
                    PlatformId = table.Column<int>(nullable: true),
                    RovingMic1Id = table.Column<int>(nullable: true),
                    RovingMic2Id = table.Column<int>(nullable: true),
                    SecurityId = table.Column<int>(nullable: true),
                    SoundDeskId = table.Column<int>(nullable: true),
                    TreasuresId = table.Column<int>(nullable: true),
                    WeekStarting = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClmmSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_MeetingPart_AYttMBibleStudyId",
                        column: x => x.AYttMBibleStudyId,
                        principalTable: "MeetingPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_MeetingPart_AYttMPart1Id",
                        column: x => x.AYttMPart1Id,
                        principalTable: "MeetingPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_MeetingPart_AYttMPart2Id",
                        column: x => x.AYttMPart2Id,
                        principalTable: "MeetingPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_MeetingPart_AYttMSchoolTalkId",
                        column: x => x.AYttMSchoolTalkId,
                        principalTable: "MeetingPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_AttendantId",
                        column: x => x.AttendantId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_BibleReadingId",
                        column: x => x.BibleReadingId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_CbsConductorId",
                        column: x => x.CbsConductorId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_CbsReaderId",
                        column: x => x.CbsReaderId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_ChairmanId",
                        column: x => x.ChairmanId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_ClosingPrayerId",
                        column: x => x.ClosingPrayerId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_GemsId",
                        column: x => x.GemsId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_MeetingPart_LacPart1Id",
                        column: x => x.LacPart1Id,
                        principalTable: "MeetingPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_MeetingPart_LacPart2Id",
                        column: x => x.LacPart2Id,
                        principalTable: "MeetingPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_MeetingPart_LacPart3Id",
                        column: x => x.LacPart3Id,
                        principalTable: "MeetingPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_OpeningPrayerId",
                        column: x => x.OpeningPrayerId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_RovingMic1Id",
                        column: x => x.RovingMic1Id,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_RovingMic2Id",
                        column: x => x.RovingMic2Id,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_SoundDeskId",
                        column: x => x.SoundDeskId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClmmSchedules_Friends_TreasuresId",
                        column: x => x.TreasuresId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PmSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttendantId = table.Column<int>(nullable: true),
                    ChairmanId = table.Column<int>(nullable: true),
                    PlatformId = table.Column<int>(nullable: true),
                    PublicTalkId = table.Column<int>(nullable: true),
                    RovingMic1Id = table.Column<int>(nullable: true),
                    RovingMic2Id = table.Column<int>(nullable: true),
                    SecurityId = table.Column<int>(nullable: true),
                    SoundDeskId = table.Column<int>(nullable: true),
                    WeekStarting = table.Column<DateTime>(nullable: false),
                    WtConductorId = table.Column<int>(nullable: true),
                    WtReaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_AttendantId",
                        column: x => x.AttendantId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_ChairmanId",
                        column: x => x.ChairmanId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_MeetingPart_PublicTalkId",
                        column: x => x.PublicTalkId,
                        principalTable: "MeetingPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_RovingMic1Id",
                        column: x => x.RovingMic1Id,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_RovingMic2Id",
                        column: x => x.RovingMic2Id,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_SoundDeskId",
                        column: x => x.SoundDeskId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_WtConductorId",
                        column: x => x.WtConductorId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PmSchedules_Friends_WtReaderId",
                        column: x => x.WtReaderId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_AYttMBibleStudyId",
                table: "ClmmSchedules",
                column: "AYttMBibleStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_AYttMPart1Id",
                table: "ClmmSchedules",
                column: "AYttMPart1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_AYttMPart2Id",
                table: "ClmmSchedules",
                column: "AYttMPart2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_AYttMSchoolTalkId",
                table: "ClmmSchedules",
                column: "AYttMSchoolTalkId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_AttendantId",
                table: "ClmmSchedules",
                column: "AttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_BibleReadingId",
                table: "ClmmSchedules",
                column: "BibleReadingId");

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
                name: "IX_ClmmSchedules_SecurityId",
                table: "ClmmSchedules",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_SoundDeskId",
                table: "ClmmSchedules",
                column: "SoundDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_TreasuresId",
                table: "ClmmSchedules",
                column: "TreasuresId");

            migrationBuilder.CreateIndex(
                name: "IX_ClmmSchedules_WeekStarting",
                table: "ClmmSchedules",
                column: "WeekStarting",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_Name",
                table: "Friends",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPart_AssistantId",
                table: "MeetingPart",
                column: "AssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPart_FriendId",
                table: "MeetingPart",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPart_StudentId",
                table: "MeetingPart",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_AttendantId",
                table: "PmSchedules",
                column: "AttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_ChairmanId",
                table: "PmSchedules",
                column: "ChairmanId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_PlatformId",
                table: "PmSchedules",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_PublicTalkId",
                table: "PmSchedules",
                column: "PublicTalkId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_RovingMic1Id",
                table: "PmSchedules",
                column: "RovingMic1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_RovingMic2Id",
                table: "PmSchedules",
                column: "RovingMic2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_SecurityId",
                table: "PmSchedules",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_SoundDeskId",
                table: "PmSchedules",
                column: "SoundDeskId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_WeekStarting",
                table: "PmSchedules",
                column: "WeekStarting",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_WtConductorId",
                table: "PmSchedules",
                column: "WtConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_WtReaderId",
                table: "PmSchedules",
                column: "WtReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_UnavailablePeriods_FriendId",
                table: "UnavailablePeriods",
                column: "FriendId");
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
                name: "MeetingPart");

            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
