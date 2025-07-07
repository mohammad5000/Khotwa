using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditedTutorRequestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TutorRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "TutorRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "TutorRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "TutorRequests");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "TutorRequests");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "TutorRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
