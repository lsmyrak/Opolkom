using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI;
using WebAPI.Extentions;

var builder = WebApplication.CreateBuilder(args);
var authenticationSetting = new AuthenticationSetting();

builder.Configuration.GetSection("Authentication").Bind(authenticationSetting);
builder.Services.AddSingleton(authenticationSetting);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSetting.JwtIssuer,
        ValidAudience = authenticationSetting.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSetting.JwtKey))
    };
});
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
