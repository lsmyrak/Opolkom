using Infrastructure.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Extentions;

var builder = WebApplication.CreateBuilder(args);
var authenticationSetting = new AuthenticationSetting();

builder.Configuration.GetSection("AuthenticationSetting").Bind(authenticationSetting);
builder.Services.AddSingleton(authenticationSetting);
builder.Services.AddOtherServices();

builder.Services.AddDbContext<DataContext>(options => options
  .UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")).UseSnakeCaseNamingConvention()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging());

builder.Services.AddControllers();

builder.Services.AddSwagger();

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", c =>
{
    c.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod();
}));


var app = builder.Build();

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
