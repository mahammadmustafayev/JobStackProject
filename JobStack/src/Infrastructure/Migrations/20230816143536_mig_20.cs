using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobStack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyUserId",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateUserId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyUserId",
                table: "Companies",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CandidateUserId",
                table: "Candidates",
                column: "CandidateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_CandidateUserId",
                table: "Candidates",
                column: "CandidateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_CompanyUserId",
                table: "Companies",
                column: "CompanyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_CandidateUserId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_CompanyUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_CandidateUserId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CandidateUserId",
                table: "Candidates");
        }
    }
}
