using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnIDfromCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Columns_ColumnsID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ColumnsID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ColumnsID",
                table: "Categories");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
