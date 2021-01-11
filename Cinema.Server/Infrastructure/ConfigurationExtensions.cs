namespace Cinema.Server.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
        => configuration.GetConnectionString("DefaultConnection");

        public static ApplicationSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration) 
        {
            var applicationSettingConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(applicationSettingConfig);

            var appSettings = applicationSettingConfig.Get<ApplicationSettings>();

            return appSettings;
        }
    }
}
