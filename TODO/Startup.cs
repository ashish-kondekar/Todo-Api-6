using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TODO.Domain.Entities;
using TODO.Extensions;

public static class Startup
{
    /// <summary>
    /// Configure application services and build
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplication ConfigureAppServices(this WebApplicationBuilder builder)
    {
        // Add app services
        builder.Services.AddBLLServices();
        builder.Services.AddDALServices();
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // Configure Swagger for the api
        builder.Services.AddEndpointsApiExplorer(); //Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen();

        // Database configuration
        builder.Services.AddDbContext<TodoDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Todo"));
        });

        return builder.Build();
    }

    /// <summary>
    /// Configure app settings
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static WebApplication ConfigureApp(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
