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

    public class NewProjectionPreviousOverlapValidation : INewProjection
    {
        private readonly IProjectionService projectionService;
        private readonly IMovieService movieService;
        private readonly INewProjection newProj;

        public NewProjectionPreviousOverlapValidation(IProjectionService projectionService, IMovieService movieService, INewProjection proj)
        {
            this.projectionService = projectionService;
            this.movieService = movieService;
            this.newProj = proj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation proj)
        {
            IEnumerable<IProjection> movieProjectionsInRoom = await projectionService.GetActiveProjections(proj.RoomId);

            IProjection previousProjection = movieProjectionsInRoom.Where(x => x.StartTime < proj.StartTime)
                                                                        .OrderByDescending(x => x.StartTime)
                                                                        .FirstOrDefault();

            if (previousProjection != null)
            {
                IMovie previousProjectionMovie = await movieService.GetById(previousProjection.MovieId);

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
