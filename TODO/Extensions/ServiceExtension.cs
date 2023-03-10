using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TODO.BLL.IRepositories;
using TODO.BLL.IServices;
using TODO.BLL.Services;
using TODO.DAL.Repositories;
using TODO.Domain.Entities;

namespace TODO.Extensions
{
    public static class ServiceExtension
    {
        /// <summary>
        /// Used to add Services, Repositories and SwaggerUI
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Services
            services.AddTransient<ITodoService, TodoService>();

            // Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            // Configure Swagger/OpenAPI for the api
            // https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer().AddSwaggerGen();

            return services;
        }

        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Todo"));
            });

            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
             {
                 var key = Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"]);

                 jwt.SaveToken = true;
                 jwt.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = false, // false for dev
                     ValidateAudience = false, // false for dev
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateLifetime = true,
                     RequireExpirationTime = false
                 };
             });

            return services;
        }
    }
}
