using Antheap_1_task_net_react.Extensions;

namespace Antheap_1_task_net_react
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            builder.Services.AddControllersWithViews();
            builder.Services.ConfigureServices();
            builder.Services.ConfigureDatabase(configuration);
            builder.Services.ConfigureAutoMapper();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}