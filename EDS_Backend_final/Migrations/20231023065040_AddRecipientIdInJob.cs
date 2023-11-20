using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipientIdInJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
           name: "RecipientID",
           table: "Job", // Specify the correct table name
           nullable: true,
           defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Job_RecipientID", // Specify the correct table name
                table: "Job",
                column: "RecipientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_DataRecipient_RecipientID", // Specify the correct table names
                table: "Job",
                column: "RecipientID",
                principalTable: "DataRecipient", // Specify the correct table name
                principalColumn: "RecipientID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
           name: "FK_Job_DataRecipient_RecipientID", // Specify the correct table names
           table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_RecipientID", // Specify the correct table name
                table: "Job");

            migrationBuilder.DropColumn(
                name: "RecipientID",
                table: "Job");
        }
    }
}
