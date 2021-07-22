namespace Cinema.Application.Features.Movie.Commands.CreateMovie
{
    using System.Threading.Tasks;
    using Domain.EntitiesContracts;

    public interface ICreateMovie
    {
        Task<CreateMovieSummary> Create(IMovieCreation movie);
    }
}
