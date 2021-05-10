namespace Cinema.Server.Infrastructure
{
    using Cinema.Server.Services.Contracts;
    using Domain.CinemaDomain.NewCinema;
    using Domain.CinemaDomain.NewMovie;
    using Domain.CinemaDomainContracts;
    using Domain.CinemaDomain.NewRoom;
    using Cinema.Server.Services;
    using Data.Models;
    using Data;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.OpenApi.Models;
    using System.Text;

    public static class ServiceCollectionExtensions
    {
        public static ApplicationSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(applicationSettingConfig);

            var appSettings = applicationSettingConfig.Get<ApplicationSettings>();

            return appSettings;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                   .AddEntityFrameworkStores<CinemaDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, ApplicationSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICinemaRepository, CinemaRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();

            services.AddTransient<INewCinema, NewCinemaCreation>();
            services.Decorate<INewCinema, NewCinemaUniqueValidation>();

            services.AddTransient<INewRoom, NewRoomCreation>();
            services.Decorate<INewRoom, NewRoomUniqueValidation>();
            services.Decorate<INewRoom, NewRoomCinemaValidation>();

            services.AddTransient<INewMovie, NewMovieCreation>();
            services.Decorate<INewMovie, NewMovieUniqueValidation>();

            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "My Cinema API",
                        Version = "v1"
                    });
            });
    }
}
