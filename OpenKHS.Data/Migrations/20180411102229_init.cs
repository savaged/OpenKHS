using Microsoft.EntityFrameworkCore.Metadata;
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Name = table.Column<string>(nullable: true),
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
                name: "DateRange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    End = table.Column<DateTime>(nullable: false),
                    FriendId = table.Column<int>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateRange_Friends_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicTalk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FriendId = table.Column<int>(nullable: true),
                    TalkNumber = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicTalk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicTalk_Friends_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PmSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttendantId = table.Column<int>(nullable: true),
                    ChairmanId = table.Column<int>(nullable: true),
                    PlatformId = table.Column<int>(nullable: true),
                    PublicTalkId = table.Column<int>(nullable: true),
                    RovingMic1Id = table.Column<int>(nullable: true),
                    RovingMic2Id = table.Column<int>(nullable: true),
                    SecurityId = table.Column<int>(nullable: true),
                    SoundDeskId = table.Column<int>(nullable: true),
                    Week = table.Column<int>(nullable: false),
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
                        name: "FK_PmSchedules_PublicTalk_PublicTalkId",
                        column: x => x.PublicTalkId,
                        principalTable: "PublicTalk",
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
                name: "IX_DateRange_FriendId",
                table: "DateRange",
                column: "FriendId");

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
                name: "IX_PmSchedules_WtConductorId",
                table: "PmSchedules",
                column: "WtConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_PmSchedules_WtReaderId",
                table: "PmSchedules",
                column: "WtReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicTalk_FriendId",
                table: "PublicTalk",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateRange");

            migrationBuilder.DropTable(
                name: "PmSchedules");

            migrationBuilder.DropTable(
                name: "PublicTalk");

            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
