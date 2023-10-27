using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class dropJobsTableIndb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
name: "FK_JobStatus_Job_JobID", // Replace with the actual constraint name
table: "JobStatus");

            migrationBuilder.DropForeignKey(
    name: "FK_JobLog_Job_JobID", // Replace with the actual constraint name
    table: "JobLog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
