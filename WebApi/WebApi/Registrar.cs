using AutoMapper;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Implementations;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories.Abstractions;
using WebApi.Settings;
using Services.Implementations.Mapping;
using WebApi.Mapping;

namespace WebApi
{
    /// <summary>
    /// Регистратор сервиса.
    /// </summary>
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            InstallAutomapper(services);

            var applicationSettings = configuration.Get<ApplicationSettings>();

            services.AddSingleton(applicationSettings)
                    .AddSingleton((IConfigurationRoot)configuration)
                    .InstallServices()
                    .ConfigureContext(applicationSettings.ConnectionString)
                    .InstallRepositories()
                    .AddScoped<IDataInitializer, EFDataInitializer>();

            return services;
        }

        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IEmployeeService, EmployeeService>()
                .AddTransient<IRoleService, RoleService>();
            return serviceCollection;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<IRoleRepository, RoleRepository>();
            return serviceCollection;
        }

        private static IServiceCollection InstallAutomapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<EmployeeMappingsProfileController>();
                config.AddProfile<RoleMappingsProfileController>();
                config.AddProfile<EmployeeMappingsProfile>();
                config.AddProfile<RoleMappingsProfile>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}