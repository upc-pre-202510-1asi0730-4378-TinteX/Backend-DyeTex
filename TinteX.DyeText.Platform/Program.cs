using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// ARM
using ServiceDesing.Application.Internal.CommandServices;
using TinteX.DyeText.Platform.ARM.Application.Internal.CommandServices;
using TinteX.DyeText.Platform.ARM.Application.Internal.QueryServices;
using TinteX.DyeText.Platform.ARM.Infrastructure.Persistence.EFC.Repositories;

// ServiceDesign_Planning
using TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.QueryServices;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Repositories;

// Shared
using TinteX.DyeText.Platform.Shared.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration;

// Analytics
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;
using TinteX.DyeText.Platform.Analytics.Domain.Services;
using TinteX.DyeText.Platform.Analytics.Infrastructure.Repositories;
using TinteX.DyeText.Platform.Analytics.Application.Internal.QueryServices;
using TinteX.DyeText.Platform.Analytics.Application.Internal.CommandServices;

// Monitoring
using TinteX.DyeText.Platform.Monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.Monitoring.Domain.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null) throw new InvalidOperationException("Connection string not found");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    else
        options.UseMySQL(connectionString)
               .LogTo(Console.WriteLine, LogLevel.Error);
});

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TinTeX.DyeTex.API",
        Version = "v1",
        Description = "TinteX DyeTex Platform API",
        TermsOfService = new Uri("https://tintex-dyetex.com/tos"),
        Contact = new OpenApiContact { Name = "Tintex Studios", Email = "contact@acme.com" },
        License = new OpenApiLicense { Name = "Apache 2.0", Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0") }
    });
    options.EnableAnnotations();
});

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ARM Bounded Context
builder.Services.AddScoped<ITextileMachineRepository, TextileMachineRepository>();
builder.Services.AddScoped<ITextileMachineCommandService, TextileMachineCommandService>();
builder.Services.AddScoped<ITextileMachineQueryService, TextileMachineQueryService>();

builder.Services.AddScoped<IMachineInformationRepository, MachineInformationRepository>();
builder.Services.AddScoped<IMachineInformationCommandService, MachineInformationCommandService>();
builder.Services.AddScoped<IMachineInformationQueryService, MachineInformationQueryService>();

builder.Services.AddScoped<IDeviceConfigurationRepository, DeviceConfigurationRepository>();
builder.Services.AddScoped<IDeviceConfigurationCommandService, DeviceConfigurationCommandService>();
builder.Services.AddScoped<IDeviceConfigurationQueryService, DeviceConfigurationQueryService>();

// ServiceDesign_Planning Bounded Context - Tasks
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskCommandService, TaskCommandService>();
builder.Services.AddScoped<ITaskQueryService, TaskQueryService>();

// Analytics Bounded Context
builder.Services.AddScoped<IMachineFailureCountRepository, MachineFailureCountRepository>();
builder.Services.AddScoped<IFailureCountCommandService, FailuresCountCommandService>();
builder.Services.AddScoped<IMachinesFailureCountQueryService, FailuresCountQueryService>();

builder.Services.AddScoped<IMachineFailureRateRepository, MachineFailureRateRepository>();
builder.Services.AddScoped<IMachineFailureRateQueryService, FailureRateQueryService>();
builder.Services.AddScoped<IFailureRateCommandService, FailureRateCommandService>();

var app = builder.Build();

// Ensure DB Created / Migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowAllPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
