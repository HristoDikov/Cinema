namespace Cinema.Server.Domain.CinemaDomainContracts
{
    using Models;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public interface INewProjection
    {
        Task<NewProjectionSummary> New(IProjectionCreation projection);
    }
}
