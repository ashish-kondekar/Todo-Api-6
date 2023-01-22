using Microsoft.AspNetCore.Builder;

namespace TODO
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebApplication
                .CreateBuilder(args)
                .ConfigureAppServices()
                .ConfigureApp()
                .Run();
        }
    }
}
