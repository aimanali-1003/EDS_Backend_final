using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class FileFormatIDinJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddForeignKey(
            //    name: "FK_Job_FileFormat_FileFormatID",
            //    table: "Job",
            //    column: "FileFormatID",
            //    principalTable: "FileFormat",
            //    principalColumn: "FileFormatID",
            //    onDelete: ReferentialAction.Restrict
            //);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
