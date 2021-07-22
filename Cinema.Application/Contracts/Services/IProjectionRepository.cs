namespace Cinema.Application.Contracts.Services
{
    using Domain.EntitiesContracts;
    using Features.Projection.Commands.CreateProjection;

    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IProjectionService
    {
        Task<int> Create(IProjectionCreation projection);

        Task<ProjectionOutputModel> Get(int movieId, int roomId, DateTime startTime);

        Task<ProjectionOutputModel> GetById(int projectionId);

        Task<IEnumerable<ProjectionOutputModel>> GetActiveProjections(int roomId);

        Task<bool> CheckIfProjectionHasNotStarted(int projectionId);
    }
}
