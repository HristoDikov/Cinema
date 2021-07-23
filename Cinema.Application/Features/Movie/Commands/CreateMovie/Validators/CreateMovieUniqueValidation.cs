namespace Cinema.Application.Features.Movie.Commands.CreateMovie.Validators
{
    using Contracts.Services;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateMovieUniqueValidation : ICreateMovie
    {
        private readonly IMovieService movieService;
        private readonly ICreateMovie newMovie;

        public CreateMovieUniqueValidation(IMovieService movieService, ICreateMovie newMovie)
        {
            this.movieService = movieService;
            this.newMovie = newMovie;
        }

        public async Task<CreateMovieSummary> Create(IMovieCreation movie)
        {
            MovieOutputModel movieInDb = await this.movieService.GetByNameAndDuration(movie.Name, movie.DurationMinutes);

            if (movieInDb != null)
            {
                return new CreateMovieSummary(false, $"Movie with name: '{movie.Name}' and duration: '{movie.DurationMinutes}' already exists!");
            }

            return await this.newMovie.Create(movie);
        }
    }
}
