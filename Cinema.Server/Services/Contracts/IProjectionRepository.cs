namespace Cinema.Server.Services.Contracts
{
    using Data.ModelsContracts;

    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IProjectionRepository
    {
        Task<int> Create(IProjectionCreation projection);

        Task<IProjection> Get(int movieId, int roomId, DateTime startTime);

        Task<IEnumerable<IProjection>> GetActiveProjections(int roomId);
    }
}
