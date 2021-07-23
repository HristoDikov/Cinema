namespace Cinema.Application.Features.Projection.Commands.CreateProjection.Validations
{
    using Contracts.Services;
    using Features.Movie.Commands.CreateMovie;
    using Domain.EntitiesContracts;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class CreateProjectionPreviousOverlapValidation : ICreateProjection
    {
        private readonly IProjectionService projectionService;
        private readonly IMovieService movieService;
        private readonly ICreateProjection createProjection;

        public CreateProjectionPreviousOverlapValidation(IProjectionService projectionService, IMovieService movieService, ICreateProjection createProjection)
        {
            this.projectionService = projectionService;
            this.movieService = movieService;
            this.createProjection = createProjection;
        }

        public async Task<CreateProjectionSummary> Create(IProjectionCreation proj)
        {
            IEnumerable<ProjectionOutputModel> movieProjectionsInRoom = await projectionService.GetActiveProjections(proj.RoomId);

            ProjectionOutputModel previousProjection = movieProjectionsInRoom.Where(x => x.StartTime < proj.StartTime)
                                                                        .OrderByDescending(x => x.StartTime)
                                                                        .FirstOrDefault();

            if (previousProjection != null)
            {
                MovieOutputModel previousProjectionMovie = await movieService.GetById(previousProjection.MovieId);

                DateTime previousProjectionEnd = previousProjection.StartTime.AddMinutes(previousProjectionMovie.DurationMinutes);

                if (previousProjectionEnd >= proj.StartTime)
                {
                    return new CreateProjectionSummary(false, $"Projection overlaps with previous one: '{previousProjectionMovie.Name}' at: '{previousProjection.StartTime}'");
                }
            }

            return await createProjection.Create(proj);
        }
    }
}
