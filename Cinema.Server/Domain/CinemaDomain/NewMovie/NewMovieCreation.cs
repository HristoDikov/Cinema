namespace Cinema.Server.Domain.CinemaDomain.NewMovie
{
    using Repositories.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;
    using Cinema.Server.Data.Models;

    public class NewMovieCreation : INewMovie
    {
        private readonly IMovieRepository movieRepository;

        public NewMovieCreation(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<NewMovieSummary> New(IMovieCreation movie)
        {
            int movieId = await this.movieRepository.Create(new Movie(movie.Name, movie.DurationMinutes));

            return new NewMovieSummary(true, $"Movie with name: '{movie.Name}' and duration: '{movie.DurationMinutes}' has been successfully created! Get the id: '{movieId}' in order to create a projection!");
        }
    }
}
