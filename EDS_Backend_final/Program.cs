using EDS_Backend_final.DataAccess;
using EDS_Backend_final.DataContext;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsBuilder =>
        {
            sqlServerOptionsBuilder.EnableRetryOnFailure(
                maxRetryCount: 5, // The maximum number of retry attempts
                maxRetryDelay: TimeSpan.FromSeconds(30), // The maximum delay between retries
                errorNumbersToAdd: null // List of specific error numbers to consider transient
            );
        });
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//category
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<CategoryDAL>();

// organization
builder.Services.AddTransient<IOrganizationService, OrganizationService>();
builder.Services.AddTransient<OrganizationDAL>();

//client
builder.Services.AddTransient<ClientDAL>();
builder.Services.AddTransient<IClientService, ClientService>();

//column
builder.Services.AddTransient<ColumnDAL>();
builder.Services.AddTransient<IColumnService, ColumnsService>();

//Criteria
builder.Services.AddTransient<CriteriaDAL>();
builder.Services.AddTransient<ICriteriaService, CriteriaService>();

//Data Recipient
builder.Services.AddTransient<DataRecipientDAL>();
builder.Services.AddTransient<IDataRecipientService, DataRecipientService>();

//Frequency
builder.Services.AddTransient<FrequencyDAL>();
builder.Services.AddTransient<IFrequencyService, FrequencyService>();

//JobLog
builder.Services.AddTransient<JobLogDAL>();
builder.Services.AddTransient<IJobLogService, JobLogService>();

//JOb
builder.Services.AddTransient<JobDAL>();
builder.Services.AddTransient<IJobService, JobService>();

//JOb Status
builder.Services.AddTransient<JobStatusDAL>();
builder.Services.AddTransient<IJobStatusService, JobStatusService>();

//Lookup
builder.Services.AddTransient<LookupDAL>();
builder.Services.AddTransient<ILookupService, LookupService>();

//NotificationRecipient
builder.Services.AddTransient<NotificationRecipientDAL>();
builder.Services.AddTransient<INotificationRecipientService, NotificationRecipientService>();

//org level
builder.Services.AddTransient<OrgLevelDAL>();
builder.Services.AddTransient<IOrgLevelService, OrgLevelService>();

//temp cols
builder.Services.AddTransient<TemplateColDAL>();
builder.Services.AddTransient<ITemplateColsService, TemplateColumnsService>();

//template
builder.Services.AddTransient<TemplateDAL>();
builder.Services.AddTransient<ITemplateService, TemplateService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.MaxDepth = 32; // Adjust the depth as needed
});

var app = builder.Build();
//app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); //allowing angular app to talk to api

app.UseAuthorization();

app.MapControllers();

app.Run();
