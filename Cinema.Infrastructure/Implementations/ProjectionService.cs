namespace Cinema.Infrastructure.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Persistance;
    using Cinema.Domain.EntitiesContracts;
    using Cinema.Domain.Entities;
    using Application.Contracts.Services;
    using Application.Features.Projection.Commands.CreateProjection;

    public class ProjectionService : IProjectionService
    {
        private readonly CinemaDbContext db;

        public ProjectionService(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(IProjectionCreation projection)
        {
            Projection newProj = new Projection(projection.MovieId, projection.RoomId, projection.StartTime);

            int count = await db.Rooms.Where(r => r.Id == newProj.RoomId).Select(r => r.Rows * r.SeatsPerRow).FirstOrDefaultAsync();

            //Set the projection seats
            newProj.AvailableSeats = count;

            this.db.Projections.Add(newProj);

            await db.SaveChangesAsync();

            return newProj.Id;
        }

        public async Task<ProjectionOutputModel> Get(int movieId, int roomId, DateTime startTime)
        {
            return await this.db.Projections
                .Select(p => new ProjectionOutputModel
                {
                    MovieId = p.MovieId,
                    ProjectionId = p.Id,
                    RoomId = p.RoomId,
                    StartTime = p.StartTime
                })
                .FirstOrDefaultAsync(x => x.MovieId == movieId &&
                x.RoomId == roomId &&
                x.StartTime == startTime);
        }

        public async Task<IEnumerable<ProjectionOutputModel>> GetActiveProjections(int roomId)
        {
            DateTime now = DateTime.UtcNow;

            return await this.db.Projections
                .Where(p => p.RoomId == roomId && p.StartTime > now)
                .Select(p => new ProjectionOutputModel 
                {
                    ProjectionId = p.Id,
                    StartTime = p.StartTime,
                    MovieId = p.MovieId,
                    RoomId = p.RoomId,
                })
                .ToListAsync();
        }

        public async Task<ProjectionOutputModel> GetById(int projectionId)
        {
            return await this.db.Projections.Where(p => p.Id == projectionId)
                .Select(p => new ProjectionOutputModel
                {
                    ProjectionId = p.Id,
                    StartTime = p.StartTime,
                    RoomId = p.RoomId,
                    MovieId = p.MovieId,
                })
              .FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfProjectionHasNotStarted(int projectionId)
        {
            ProjectionOutputModel proj = await this.GetById(projectionId);

            if (proj.StartTime < DateTime.Now || (proj.StartTime - DateTime.Now).TotalMinutes < 10)
            {
                return false;
            }

            return true;
        }
    }
}
