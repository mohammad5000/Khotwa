using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TutorRequest_Propsal_Attributes_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_TutorRequests_TutorRequestId",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequests_Categories_CategoryId",
                table: "TutorRequests");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "TutorRequests",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "TutorRequests",
                newName: "MinBudget");

            migrationBuilder.RenameIndex(
                name: "IX_TutorRequests_CategoryId",
                table: "TutorRequests",
                newName: "IX_TutorRequests_CategoryID");

            migrationBuilder.RenameColumn(
                name: "TutorRequestId",
                table: "Proposals",
                newName: "TutorRequestID");

            migrationBuilder.RenameIndex(
                name: "IX_Proposals_TutorRequestId",
                table: "Proposals",
                newName: "IX_Proposals_TutorRequestID");

            migrationBuilder.AddColumn<int>(
                name: "AcceptedProposalId",
                table: "TutorRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxBudget",
                table: "TutorRequests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SessionID",
                table: "TutorRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DemoId",
                table: "Proposals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceOffered",
                table: "Proposals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ProposalAvailableDate",
                columns: table => new
                {
                    AvailableDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalAvailableDate", x => new { x.ProposalId, x.AvailableDateTime });
                    table.ForeignKey(
                        name: "FK_ProposalAvailableDate_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_AcceptedProposalId",
                table: "TutorRequests",
                column: "AcceptedProposalId",
                unique: true,
                filter: "[AcceptedProposalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TutorRequests_SessionID",
                table: "TutorRequests",
                column: "SessionID",
                unique: true,
                filter: "[SessionID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_DemoId",
                table: "Proposals",
                column: "DemoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Demos_DemoId",
                table: "Proposals",
                column: "DemoId",
                principalTable: "Demos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_TutorRequests_TutorRequestID",
                table: "Proposals",
                column: "TutorRequestID",
                principalTable: "TutorRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequests_Categories_CategoryID",
                table: "TutorRequests",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequests_Proposals_AcceptedProposalId",
                table: "TutorRequests",
                column: "AcceptedProposalId",
                principalTable: "Proposals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequests_Sessions_SessionID",
                table: "TutorRequests",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Demos_DemoId",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_TutorRequests_TutorRequestID",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequests_Categories_CategoryID",
                table: "TutorRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequests_Proposals_AcceptedProposalId",
                table: "TutorRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorRequests_Sessions_SessionID",
                table: "TutorRequests");

            migrationBuilder.DropTable(
                name: "ProposalAvailableDate");

            migrationBuilder.DropIndex(
                name: "IX_TutorRequests_AcceptedProposalId",
                table: "TutorRequests");

            migrationBuilder.DropIndex(
                name: "IX_TutorRequests_SessionID",
                table: "TutorRequests");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_DemoId",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "AcceptedProposalId",
                table: "TutorRequests");

            migrationBuilder.DropColumn(
                name: "MaxBudget",
                table: "TutorRequests");

            migrationBuilder.DropColumn(
                name: "SessionID",
                table: "TutorRequests");

            migrationBuilder.DropColumn(
                name: "DemoId",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "PriceOffered",
                table: "Proposals");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "TutorRequests",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "MinBudget",
                table: "TutorRequests",
                newName: "Budget");

            migrationBuilder.RenameIndex(
                name: "IX_TutorRequests_CategoryID",
                table: "TutorRequests",
                newName: "IX_TutorRequests_CategoryId");

            migrationBuilder.RenameColumn(
                name: "TutorRequestID",
                table: "Proposals",
                newName: "TutorRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Proposals_TutorRequestID",
                table: "Proposals",
                newName: "IX_Proposals_TutorRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_TutorRequests_TutorRequestId",
                table: "Proposals",
                column: "TutorRequestId",
                principalTable: "TutorRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TutorRequests_Categories_CategoryId",
                table: "TutorRequests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
