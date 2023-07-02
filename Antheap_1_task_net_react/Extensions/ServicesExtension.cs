using Antheap_1_task_net_react.Data.Contexts;
using Antheap_1_task_net_react.Data.Repositories;
using Antheap_1_task_net_react.Operations;
using Antheap_1_task_net_react.Profiles;
using Antheap_1_task_net_react.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Antheap_1_task_net_react.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<ICompanyOperation, CompanyOperation>();
        }

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("AntheapTask1")));
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<RepresentativeProfile>();
                config.AddProfile<PersonProfile>();
                config.AddProfile<CompanyProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
