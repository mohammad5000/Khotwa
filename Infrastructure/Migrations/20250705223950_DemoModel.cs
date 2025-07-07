using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DemoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequest_AspNetUsers_CustomerId",
                table: "TutorRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequest_Categories_CategoryId",
                table: "TutorRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TutorRequest",
                table: "TutorRequest");

            migrationBuilder.RenameTable(
                name: "TutorRequest",
                newName: "TutorRequests");

            migrationBuilder.RenameIndex(
                name: "IX_TutorRequest_CustomerId",
                table: "TutorRequests",
                newName: "IX_TutorRequests_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_TutorRequest_CategoryId",
                table: "TutorRequests",
                newName: "IX_TutorRequests_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TutorRequests",
                table: "TutorRequests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Demos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequests_AspNetUsers_CustomerId",
                table: "TutorRequests",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequests_Categories_CategoryId",
                table: "TutorRequests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequests_AspNetUsers_CustomerId",
                table: "TutorRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequests_Categories_CategoryId",
                table: "TutorRequests");

            migrationBuilder.DropTable(
                name: "Demos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TutorRequests",
                table: "TutorRequests");

            migrationBuilder.RenameTable(
                name: "TutorRequests",
                newName: "TutorRequest");

            migrationBuilder.RenameIndex(
                name: "IX_TutorRequests_CustomerId",
                table: "TutorRequest",
                newName: "IX_TutorRequest_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_TutorRequests_CategoryId",
                table: "TutorRequest",
                newName: "IX_TutorRequest_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TutorRequest",
                table: "TutorRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequest_AspNetUsers_CustomerId",
                table: "TutorRequest",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequest_Categories_CategoryId",
                table: "TutorRequest",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
