using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableCriteriaIdInJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
           name: "CriteriaID",
           table: "Job",
           nullable: true, // Make the column nullable
           oldClrType: typeof(int),
           oldNullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "CriteriaID",
            table: "Job",
            nullable: false, // If you ever need to revert the change, specify the correct value
            oldClrType: typeof(int),
            oldNullable: true);
        }
    }
}
