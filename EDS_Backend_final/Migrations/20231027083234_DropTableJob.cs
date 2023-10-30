using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class DropTableJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //                   name: "Job");
            //        migrationBuilder.DropForeignKey(
            //name: "FileFormatID",
            //table: "FileFormat");

            //migrationBuilder.DropForeignKey(
            //   name: "FK_Job_FileFormat_FileFormatID",
            //   table: "Job");

            //migrationBuilder.DropIndex(
            //    name: "IX_Job_FileFormatID",
            //    table: "Job");

            //migrationBuilder.DropColumn(
            //    name: "FileFormatID",
            //    table: "Job");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
