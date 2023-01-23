using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using TODO.Extensions;
using TODO.Middlewares;

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

        // Add logging configuration services
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();

        // Add Todo sepecific services
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
            app.UseMiddleware<ExceptionMiddleware>();
            //app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
