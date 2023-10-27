﻿// <auto-generated />
using System;
using EDS_Backend_final.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DayOfWeekFrequency", b =>
                {
                    b.Property<int>("DaysOfWeekDayOfWeekId")
                        .HasColumnType("int");

                    b.Property<int>("FrequencyID")
                        .HasColumnType("int");

                    b.HasKey("DaysOfWeekDayOfWeekId", "FrequencyID");

                    b.HasIndex("FrequencyID");

                    b.ToTable("FrequencyDayOfWeek", (string)null);
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CategoryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ClientCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrgsOrganizationID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.HasIndex("OrgsOrganizationID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Columns", b =>
                {
                    b.Property<int>("ColumnsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColumnsID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ColumnCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColumnsID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Criteria", b =>
                {
                    b.Property<int>("CriteriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CriteriaID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilterColumnValue")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("LookupID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TemplateColumnID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CriteriaID");

                    b.HasIndex("LookupID");

                    b.HasIndex("TemplateColumnID");

                    b.ToTable("Criteria");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.DataRecipient", b =>
                {
                    b.Property<int>("RecipientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipientID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DataRecipientTypeRecipientTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("LookupID")
                        .HasColumnType("int");

                    b.Property<int?>("RecipientTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipientID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DataRecipientTypeRecipientTypeID");

                    b.HasIndex("LookupID");

                    b.ToTable("DataRecipient");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.DataRecipientType", b =>
                {
                    b.Property<int>("RecipientTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipientTypeID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipientTypeID");

                    b.ToTable("DataRecipientType");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.DayOfWeek", b =>
                {
                    b.Property<int>("DayOfWeekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayOfWeekId"));

                    b.Property<int>("DayValue")
                        .HasColumnType("int");

                    b.HasKey("DayOfWeekId");

                    b.ToTable("DayOfWeek");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.FileFormat", b =>
                {
                    b.Property<int>("FileFormatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileFormatID"));

                    b.Property<string>("FileFormatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FileFormatID");

                    b.ToTable("FileFormat");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Frequency", b =>
                {
                    b.Property<int>("FrequencyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FrequencyID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DateOfMonth")
                        .HasColumnType("int");

                    b.Property<string>("FrequencyType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FrequencyID");

                    b.ToTable("Frequency");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CriteriaID")
                        .HasColumnType("int");

                    b.Property<int>("DataRecipientID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FileFormatID")
                        .HasColumnType("int");

                    b.Property<int>("FrequencyID")
                        .HasColumnType("int");

                    b.Property<string>("JobType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LookupID")
                        .HasColumnType("int");

                    b.Property<int?>("MaxRecordCountAlarm")
                        .HasColumnType("int");

                    b.Property<int?>("MaxRunDurationAlarm")
                        .HasColumnType("int");

                    b.Property<int?>("MinRecordCountAlarm")
                        .HasColumnType("int");

                    b.Property<int?>("MinRunDurationAlarm")
                        .HasColumnType("int");

                    b.Property<bool?>("NotificationCheck")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TemplateID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobID");

                    b.HasIndex("CriteriaID");

                    b.HasIndex("FrequencyID");

                    b.HasIndex("LookupID");

                    b.HasIndex("TemplateID");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.JobLog", b =>
                {
                    b.Property<int>("JobLogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobLogID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DataRecipientSuccessFailure")
                        .HasColumnType("bit");

                    b.Property<bool>("ExtraxtSuccessFailure")
                        .HasColumnType("bit");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobRunDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobRunDuration")
                        .HasColumnType("int");

                    b.Property<bool>("NotificationRecipientSuccessFailure")
                        .HasColumnType("bit");

                    b.Property<int>("RecordCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobLogID");

                    b.HasIndex("JobID");

                    b.ToTable("JobLog");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.JobStatus", b =>
                {
                    b.Property<int>("JobStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobStatusID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<string>("JobStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobStatusID");

                    b.HasIndex("JobID");

                    b.ToTable("JobStatus");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Lookup", b =>
                {
                    b.Property<int>("LookupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LookupID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HiddenValue")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LookupType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisibleValue")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("LookupID");

                    b.ToTable("Lookup");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.NotificationRecipient", b =>
                {
                    b.Property<int>("NotificationRecipientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationRecipientID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.Property<int?>("LookupID")
                        .HasColumnType("int");

                    b.Property<string>("RecipientDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationRecipientID");

                    b.HasIndex("ClientID");

                    b.HasIndex("LookupID");

                    b.ToTable("NotificationRecipient");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Org", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentOrganizationCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ParentOrganizationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Org");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.OrgLevel", b =>
                {
                    b.Property<int>("OrganizationLevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationLevelID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationLevelID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("OrgLevel");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Template", b =>
                {
                    b.Property<int>("TemplateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Template");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.TemplateColumns", b =>
                {
                    b.Property<int>("TemplateColumnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateColumnID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ColumnsID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateColumnID");

                    b.HasIndex("ColumnsID");

                    b.HasIndex("TemplateID");

                    b.ToTable("TemplateColumns");
                });

            modelBuilder.Entity("EDS_Backend_final.ViewModels.CategoryViewModel", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CategoryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CategoryID");

                    b.ToTable("CategoriesVM");
                });

            modelBuilder.Entity("EDS_Backend_final.ViewModels.OrgVM", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationID"));

                    b.Property<string>("OrganizationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentOrganizationCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ParentOrganizationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationID");

                    b.ToTable("OrgVM");
                });

            modelBuilder.Entity("DayOfWeekFrequency", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.DayOfWeek", null)
                        .WithMany()
                        .HasForeignKey("DaysOfWeekDayOfWeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_Backend_final.Models.Frequency", null)
                        .WithMany()
                        .HasForeignKey("FrequencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Client", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Org", "Orgs")
                        .WithMany("Clients")
                        .HasForeignKey("OrgsOrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orgs");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Columns", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Category", "Category")
                        .WithMany("Columns")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Criteria", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Lookup", "Lookup")
                        .WithMany("Criterias")
                        .HasForeignKey("LookupID");

                    b.HasOne("EDS_Backend_final.Models.TemplateColumns", "TemplateColumn")
                        .WithMany("Criterias")
                        .HasForeignKey("TemplateColumnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lookup");

                    b.Navigation("TemplateColumn");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.DataRecipient", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("EDS_Backend_final.Models.DataRecipientType", "DataRecipientType")
                        .WithMany("DataRecipient")
                        .HasForeignKey("DataRecipientTypeRecipientTypeID");

                    b.HasOne("EDS_Backend_final.Models.Lookup", "Lookup")
                        .WithMany("DataRecipients")
                        .HasForeignKey("LookupID");

                    b.Navigation("Client");

                    b.Navigation("DataRecipientType");

                    b.Navigation("Lookup");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Job", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Criteria", null)
                        .WithMany("Jobs")
                        .HasForeignKey("CriteriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_Backend_final.Models.Frequency", null)
                        .WithMany("Jobs")
                        .HasForeignKey("FrequencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_Backend_final.Models.Lookup", null)
                        .WithMany("Jobs")
                        .HasForeignKey("LookupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_Backend_final.Models.Template", null)
                        .WithMany("Jobs")
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EDS_Backend_final.Models.JobLog", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.JobStatus", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.NotificationRecipient", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_Backend_final.Models.Lookup", "Lookup")
                        .WithMany("NotificationRecipients")
                        .HasForeignKey("LookupID");

                    b.Navigation("Client");

                    b.Navigation("Lookup");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.OrgLevel", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Org", "Org")
                        .WithMany("Levels")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Org");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Template", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Category", "Category")
                        .WithMany("Templates")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.TemplateColumns", b =>
                {
                    b.HasOne("EDS_Backend_final.Models.Columns", "Column")
                        .WithMany("TemplateColumns")
                        .HasForeignKey("ColumnsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDS_Backend_final.Models.Template", "Template")
                        .WithMany("TemplateColumns")
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Category", b =>
                {
                    b.Navigation("Columns");

                    b.Navigation("Templates");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Columns", b =>
                {
                    b.Navigation("TemplateColumns");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Criteria", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.DataRecipientType", b =>
                {
                    b.Navigation("DataRecipient");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Frequency", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Lookup", b =>
                {
                    b.Navigation("Criterias");

                    b.Navigation("DataRecipients");

                    b.Navigation("Jobs");

                    b.Navigation("NotificationRecipients");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Org", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Levels");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.Template", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("TemplateColumns");
                });

            modelBuilder.Entity("EDS_Backend_final.Models.TemplateColumns", b =>
                {
                    b.Navigation("Criterias");
                });
#pragma warning restore 612, 618
        }
    }
}
