using Microsoft.Extensions.DependencyInjection;
using TODO.BLL.IRepositories;
using TODO.BLL.IServices;
using TODO.BLL.Services;
using TODO.DAL.Repositories;

namespace TODO.Extensions
{
    public static class ServiceExtension
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddTransient<ITodoService, TodoService>();
        }

        public static void AddDALServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
