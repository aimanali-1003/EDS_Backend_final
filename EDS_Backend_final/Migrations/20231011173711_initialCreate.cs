using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    ColumnsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColumnName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ColumnCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.ColumnsID);
                });

            migrationBuilder.CreateTable(
                name: "DayOfWeek",
                columns: table => new
                {
                    DayOfWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeek", x => x.DayOfWeekId);
                });

            migrationBuilder.CreateTable(
                name: "Frequency",
                columns: table => new
                {
                    FrequencyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequencyType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfMonth = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequency", x => x.FrequencyID);
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {
                    LookupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VisibleValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HiddenValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.LookupID);
                });

            migrationBuilder.CreateTable(
                name: "Org",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentOrganizationCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ParentOrganizationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Org", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ColumnsID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_Columns_ColumnsID",
                        column: x => x.ColumnsID,
                        principalTable: "Columns",
                        principalColumn: "ColumnsID");
                });

            migrationBuilder.CreateTable(
                name: "FrequencyDayOfWeek",
                columns: table => new
                {
                    DaysOfWeekDayOfWeekId = table.Column<int>(type: "int", nullable: false),
                    FrequencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequencyDayOfWeek", x => new { x.DaysOfWeekDayOfWeekId, x.FrequencyID });
                    table.ForeignKey(
                        name: "FK_FrequencyDayOfWeek_DayOfWeek_DaysOfWeekDayOfWeekId",
                        column: x => x.DaysOfWeekDayOfWeekId,
                        principalTable: "DayOfWeek",
                        principalColumn: "DayOfWeekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrequencyDayOfWeek_Frequency_FrequencyID",
                        column: x => x.FrequencyID,
                        principalTable: "Frequency",
                        principalColumn: "FrequencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClientCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgsOrganizationID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_Org_OrgsOrganizationID",
                        column: x => x.OrgsOrganizationID,
                        principalTable: "Org",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgLevel",
                columns: table => new
                {
                    OrganizationLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceColumn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgLevel", x => x.OrganizationLevelID);
                    table.ForeignKey(
                        name: "FK_OrgLevel_Org_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Org",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.TemplateID);
                    table.ForeignKey(
                        name: "FK_Template_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataRecipient",
                columns: table => new
                {
                    RecipientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRecipient", x => x.RecipientID);
                    table.ForeignKey(
                        name: "FK_DataRecipient_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataRecipient_Lookup_LookupID",
                        column: x => x.LookupID,
                        principalTable: "Lookup",
                        principalColumn: "LookupID");
                });

            migrationBuilder.CreateTable(
                name: "NotificationRecipient",
                columns: table => new
                {
                    NotificationRecipientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSubscribed = table.Column<bool>(type: "bit", nullable: false),
                    RecipientDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookupID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRecipient", x => x.NotificationRecipientID);
                    table.ForeignKey(
                        name: "FK_NotificationRecipient_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationRecipient_Lookup_LookupID",
                        column: x => x.LookupID,
                        principalTable: "Lookup",
                        principalColumn: "LookupID");
                });

            migrationBuilder.CreateTable(
                name: "TemplateColumns",
                columns: table => new
                {
                    TemplateColumnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    ColumnsID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateColumns", x => x.TemplateColumnID);
                    table.ForeignKey(
                        name: "FK_TemplateColumns_Columns_ColumnsID",
                        column: x => x.ColumnsID,
                        principalTable: "Columns",
                        principalColumn: "ColumnsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateColumns_Template_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "Template",
                        principalColumn: "TemplateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataRecipientType",
                columns: table => new
                {
                    RecipientTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRecipientRecipientID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRecipientType", x => x.RecipientTypeID);
                    table.ForeignKey(
                        name: "FK_DataRecipientType_DataRecipient_DataRecipientRecipientID",
                        column: x => x.DataRecipientRecipientID,
                        principalTable: "DataRecipient",
                        principalColumn: "RecipientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    CriteriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilterColumnValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TemplateColumnID = table.Column<int>(type: "int", nullable: false),
                    LookupID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.CriteriaID);
                    table.ForeignKey(
                        name: "FK_Criteria_Lookup_LookupID",
                        column: x => x.LookupID,
                        principalTable: "Lookup",
                        principalColumn: "LookupID");
                    table.ForeignKey(
                        name: "FK_Criteria_TemplateColumns_TemplateColumnID",
                        column: x => x.TemplateColumnID,
                        principalTable: "TemplateColumns",
                        principalColumn: "TemplateColumnID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationCheck = table.Column<bool>(type: "bit", nullable: true),
                    MinRecordRecordCountAlarm = table.Column<int>(type: "int", nullable: true),
                    MaxRecordRecordCountAlarm = table.Column<int>(type: "int", nullable: true),
                    MinRunDurationAlarm = table.Column<int>(type: "int", nullable: true),
                    MaxRunDurationAlarm = table.Column<int>(type: "int", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRecipientFailAlarm = table.Column<int>(type: "int", nullable: false),
                    NotificationRecipientFailAlarm = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CriteriaID = table.Column<int>(type: "int", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    FrequencyID = table.Column<int>(type: "int", nullable: false),
                    LookupID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Job_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Criteria_CriteriaID",
                        column: x => x.CriteriaID,
                        principalTable: "Criteria",
                        principalColumn: "CriteriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Frequency_FrequencyID",
                        column: x => x.FrequencyID,
                        principalTable: "Frequency",
                        principalColumn: "FrequencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_Lookup_LookupID",
                        column: x => x.LookupID,
                        principalTable: "Lookup",
                        principalColumn: "LookupID");
                    table.ForeignKey(
                        name: "FK_Job_Template_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "Template",
                        principalColumn: "TemplateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobLog",
                columns: table => new
                {
                    JobLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRunDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobRunDuration = table.Column<int>(type: "int", nullable: false),
                    ExtraxtSuccessFailure = table.Column<bool>(type: "bit", nullable: false),
                    NotificationRecipientSuccessFailure = table.Column<bool>(type: "bit", nullable: false),
                    RecordCount = table.Column<int>(type: "int", nullable: false),
                    DataRecipientSuccessFailure = table.Column<bool>(type: "bit", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLog", x => x.JobLogID);
                    table.ForeignKey(
                        name: "FK_JobLog_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobStatus",
                columns: table => new
                {
                    JobStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatus", x => x.JobStatusID);
                    table.ForeignKey(
                        name: "FK_JobStatus_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ColumnsID",
                table: "Categories",
                column: "ColumnsID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_OrgsOrganizationID",
                table: "Client",
                column: "OrgsOrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_LookupID",
                table: "Criteria",
                column: "LookupID");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_TemplateColumnID",
                table: "Criteria",
                column: "TemplateColumnID");

            migrationBuilder.CreateIndex(
                name: "IX_DataRecipient_ClientID",
                table: "DataRecipient",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_DataRecipient_LookupID",
                table: "DataRecipient",
                column: "LookupID");

            migrationBuilder.CreateIndex(
                name: "IX_DataRecipientType_DataRecipientRecipientID",
                table: "DataRecipientType",
                column: "DataRecipientRecipientID");

            migrationBuilder.CreateIndex(
                name: "IX_FrequencyDayOfWeek_FrequencyID",
                table: "FrequencyDayOfWeek",
                column: "FrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ClientID",
                table: "Job",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CriteriaID",
                table: "Job",
                column: "CriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_FrequencyID",
                table: "Job",
                column: "FrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_LookupID",
                table: "Job",
                column: "LookupID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_TemplateID",
                table: "Job",
                column: "TemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_JobLog_JobID",
                table: "JobLog",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_JobStatus_JobID",
                table: "JobStatus",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecipient_ClientID",
                table: "NotificationRecipient",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecipient_LookupID",
                table: "NotificationRecipient",
                column: "LookupID");

            migrationBuilder.CreateIndex(
                name: "IX_OrgLevel_OrganizationID",
                table: "OrgLevel",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Template_CategoryID",
                table: "Template",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateColumns_ColumnsID",
                table: "TemplateColumns",
                column: "ColumnsID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateColumns_TemplateID",
                table: "TemplateColumns",
                column: "TemplateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataRecipientType");

            migrationBuilder.DropTable(
                name: "FrequencyDayOfWeek");

            migrationBuilder.DropTable(
                name: "JobLog");

            migrationBuilder.DropTable(
                name: "JobStatus");

            migrationBuilder.DropTable(
                name: "NotificationRecipient");

            migrationBuilder.DropTable(
                name: "OrgLevel");

            migrationBuilder.DropTable(
                name: "DataRecipient");

            migrationBuilder.DropTable(
                name: "DayOfWeek");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "Frequency");

            migrationBuilder.DropTable(
                name: "Org");

            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "TemplateColumns");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Columns");
        }
    }
}
