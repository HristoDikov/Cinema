namespace Cinema.Server.Infrastructure
{
    using Data;
    using Data.Models;
    using Repositories;
    using Repositories.Contracts;
    using Domain.CinemaDomain.NewRoom;
    using Domain.CinemaDomainContracts;
    using Domain.CinemaDomain.NewMovie;
    using Domain.CinemaDomain.NewCinema;
    using Domain.CinemaDomain.NewTicket;
    using Domain.CinemaDomain.ReserveTicket;
    using Domain.CinemaDomain.NewProjection;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.OpenApi.Models;
    using System.Text;
    using Cinema.Server.Domain.CinemaDomain.BuyTicketWithReservation;

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
            services.AddTransient<IIdentityRepository, IdentityRepository>();
            services.AddTransient<ICinemaRepository, CinemaRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IProjectionRepository, ProjectionRepository>();
            services.AddTransient<ISeatRepository, SeatRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();

            services.AddTransient<INewCinema, NewCinemaCreation>();
            services.Decorate<INewCinema, NewCinemaUniqueValidation>();

            services.AddTransient<INewRoom, NewRoomCreation>();
            services.Decorate<INewRoom, NewRoomUniqueValidation>();
            services.Decorate<INewRoom, NewRoomCinemaValidation>();

            services.AddTransient<INewMovie, NewMovieCreation>();
            services.Decorate<INewMovie, NewMovieUniqueValidation>();

            services.AddTransient<INewProjection, NewProjectionSeatCreation>();
            services.Decorate<INewProjection, NewProjectionCreation>();
            services.Decorate<INewProjection, NewProjectionMovieValidation>();
            services.Decorate<INewProjection, NewProjectionRoomValidation>();
            services.Decorate<INewProjection, NewProjectionUniqueValidation>();
            services.Decorate<INewProjection, NewProjectionPreviousOverlapValidation>();
            services.Decorate<INewProjection, NewProjectionNextOverlapValidation>();

            services.AddTransient<INewTicket, NewTicketCreation>();
            services.Decorate<INewTicket, NewTicketIsNotBoughtOrBookedValidation>();
            services.Decorate<INewTicket, NewTicketSeatValidation>();
            services.Decorate<INewTicket, NewTicketRoomValidation>();
            services.Decorate<INewTicket, NewTicketProjectionValidation>();

            services.AddTransient<ITicketReservation, TicketReservation>();
            services.Decorate<ITicketReservation, TicketReservationIsNotBoughtOrBookedValdiation>();
            services.Decorate<ITicketReservation, TicketReservationProjectionHasNotStartedValidation>();
            services.Decorate<ITicketReservation, TicketReservationSeatValidation>();
            services.Decorate<ITicketReservation, TicketReservationRoomValidation>();
            services.Decorate<ITicketReservation, TicketReservationProjectionValidation>();

            services.AddTransient<IBuyTicketWithReservation, BuyTicketWithReservationReturnBoughtTicket>();
            services.Decorate<IBuyTicketWithReservation, BuyTicketWithReservation>();
            services.Decorate<IBuyTicketWithReservation, BuyTicketWithReservationStartTimeValidation>();
            services.Decorate<IBuyTicketWithReservation, BuyTicketWithReservationNotBoughtValidation>();

            services.AddHostedService<BackgroundRepository>();

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
