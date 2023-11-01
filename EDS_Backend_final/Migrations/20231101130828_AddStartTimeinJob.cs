using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddStartTimeinJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "StartTime",
            table: "Job", // Replace with your actual table name
            type: "nvarchar(max)", // Use the appropriate data type and length
            nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Job");

        }
    }
}
