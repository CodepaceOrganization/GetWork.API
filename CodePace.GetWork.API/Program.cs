using CodePace.GetWork.API.Plans.Application.Internal;
using CodePace.GetWork.API.Plans.Domain.Repositories;
using CodePace.GetWork.API.Plans.Domain.Service;
using CodePace.GetWork.API.Plans.Infrastructure.Persistence.EFC;
using CodePace.GetWork.API.Shared.Domain.Repositories;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using CodePace.GetWork.API.Shared.Interfaces.ASP.Configuration;
using CodePace.GetWork.API.TechnicalEvaluation.Application.Internal.CommandServices;
using CodePace.GetWork.API.TechnicalEvaluation.Application.Internal.QueryServices;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Repositories;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Services;
using CodePace.GetWork.API.TechnicalEvaluation.Infrastructure.Persistence.EFC.Repositories;
//using CodePace.GetWork.API.TechnicalEvaluation.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DefaultNamespace;  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
        {
            if (builder.Environment.IsDevelopment())
            {
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
            else if (builder.Environment.IsProduction())
            {
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
            }
        }
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "CodePace.GetWork.API",
                Version = "v1",
                Description = "CodePace Get Work Platform API",
                TermsOfService = new Uri("https://codepace-getwork.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "CodePace",
                    Email = "contact@codepace.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Technical Evaluation Bounded Context Injection Configuration
builder.Services.AddScoped<ITechnicalTaskRepository, TechnicalTaskRepository>();
builder.Services.AddScoped<ITechnicalTestRepository, TechnicalTestRepository>();
builder.Services.AddScoped<ITechnicalTaskCommandService, TechnicalTaskCommandService>();
builder.Services.AddScoped<ITechnicalTaskQueryService, TechnicalTaskQueryService>();
builder.Services.AddScoped<ITechnicalTestQueryService, TechnicalTestQueryService>();

// Register Tutor services and repository
builder.Services.AddSingleton<ITutorRepository, TutorRepository>();
builder.Services.AddTransient<TutorCommandService>();
builder.Services.AddTransient<TutorQueryService>();

//Subscription services and repository
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();



var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
