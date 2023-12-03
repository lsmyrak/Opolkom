using Contracts.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

namespace WebAPI.Extentions
{
    public static class ServiceCollectionExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWT_Token_API",
                    Version = "v1",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Description",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                             {
                                Reference = new OpenApiReference
                                    {
                                        Type= ReferenceType.SecurityScheme,
                                        Id="Bearer"
                                    },
                            }, new string[] { }
                        }
                 });
            });         
        }
        public static void AddRepositories(this IServiceCollection services)
        {

        }

        public static void AddServices(this IServiceCollection services)
        {

        }

        public static void AddOtherServices(this IServiceCollection services)
        {
           services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
           services.AddScoped<IPasswordHasher<RegisterUserDto>, PasswordHasher<RegisterUserDto>>();
        }
    }
}
