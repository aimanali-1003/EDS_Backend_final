using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class addColumnInJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "DayofWeek_Lkp",
            table: "Job", // Replace with the actual table name for your Job entity
            type: "nvarchar(11)",
            nullable: true); // Depending on your requirements, you may set this to nullable or not
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
             name: "DayofWeek_Lkp",
             table: "Job"
             );// Replace with the actual table name for your Job entity

        }
    }
}
