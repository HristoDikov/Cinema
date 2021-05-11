namespace Cinema.Server.Domain.CinemaDomain.NewProjection
{
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class NewProjectionNextOverlapValidation : INewProjection
    {

        private readonly IProjectionRepository projectRepo;
        private readonly IMovieRepository movieRepo;
        private readonly INewProjection newProj;

        public NewProjectionNextOverlapValidation(IProjectionRepository projectRepo, IMovieRepository movieRepo, INewProjection newProj)
        {
            this.projectRepo = projectRepo;
            this.movieRepo = movieRepo;
            this.newProj = newProj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation proj)
        {
            IEnumerable<IProjection> movieProjectionsInRoom = await projectRepo.GetActiveProjections(proj.RoomId);

            IProjection nextProjection = movieProjectionsInRoom.Where(x => x.StartTime > proj.StartTime)
                                                                       .OrderBy(x => x.StartTime)
                                                                       .FirstOrDefault();

            if (nextProjection != null)
            {
                IMovie curMovie = await movieRepo.GetById(proj.MovieId);
                IMovie nextProjectionMovie = await movieRepo.GetById(nextProjection.MovieId);

                DateTime curProjectionEndTime = proj.StartTime.AddMinutes(curMovie.DurationMinutes);

                if (curProjectionEndTime >= nextProjection.StartTime)
                {
                    return new NewProjectionSummary(false, $"Projection overlaps with next one: {nextProjectionMovie.Name} at {nextProjection.StartTime}");
                }
            }

            return await newProj.New(proj);
        }
    }
}
