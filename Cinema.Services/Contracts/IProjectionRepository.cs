namespace Cinema.Services.Contracts
{
    using Data.Dtos;
    using Data.ModelsContracts;

    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IProjectionService
    {
        Task<int> Create(IProjectionCreation projection);

        Task<IProjection> Get(int movieId, int roomId, DateTime startTime);

        Task<ProjectionDto> GetById(int projectionId);

        Task<IEnumerable<IProjection>> GetActiveProjections(int roomId);

        Task<bool> CheckIfProjectionHasNotStarted(int projectionId);
    }
}
