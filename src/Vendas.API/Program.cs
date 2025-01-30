using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;
using Vendas.API.ApiExceptionHandler;
using Vendas.API.Extensions;
using Vendas.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry().WithTracing(b =>
{
    b.SetResourceBuilder(
        ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName))
     .AddAspNetCoreInstrumentation()
     .AddOtlpExporter(opts => { opts.Endpoint = new Uri("http://localhost:4317"); });
});

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .WriteTo.Seq("http://localhost:5341")
        .Enrich.FromLogContext();
});

builder.Services.AddDbContext<VendasDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDB")));

builder.Services.AddServicesCollection();

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
        ValidIssuer = "api",
        ValidAudience = "account",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("13e66a5a9db11cef6e34dda1587d8113b90dd6b2e0d1a66725f9bbca44279c67"))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddServicesCollection();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira um token válido",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
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
            new string[]{}
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetService<VendasDbContext>();
    context.Database.Migrate();
}

app.Run();
