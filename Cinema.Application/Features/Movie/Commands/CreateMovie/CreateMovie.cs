namespace Cinema.Application.Features.Movie.Commands.CreateMovie
{
    using Contracts.Services;
    using Domain.Entities;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateMovie : ICreateMovie
    {
        private readonly IMovieService movieService;

        public CreateMovie(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<CreateMovieSummary> Create(IMovieCreation movie)
        {
            int movieId = await this.movieService.Create(new Movie(movie.Name, movie.DurationMinutes));

            return new CreateMovieSummary(true, $"Movie with name: '{movie.Name}' and duration: '{movie.DurationMinutes}' has been successfully created! Get the id: '{movieId}' in order to create a projection!");
        }
    }
}
