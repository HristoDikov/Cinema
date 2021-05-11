namespace Cinema.Server.Services.Contracts
{
    using Cinema.Server.Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface IMovieRepository
    {
        Task<int> Create(IMovieCreation movie);

        Task<IMovie> GetByNameAndDuration(string name, short duration);

        Task<IMovie> GetById(int movieId);
    }
}
