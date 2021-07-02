namespace Cinema.Domain.Domain.NewProjection
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class NewProjectionNextOverlapValidation : INewProjection
    {

        private readonly IProjectionService projectionService;
        private readonly IMovieService movieService;
        private readonly INewProjection newProj;

        public NewProjectionNextOverlapValidation(IProjectionService projectionService, IMovieService movieService, INewProjection newProj)
        {
            this.projectionService = projectionService;
            this.movieService = movieService;
            this.newProj = newProj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation proj)
        {
            IEnumerable<IProjection> movieProjectionsInRoom = await projectionService.GetActiveProjections(proj.RoomId);

            IProjection nextProjection = movieProjectionsInRoom.Where(x => x.StartTime > proj.StartTime)
                                                                       .OrderBy(x => x.StartTime)
                                                                       .FirstOrDefault();

            if (nextProjection != null)
            {
                IMovie curMovie = await movieService.GetById(proj.MovieId);
                IMovie nextProjectionMovie = await movieService.GetById(nextProjection.MovieId);

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
