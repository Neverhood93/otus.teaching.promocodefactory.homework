using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Implementations;
using Otus.Teaching.PromoCodeFactory.WebHost.Models;
using Services.Repositories.Abstractions;
using WebApi.Settings;

namespace WebApi
{
    /// <summary>
    /// Регистратор сервиса.
    /// </summary>
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                    .AddSingleton((IConfigurationRoot)configuration)
                    .InstallServices()
                    .ConfigureContext(applicationSettings.ConnectionString)
                    .InstallRepositories();
            //services.AddSingleton(typeof(IRepository<Employee>), (x) =>
            //    new InMemoryRepository<Employee>(FakeDataFactory.Employees));
            //services.AddSingleton(typeof(IRepository<Role>), (x) =>
            //    new InMemoryRepository<Role>(FakeDataFactory.Roles));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddSingleton<EmployeeHelper>();

            services.AddScoped<IDataInitializer, EFDataInitializer>();

            return services;
        }

        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection
            //.AddTransient<ICourseService, CourseService>()
            //    .AddTransient<ILessonService, LessonService>();
            return serviceCollection;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            //serviceCollection
            //    .AddTransient<ICourseRepository, CourseRepository>()
            //    .AddTransient<ILessonRepository, LessonRepository>();
            return serviceCollection;
        }
    }
}