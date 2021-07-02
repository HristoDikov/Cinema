namespace Cinema.Server.Infrastructure
{
    using Data;
    using Data.Models;
    using Repositories;
    using Services.Implementations;
    using Services.Contracts;
    using Domain.Contracts;
    using Domain.Domain.NewCinema;
    using Domain.Domain.NewRoom;
    using Domain.Domain.NewMovie;
    using Domain.Domain.NewProjection;
    using Domain.Domain.BuyTicket;
    using Domain.Domain.ReserveTicket;
    using Domain.Domain.BuyTicketWithReservation;

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
            services.AddTransient<ICinemaService, CinemaService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IProjectionService, ProjectionService>();
            services.AddTransient<ISeatService, SeatService>();
            services.AddTransient<ITicketService, TicketService>();

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

            services.AddTransient<IBuyTicket, BuyTicket>();
            services.Decorate<IBuyTicket, TicketsSeatIsNotBoughtOrBookedValidation>();
            services.Decorate<IBuyTicket, TicketsSeatValidation>();
            services.Decorate<IBuyTicket, TicketRoomValidation>();
            services.Decorate<IBuyTicket, TicketProjectionValidation>();

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

            services.AddHostedService<BackgroundService>();

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
