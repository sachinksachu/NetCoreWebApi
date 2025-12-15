using NetCoreWebApi.Platform.Services.Extensions;
using NetCoreWebApi.Server.Extrensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomConfigurations(builder.Configuration);

builder.Services.AddControllers();// enable controllers

// Register services to the container
builder.Services.AddCustomServices();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapControllers(); // very important

app.Run();
