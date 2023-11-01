using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TemplateColumns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Template",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrgLevel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Org",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NotificationRecipient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lookup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobLog",
                type: "bit",
                nullable: false,
                defaultValue: false);
 

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Frequency",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DataRecipientType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DataRecipient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Criteria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Columns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

             
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Clients_ClientID",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_ClientID",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TemplateColumns");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Template");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrgLevel");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Org");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NotificationRecipient");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lookup");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobLog");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Frequency");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DataRecipientType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DataRecipient");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Criteria");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Columns");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");
        }
    }
}
