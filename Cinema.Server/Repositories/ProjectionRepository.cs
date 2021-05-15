namespace Cinema.Server.Repositories
{
    using Data;
    using Data.Dtos;
    using Contracts;
    using Data.Models;
    using Data.ModelsContracts;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

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

            int count = await db.Rooms.Where(r => r.Id == newProj.RoomId).Select(r => r.Rows * r.SeatsPerRow).FirstOrDefaultAsync();

            //Set the projection seats
            newProj.AvailableSeats = count;

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
                    MovieId = p.MovieId,
                })
              .FirstOrDefaultAsync();
        }

        public async Task<bool> CheckIfProjectionHasNotStarted(int projectionId)
        {
            ProjectionDto proj = await this.GetById(projectionId);

            if (DateTime.Parse(proj.StartTime) < DateTime.Now || (DateTime.Parse(proj.StartTime) - DateTime.Now).TotalMinutes < 10)
            {
                return false;
            }

            return true;
        }
    }
}
