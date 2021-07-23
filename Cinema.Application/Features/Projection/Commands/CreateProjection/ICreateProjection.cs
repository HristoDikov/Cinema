namespace Cinema.Application.Features.Projection.Commands.CreateProjection
{
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public interface ICreateProjection
    {
        Task<CreateProjectionSummary> Create(IProjectionCreation projection);
    }
}
