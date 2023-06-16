using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Manegment_System.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberMeeting",
                columns: table => new
                {
                    MemberMeetingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberMeeting", x => x.MemberMeetingId);
                    table.ForeignKey(
                        name: "FK_MemberMeeting_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "MeetingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberMeeting_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberMeeting_MeetingId",
                table: "MemberMeeting",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberMeeting_MemberId",
                table: "MemberMeeting",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberMeeting");
        }
    }
}
