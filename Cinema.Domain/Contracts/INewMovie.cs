namespace Cinema.Domain.Contracts
{
    using Models;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface INewMovie
    {
        Task<NewMovieSummary> New(IMovieCreation movie);
    }
}
