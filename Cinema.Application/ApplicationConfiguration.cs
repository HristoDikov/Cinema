namespace Cinema.Application
{
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
          this IServiceCollection services,
          IConfiguration configuration)
          => services
              .Configure<ApplicationSettings>(
                  configuration.GetSection(nameof(ApplicationSettings)),
                  options => options.BindNonPublicProperties = true)
               .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
