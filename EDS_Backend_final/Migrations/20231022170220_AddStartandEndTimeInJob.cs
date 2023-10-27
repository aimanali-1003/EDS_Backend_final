using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddStartandEndTimeInJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
             name: "startTime",
             table: "Job",
             type: "datetime2",
             nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "endTime",
                table: "Job",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
               name: "DataRecipientFailAlarm",
               table: "Job",
               nullable: true, // Make the column nullable
               oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
               name: "NotificationRecipientFailAlarm",
               table: "Job",
               nullable: true, // Make the column nullable
               oldClrType: typeof(int));


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "startTime",
               table: "Job");

            migrationBuilder.DropColumn(
                name: "endTime",
                table: "Job");
        }
    }
}
