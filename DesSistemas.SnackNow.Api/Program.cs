using DesSistemas.SnackNow.Api.Domain;
using DesSistemas.SnackNow.Api.Domain.Context;
using DesSistemas.SnackNow.Startup.Configuration;
using DesSistemas.SnackNow.Startup.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SnackNow API",
        Version = "v1",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-1dzgnv8qfcf6gj62.us.auth0.com";
    options.Audience = "https://dev-1dzgnv8qfcf6gj62.us.auth0.com/api/v2/";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier,
    };
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddAppDependency();
builder.Services.AddStartupDependency();

// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    x.RoutePrefix = string.Empty;
});
app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("http://localhost:3000"));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();

using var scope = app.Services.CreateScope();
using var ctx = scope.ServiceProvider.GetService<SnackNowApiContext>();
ctx!.Migrate();

app.Run();