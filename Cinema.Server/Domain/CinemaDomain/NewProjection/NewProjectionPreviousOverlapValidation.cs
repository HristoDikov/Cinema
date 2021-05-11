namespace Cinema.Server.Domain.CinemaDomain.NewProjection
{
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using Domain.CinemaDomainContracts.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NewProjectionPreviousOverlapValidation : INewProjection
    {
        private readonly IProjectionRepository projectRepo;
        private readonly IMovieRepository movieRepo;
        private readonly INewProjection newProj;

        public NewProjectionPreviousOverlapValidation(IProjectionRepository projectRepo, IMovieRepository movieRepo, INewProjection proj)
        {
            this.projectRepo = projectRepo;
            this.movieRepo = movieRepo;
            this.newProj = proj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation proj)
        {
            IEnumerable<IProjection> movieProjectionsInRoom = await projectRepo.GetActiveProjections(proj.RoomId);

            IProjection previousProjection = movieProjectionsInRoom.Where(x => x.StartTime < proj.StartTime)
                                                                        .OrderByDescending(x => x.StartTime)
                                                                        .FirstOrDefault();

            if (previousProjection != null)
            {
                IMovie previousProjectionMovie = await movieRepo.GetById(previousProjection.MovieId);

                DateTime previousProjectionEnd = previousProjection.StartTime.AddMinutes(previousProjectionMovie.DurationMinutes);

                if (previousProjectionEnd >= proj.StartTime)
                {
                    return new NewProjectionSummary(false, $"Projection overlaps with previous one: '{previousProjectionMovie.Name}' at: '{previousProjection.StartTime}'");
                }
            }

            return await newProj.New(proj);
        }
    }
}
