namespace Cinema.Server.Domain.CinemaDomain.NewMovie
{
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewMovieUniqueValidation : INewMovie
    {
        private readonly IMovieRepository movieRepository;
        private readonly INewMovie newMovie;
        public NewMovieUniqueValidation(IMovieRepository movieRepository, INewMovie newMovie)
        {
            this.movieRepository = movieRepository;
            this.newMovie = newMovie;
        }

        public async Task<NewMovieSummary> New(IMovieCreation movie)
        {
            IMovie movieInDb = await this.movieRepository.GetByNameAndDuration(movie.Name, movie.DurationMinutes);

            if (movieInDb != null)
            {
                return new NewMovieSummary(false, $"Movie with name: '{movie.Name}' and duration: '{movie.DurationMinutes}' already exists!");
            }

            return await this.newMovie.New(movie);
        }
    }
}
