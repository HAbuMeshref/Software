using Repository.Interfaces;
using Service.Interfaces;
using Service.UnitOfWork;
using Repository.UnitOfWork;
using System.Text.Json.Serialization;
using System.Text.Json;
using Service.Services;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Domain.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using System.Microservices.Core;
using Serilog;
using API.Handler;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddCors();
builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Register IHttpClientFactory
builder.Services.AddHttpClient();

builder.Services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();
builder.Services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
builder.Services.AddScoped<ILookupService, LookupService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient("")
    .AddHttpMessageHandler<AuthenticationDelegatingHandler>();

#region Configuration
var configuration = builder.Configuration;

#region SharedSettings
SharedSettings.JwtExpireDays = configuration.GetSection("SharedSettings").GetValue<int>("JwtExpireDays");
SharedSettings.Secret = configuration.GetSection("SharedSettings").GetValue<string>("Secret");
SharedSettings.ConnectionString = configuration.GetSection("SharedSettings").GetValue<string>("ConnectionString");

#endregion

// Add services to the container.


#region Database Context    
//switch ((DatabaseType)SharedSettings.DatabaseType)
//{

// case DatabaseType.Oracle:
builder.Services.AddDbContext<InventoryManagDbContext>(options =>
    options.UseSqlite("Data Source=C:\\Users\\h.abumeshref\\source\\repos\\Inventory Management\\Happy Company.db")
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
//  break;

//}
#endregion
#endregion
;



#region Swagger

#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.CustomSchemaIds(type => type.ToString());
    option.UseInlineDefinitionsForEnums();
});


// Add Swagger and configure JWT authorization in Swagger
builder.Services.AddSwaggerGen(c =>
{
    // Add Bearer token to Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and your JWT token."
    });

    // Add security requirement to the Swagger UI
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
#endregion
#endregion;

#region ~ JWT ~

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
        
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretunguessablekeyhdfhdjdskjbjdfsbddsfdffdsfdfsfdsddsdfsdsfdfsdfss")),
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
     };
 });


// Add services to the container (controllers, etc.)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#endregion


#region Serilog
Log.Logger = new LoggerConfiguration()
             .WriteTo.Console()  // Optionally log to console for debugging
             .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)  // Log to a file
             .CreateLogger();

builder.Logging.AddSerilog();
builder.Services.AddHostedService<LoggingWorker>();


#endregion


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Use authentication and authorization middlewares
app.UseAuthentication(); // Ensure this is before UseAuthorization
app.UseAuthorization(); // Ensure this is after UseAuthentication





app.MapControllers();

app.Run();



