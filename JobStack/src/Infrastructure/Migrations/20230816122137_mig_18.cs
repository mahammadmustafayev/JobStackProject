using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobStack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateSkillRating",
                table: "Candidates",
                type: "int",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CandidateSkillRating",
                table: "Candidates");
        }
    }
}
