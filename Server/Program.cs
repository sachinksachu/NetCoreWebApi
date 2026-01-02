using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NetCoreWebApi.Platform.Services.Extensions;
using NetCoreWebApi.Server.Extensions;
using NetCoreWebApi.Server.Extrensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("a-string-secret-at-least-256-bits-long"))
        };
    });

services.AddCustomConfigurations(builder.Configuration);

services.AddControllers(); // enable controllers

// Register services to the container
services.AddCustomServices();
//Compiler internally translates to:
//ServiceExtensionHandler.AddCustomServices(services);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

services.ConfigureSwagger();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//If middleware needs to know WHICH endpoint is being executed → UseRouting is required.
app.UseRouting();

app.UseRequestLogging();

//When a request arrives:
//Finds the default authentication scheme
//Runs the scheme’s authentication handler
//Reads credentials (JWT, cookie, etc.)
//Validates credentials
//Creates a ClaimsPrincipal
//Assigns it to: HttpContext.User
app.UseAuthentication();

//Endpoint metadata contains [Authorize]
//Authorization middleware sees it
//It checks:HttpContext.User.Identity.IsAuthenticated
app.UseAuthorization();

app.UseAuthenticationMiddleware();

// Routing + endpoints
//In .NET 6+, UseRouting() and UseEndpoints() are implicitly added when you use MapControllers() or Minimal APIs.
app.MapControllers();

app.Run();
