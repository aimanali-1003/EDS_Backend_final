using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class DropContraintsTableJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
    name: "FK_Job_Client_ClientID", // Update with the actual constraint name
    table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_ClientID", // Update with the actual index name
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Job");

            migrationBuilder.DropForeignKey(
    name: "FK_Job_Frequency_FrequencyID", // Update with the actual constraint name
    table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_FrequencyID", // Update with the actual index name
                table: "Job");

            migrationBuilder.DropColumn(
                name: "FrequencyID",
                table: "Job");

            migrationBuilder.DropForeignKey(
    name: "FK_Job_DataRecipient_RecipientID", // Update with the actual constraint name
    table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_RecipientID", // Update with the actual index name
                table: "Job");

            migrationBuilder.DropColumn(
                name: "RecipientID",
                table: "Job");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
