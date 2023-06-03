using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Manegment_System.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Organizations_OrganizationId",
                table: "Committees");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Committees_CommitteeId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberCommittees_Committees_CommitteeId",
                table: "MemberCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberCommittees_Members_MemberId",
                table: "MemberCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAnswers_Meetings_MeetingId",
                table: "MembersAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAnswers_Members_MemberId",
                table: "MembersAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAnswers_Votings_VotingId",
                table: "MembersAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Meetings_MeetingId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Votings_Meetings_MeetingId",
                table: "Votings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Committees",
                table: "Committees");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameTable(
                name: "Meetings",
                newName: "Meeting");

            migrationBuilder.RenameTable(
                name: "Committees",
                newName: "Committee");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_CommitteeId",
                table: "Meeting",
                newName: "IX_Meeting_CommitteeId");

            migrationBuilder.RenameIndex(
                name: "IX_Committees_OrganizationId",
                table: "Committee",
                newName: "IX_Committee_OrganizationId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Committee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Committee",
                table: "Committee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Committee_Organizations_OrganizationId",
                table: "Committee",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Committee_CommitteeId",
                table: "Meeting",
                column: "CommitteeId",
                principalTable: "Committee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberCommittees_Committee_CommitteeId",
                table: "MemberCommittees",
                column: "CommitteeId",
                principalTable: "Committee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberCommittees_Member_MemberId",
                table: "MemberCommittees",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAnswers_Meeting_MeetingId",
                table: "MembersAnswers",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAnswers_Member_MemberId",
                table: "MembersAnswers",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAnswers_Votings_VotingId",
                table: "MembersAnswers",
                column: "VotingId",
                principalTable: "Votings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Meeting_MeetingId",
                table: "Reports",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votings_Meeting_MeetingId",
                table: "Votings",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committee_Organizations_OrganizationId",
                table: "Committee");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Committee_CommitteeId",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberCommittees_Committee_CommitteeId",
                table: "MemberCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberCommittees_Member_MemberId",
                table: "MemberCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAnswers_Meeting_MeetingId",
                table: "MembersAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAnswers_Member_MemberId",
                table: "MembersAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_MembersAnswers_Votings_VotingId",
                table: "MembersAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Meeting_MeetingId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Votings_Meeting_MeetingId",
                table: "Votings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Committee",
                table: "Committee");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Committee");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "Meeting",
                newName: "Meetings");

            migrationBuilder.RenameTable(
                name: "Committee",
                newName: "Committees");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_CommitteeId",
                table: "Meetings",
                newName: "IX_Meetings_CommitteeId");

            migrationBuilder.RenameIndex(
                name: "IX_Committee_OrganizationId",
                table: "Committees",
                newName: "IX_Committees_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Committees",
                table: "Committees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Organizations_OrganizationId",
                table: "Committees",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Committees_CommitteeId",
                table: "Meetings",
                column: "CommitteeId",
                principalTable: "Committees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberCommittees_Committees_CommitteeId",
                table: "MemberCommittees",
                column: "CommitteeId",
                principalTable: "Committees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberCommittees_Members_MemberId",
                table: "MemberCommittees",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAnswers_Meetings_MeetingId",
                table: "MembersAnswers",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAnswers_Members_MemberId",
                table: "MembersAnswers",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MembersAnswers_Votings_VotingId",
                table: "MembersAnswers",
                column: "VotingId",
                principalTable: "Votings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Meetings_MeetingId",
                table: "Reports",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votings_Meetings_MeetingId",
                table: "Votings",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
