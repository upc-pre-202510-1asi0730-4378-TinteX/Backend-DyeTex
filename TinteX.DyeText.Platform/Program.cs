using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TinteX.DyeText.Platform.machine_monitoring.Application.Internal.CommandServices;
using TinteX.DyeText.Platform.machine_monitoring.Application.Internal.QueryServices;
using TinteX.DyeText.Platform.machine_monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.machine_monitoring.Domain.Services;
using TinteX.DyeText.Platform.machine_monitoring.Infrastructure.Repositories;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection String
if (connectionString is null)
    // Stop the application if the connection string is not set.
    throw new Exception("Database connection string is not set.");


// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});
    

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "TinTeX.DyeTex.API",
            Version = "v1",
            Description = "TinteX DyeTex Platform API",
            TermsOfService = new Uri("https://tintex-dyetex.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "Tintex Studios",
                Email = "contact@acme.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0")
            },
        });
    options.EnableAnnotations();
});


// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy", 
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration
builder.Services.AddScoped<ITextileMachineRepository, TextileMachineRepository>();
builder.Services.AddScoped<ITextileMachineCommandService, TextileMachineCommandService>();
builder.Services.AddScoped<ITextileMachineQueryService, TextileMachineQueryService>();

// Shared Bounded Context
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();