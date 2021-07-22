namespace Cinema.Application.Contracts.Services
{
    using Features.Movie.Commands.CreateMovie;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public interface IMovieService
    {
        Task<int> Create(IMovieCreation movie);

        Task<MovieOutputModel> GetByNameAndDuration(string name, short duration);

        Task<MovieOutputModel> GetById(int movieId);

        Task<string> GetMovieName(int movieId);
    }
}
