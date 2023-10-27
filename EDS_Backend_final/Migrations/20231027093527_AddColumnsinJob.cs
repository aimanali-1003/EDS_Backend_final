using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsinJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                 name: "CriteriaID",
                 table: "Job",
                 nullable: true
             );

            migrationBuilder.AddColumn<int>(
                name: "LookupID",
                table: "Job",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Job",
                nullable: false
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Job",
                nullable: false
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Job",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Job",
                nullable: false
            );

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Job",
                nullable: true
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
