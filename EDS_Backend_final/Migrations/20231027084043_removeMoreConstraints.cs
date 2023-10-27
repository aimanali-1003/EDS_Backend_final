using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class removeMoreConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
    name: "FK_Job_Criteria_CriteriaID", // Update with the actual constraint name
    table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CriteriaID", // Update with the actual index name
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CriteriaID",
                table: "Job");

            migrationBuilder.DropForeignKey(
    name: "FK_Job_Template_TemplateID", // Update with the actual constraint name
    table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_TemplateID", // Update with the actual index name
                table: "Job");

            migrationBuilder.DropColumn(
                name: "TemplateID",
                table: "Job");
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Lookup_LookupID", // Update with the actual constraint name
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_LookupID", // Update with the actual index name
                table: "Job");

            migrationBuilder.DropColumn(
                name: "LookupID",
                table: "Job");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
