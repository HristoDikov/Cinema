namespace Cinema.Server.Services
{
    using Data;
    using Data.Dtos;
    using Contracts;
    using Data.ModelsContracts;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Cinema.Server.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class ProjectionRepository : IProjectionRepository
    {
        private readonly CinemaDbContext db;

        public ProjectionRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(IProjectionCreation projection)
        {
            Projection newProj = new Projection(projection.MovieId, projection.RoomId, projection.StartTime);

            this.db.Projections.Add(newProj);

            await db.SaveChangesAsync();

            return newProj.Id;
        }

        public async Task<IProjection> Get(int movieId, int roomId, DateTime startTime)
        {
            return await this.db.Projections
                .FirstOrDefaultAsync(x => x.MovieId == movieId &&
                x.RoomId == roomId &&
                x.StartTime == startTime);
        }
        public async Task<IEnumerable<IProjection>> GetActiveProjections(int roomId)
        {
            DateTime now = DateTime.UtcNow;

            return await this.db.Projections
                .Where(p => p.RoomId == roomId && p.StartTime > now)
                .ToListAsync();
        }

        public async Task<ProjectionDto> GetById(int projectionId)
        {
            return await this.db.Projections.Where(p => p.Id == projectionId)
                .Select(p => new ProjectionDto
                {
                    ProjectionId = p.Id,
                    StartTime = p.StartTime.ToString(),
                    RoomId = p.RoomId,
                })
              .FirstOrDefaultAsync();
        }

        public async Task<string> GetProjectionMovieName(int projectionId)
        {
            return await this.db.Projections
                .Where(p => p.Id == projectionId)
                .Select(p => p.Movie.Name)
                .FirstOrDefaultAsync();
        }
    }
}
