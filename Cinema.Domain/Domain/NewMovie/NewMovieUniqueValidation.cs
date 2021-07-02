namespace Cinema.Domain.Domain.NewMovie
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewMovieUniqueValidation : INewMovie
    {
        private readonly IMovieService movieService;
        private readonly INewMovie newMovie;

        public NewMovieUniqueValidation(IMovieService movieService, INewMovie newMovie)
        {
            this.movieService = movieService;
            this.newMovie = newMovie;
        }

        public async Task<NewMovieSummary> New(IMovieCreation movie)
        {
            IMovie movieInDb = await this.movieService.GetByNameAndDuration(movie.Name, movie.DurationMinutes);

            if (movieInDb != null)
            {
                return new NewMovieSummary(false, $"Movie with name: '{movie.Name}' and duration: '{movie.DurationMinutes}' already exists!");
            }

            return await this.newMovie.New(movie);
        }
    }
}
