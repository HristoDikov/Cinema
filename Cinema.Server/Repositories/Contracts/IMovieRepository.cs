namespace Cinema.Server.Repositories.Contracts
{
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface IMovieRepository
    {
        Task<int> Create(IMovieCreation movie);

        Task<IMovie> GetByNameAndDuration(string name, short duration);

        Task<IMovie> GetById(int movieId);

        Task<string> GetMovieName(int movieId);
    }
}
