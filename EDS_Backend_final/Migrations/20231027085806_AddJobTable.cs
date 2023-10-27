using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                    migrationBuilder.CreateTable(
                         name: "Job",
                         columns: table => new
                         {
                             JobID = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                             JobType = table.Column<string>(maxLength: 255, nullable: false),
                             StartDate = table.Column<DateTime>(nullable: true),
                             EndDate = table.Column<DateTime>(nullable: true),
                             NotificationCheck = table.Column<bool>(nullable: true),
                             MinRecordCountAlarm = table.Column<int>(nullable: true),
                             MaxRecordCountAlarm = table.Column<int>(nullable: true),
                             MinRunDurationAlarm = table.Column<int>(nullable: true),
                             MaxRunDurationAlarm = table.Column<int>(nullable: true),
                             FileFormatID = table.Column<int>(nullable: false),
                             FrequencyID = table.Column<int>(nullable: false),
                             DataRecipientID = table.Column<int>(nullable: false),
                             TemplateID = table.Column<int>(nullable: false),
                         },
                         constraints: table =>
                         {
                             table.PrimaryKey("PK_Job", x => x.JobID);

                             table.ForeignKey(
                                    name: "FK_Job_FileFormat_FileFormatID",
                                    column: x => x.FileFormatID,
                                    principalTable: "FileFormat",
                                    principalColumn: "FileFormatID",
                                    onDelete: ReferentialAction.Cascade);

                             table.ForeignKey(
                                 name: "FK_Job_Frequency_FrequencyID",
                                 column: x => x.FrequencyID,
                                 principalTable: "Frequency",
                                 principalColumn: "FrequencyID",
                                 onDelete: ReferentialAction.Cascade);

                             table.ForeignKey(
                                 name: "FK_Job_DataRecipient_DataRecipientID",
                                 column: x => x.DataRecipientID,
                                 principalTable: "DataRecipient",
                                 principalColumn: "RecipientID",
                                 onDelete: ReferentialAction.Cascade);

                             table.ForeignKey(
                                 name: "FK_Job_Template_TemplateID",
                                 column: x => x.TemplateID,
                                 principalTable: "Template",
                                 principalColumn: "TemplateID",
                                 onDelete: ReferentialAction.Cascade);
                         }
             );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
