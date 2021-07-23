namespace Cinema.Infrastructure.Configurations
{
    using Application;
    using Persistance;
    using Implementations;
    using Persistance.Models;
    using Application.Contracts.Services;
    using Application.Features.Cinema.Commands.CreateCinema;
    using Application.Features.Projection.Commands.CreateProjection;
    using Application.Features.Cinema.Commands.CreateCinema.Validations;
    using Application.Features.Projection.Commands.CreateProjection.Validations;

    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using FluentValidation.AspNetCore;
    using Microsoft.OpenApi.Models;
    using Cinema.Application.Features.Movie.Commands.CreateMovie;
    using Cinema.Application.Features.Movie.Commands.CreateMovie.Validators;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                   .AddIdentity<User, IdentityRole>(options =>
                   {
                       options.Password.RequiredLength = 6;
                       options.Password.RequireDigit = false;
                       options.Password.RequireLowercase = false;
                       options.Password.RequireNonAlphanumeric = false;
                       options.Password.RequireUppercase = false;
                   })
                   .AddEntityFrameworkStores<CinemaDbContext>();

            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
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
            //services.AddTransient<ITicketService, TicketService>();

            
            services.AddTransient<ICreateCinema, CreateCinema>();
            services.Decorate<ICreateCinema, CreateCinemaUniqueValidation>();


            //services.AddTransient<INewRoom, NewRoomCreation>();
            //services.Decorate<INewRoom, NewRoomUniqueValidation>();
            //services.Decorate<INewRoom, NewRoomCinemaValidation>();

            services.AddTransient<ICreateMovie, CreateMovie>();
            services.Decorate<ICreateMovie, CreateMovieUniqueValidation>();

            services.AddTransient<ICreateProjection, CreateProjectionSeatCreation>();
            services.Decorate<ICreateProjection, CreateProjection>();
            services.Decorate<ICreateProjection, CreateProjectionMovieValidation>();
            services.Decorate<ICreateProjection, CreateProjectionRoomValidation>();
            services.Decorate<ICreateProjection, CreateProjectionUniqueValidation>();
            services.Decorate<ICreateProjection, CreateProjectionPreviousOverlapValidation>();
            services.Decorate<ICreateProjection, CreateProjectionNextOverlapValidation>();

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateProjectionCommandValidator>());
                

            //services.AddTransient<IBuyTicket, BuyTicket>();
            //services.Decorate<IBuyTicket, TicketsSeatIsNotBoughtOrBookedValidation>();
            //services.Decorate<IBuyTicket, TicketsSeatValidation>();
            //services.Decorate<IBuyTicket, TicketRoomValidation>();
            //services.Decorate<IBuyTicket, TicketProjectionValidation>();

            //services.AddTransient<ITicketReservation, TicketReservation>();
            //services.Decorate<ITicketReservation, TicketReservationIsNotBoughtOrBookedValdiation>();
            //services.Decorate<ITicketReservation, TicketReservationProjectionHasNotStartedValidation>();
            //services.Decorate<ITicketReservation, TicketReservationSeatValidation>();
            //services.Decorate<ITicketReservation, TicketReservationRoomValidation>();
            //services.Decorate<ITicketReservation, TicketReservationProjectionValidation>();

            //services.AddTransient<IBuyTicketWithReservation, BuyTicketWithReservationReturnBoughtTicket>();
            //services.Decorate<IBuyTicketWithReservation, BuyTicketWithReservation>();
            //services.Decorate<IBuyTicketWithReservation, BuyTicketWithReservationStartTimeValidation>();
            //services.Decorate<IBuyTicketWithReservation, BuyTicketWithReservationNotBoughtValidation>();

            //services.AddHostedService<BackgroundService>();

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
