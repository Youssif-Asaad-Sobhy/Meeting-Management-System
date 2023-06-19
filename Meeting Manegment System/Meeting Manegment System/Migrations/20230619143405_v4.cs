using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meeting_Manegment_System.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MembersAnswers");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Meeting",
                newName: "StartDate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Votings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "MembersAnswers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "Meeting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Meeting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Meeting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Meeting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Votings");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "MembersAnswers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Meeting");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Meeting");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Meeting",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MembersAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "Meeting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
