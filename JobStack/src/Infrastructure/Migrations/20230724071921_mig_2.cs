using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobStack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Cities_CityId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Countries_CountryId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_Candidate_CandidateId",
                table: "Experience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experience",
                table: "Experience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.RenameTable(
                name: "Experience",
                newName: "Experiences");

            migrationBuilder.RenameTable(
                name: "Candidate",
                newName: "Candidates");

            migrationBuilder.RenameIndex(
                name: "IX_Experience_CandidateId",
                table: "Experiences",
                newName: "IX_Experiences_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_CountryId",
                table: "Candidates",
                newName: "IX_Candidates_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_CityId",
                table: "Candidates",
                newName: "IX_Candidates_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Cities_CityId",
                table: "Candidates",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Countries_CountryId",
                table: "Candidates",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Candidates_CandidateId",
                table: "Experiences",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Cities_CityId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Countries_CountryId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Candidates_CandidateId",
                table: "Experiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Experiences",
                table: "Experiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "Experiences",
                newName: "Experience");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "Candidate");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_CandidateId",
                table: "Experience",
                newName: "IX_Experience_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_CountryId",
                table: "Candidate",
                newName: "IX_Candidate_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_CityId",
                table: "Candidate",
                newName: "IX_Candidate_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experience",
                table: "Experience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Cities_CityId",
                table: "Candidate",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Countries_CountryId",
                table: "Candidate",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_Candidate_CandidateId",
                table: "Experience",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
