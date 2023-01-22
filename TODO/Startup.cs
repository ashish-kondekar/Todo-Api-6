using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TODO.ServiceExtensions;

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
        builder.Services.AddControllers();

        builder.Services
            .AddServices()
            .AddDbContexts(builder.Configuration)
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddSwaggerUI(builder.Configuration);

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
