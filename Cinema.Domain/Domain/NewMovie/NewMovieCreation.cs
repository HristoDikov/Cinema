namespace Cinema.Domain.Domain.NewMovie
{
    using Models;
    using Contracts;
    using Data.Models;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewMovieCreation : INewMovie
    {
        private readonly IMovieService movieService;

        public NewMovieCreation(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<NewMovieSummary> New(IMovieCreation movie)
        {
            int movieId = await this.movieService.Create(new Movie(movie.Name, movie.DurationMinutes));

            return new NewMovieSummary(true, $"Movie with name: '{movie.Name}' and duration: '{movie.DurationMinutes}' has been successfully created! Get the id: '{movieId}' in order to create a projection!");
        }
    }
}
