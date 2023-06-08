using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Manegment_System.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Committee",
                columns: table => new
                {
                    CommitteeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committee", x => x.CommitteeId);
                    table.ForeignKey(
                        name: "FK_Committee_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emergency = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.MeetingId);
                    table.ForeignKey(
                        name: "FK_Meeting_Committee_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committee",
                        principalColumn: "CommitteeId");
                });

            migrationBuilder.CreateTable(
                name: "MemberCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberCommittees", x => new { x.MemberId, x.CommitteeId });
                    table.ForeignKey(
                        name: "FK_MemberCommittees_Committee_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committee",
                        principalColumn: "CommitteeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberCommittees_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votings",
                columns: table => new
                {
                    VotingId = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votings", x => new { x.VotingId, x.MeetingId });
                    table.ForeignKey(
                        name: "FK_Votings_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotingId = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    CommitteeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembersAnswers_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "MeetingId");
                    table.ForeignKey(
                        name: "FK_MembersAnswers_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK_MembersAnswers_Votings_VotingId_MeetingId",
                        columns: x => new { x.VotingId, x.MeetingId },
                        principalTable: "Votings",
                        principalColumns: new[] { "VotingId", "MeetingId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Committee_OrganizationId",
                table: "Committee",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_CommitteeId",
                table: "Meeting",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberCommittees_CommitteeId",
                table: "MemberCommittees",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAnswers_MeetingId",
                table: "MembersAnswers",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAnswers_MemberId",
                table: "MembersAnswers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAnswers_VotingId_MeetingId",
                table: "MembersAnswers",
                columns: new[] { "VotingId", "MeetingId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MeetingId",
                table: "Reports",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Votings_MeetingId",
                table: "Votings",
                column: "MeetingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberCommittees");

            migrationBuilder.DropTable(
                name: "MembersAnswers");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Votings");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Committee");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
