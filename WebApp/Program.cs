using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using EvolveDb;
using Serilog;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApp.Shared.Configurations;
using WebApp.Application.Hypermedia.Filters;
using WebApp.Application.Extensions;
using WebApp.Infrastructure.Extensions;
using WebApp.Model.Context;
using Asp.Versioning;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Security.Claims;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

var appName = "API - Rota Bioceânica";
var appVersion = "v1";
var descricao = "API Desenvolvida por Gabriel Sanz para o Sistema da Rota Bioceânica";

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var tokenConfigurations = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(
    builder.Configuration.GetSection("TokenConfiguration"))
    .Configure(tokenConfigurations);

builder.Services.AddSingleton(tokenConfigurations);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfigurations.Issuer,
        ValidAudience = tokenConfigurations.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret)),
        NameClaimType = ClaimTypes.NameIdentifier
    };

    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json; charset=utf-8";
            var result = new { message = "Você não está autenticado." };
            return context.Response.WriteAsJsonAsync(result);
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json; charset=utf-8";
            var result = new { message = "Você não tem permissão necessária para acessar este endpoint." };
            return context.Response.WriteAsJsonAsync(result);
        }
    };
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());

    auth.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    auth.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true; 
    options.DefaultApiVersion = new ApiVersion(1, 0); 
    options.ReportApiVersions = true; 
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); 
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(appVersion, new OpenApiInfo
    {
        Title = appName,
        Version = appVersion,
        Description = descricao,
        Contact = new OpenApiContact
        {
            Name = "Gabriel Sanz",
            Url = new Uri("https://github.com/GabrielSelim")
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor insira o token JWT com o prefixo 'Bearer '",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

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
            new string[] {}
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.ExampleFilters();
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<ErrorResponseExample>();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 36))
    ));

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

builder.Services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
}).AddXmlSerializerFormatters();

var filterOptions = new HyperMediaFilterOptions();
builder.Services.AddEnrichers(filterOptions);
builder.Services.AddSingleton(filterOptions);

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddBusinessServices();

builder.Services.AddServices();

builder.Services.AddInfrastructureRepositories();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var originalBody = context.Response.Body;
    using var memStream = new MemoryStream();
    context.Response.Body = memStream;

    await next();

    if (context.Response.StatusCode == 400 && context.Response.ContentType != null && context.Response.ContentType.Contains("application/problem+json"))
    {
        context.Response.Body = originalBody;
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;

        var mensagem = "O valor informado para o campo Juros é inválido. Informe um número decimal usando ponto, por exemplo: 5.8 .";

        await context.Response.WriteAsJsonAsync(new { mensagem });
    }
    else
    {
        memStream.Seek(0, SeekOrigin.Begin);
        await memStream.CopyToAsync(originalBody);
        context.Response.Body = originalBody;
    }
});

app.UseHttpsRedirection();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/{appVersion}/swagger.json", $"{appName} - {appVersion}");
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

var options = new RewriteOptions();
options.AddRedirect("^$", "swagger");
app.UseRewriter(options);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute("DefaultApi", "v{version:apiVersion}/{controller=values}/{id?}");

app.Run();

void MigrateDatabase(string? connection)
{
    try
    {
        var envolveConnection = new MySqlConnection(connection);
        var envolve = new Evolve(envolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        envolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}
public class RemoveVersionFromParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "version");
        if (versionParameter != null)
        {
            operation.Parameters.Remove(versionParameter);
        }
    }
}

public class ReplaceVersionWithExactValueInPath : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = new OpenApiPaths();
        foreach (var (key, value) in swaggerDoc.Paths)
        {
            paths.Add(key.Replace("v{version}", swaggerDoc.Info.Version), value);
        }
        swaggerDoc.Paths = paths;
    }
}