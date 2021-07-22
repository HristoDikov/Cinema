namespace Cinema.Application.Features.Projection.Commands.CreateProjection.Validations
{
    using Contracts.Services;
    using Features.Movie.Commands.CreateMovie;
    using Domain.EntitiesContracts;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class CreateProjectionNextOverlapValidation : ICreateProjection
    {

        private readonly IProjectionService projectionService;
        private readonly IMovieService movieService;
        private readonly ICreateProjection createProjection;

        public CreateProjectionNextOverlapValidation(IProjectionService projectionService, IMovieService movieService, ICreateProjection createProjection)
        {
            this.projectionService = projectionService;
            this.movieService = movieService;
            this.createProjection = createProjection;
        }

        public IMovieService MovieService => movieService;

        public async Task<CreateProjectionSummary> Create(IProjectionCreation proj)
        {
            IEnumerable<ProjectionOutputModel> movieProjectionsInRoom = await projectionService.GetActiveProjections(proj.RoomId);

            ProjectionOutputModel nextProjection = movieProjectionsInRoom.Where(x => x.StartTime > proj.StartTime)
                                                                       .OrderBy(x => x.StartTime)
                                                                       .FirstOrDefault();

            if (nextProjection != null)
            {
                MovieOutputModel curMovie = await MovieService.GetById(proj.MovieId);
                MovieOutputModel nextProjectionMovie = await MovieService.GetById(nextProjection.MovieId);

                DateTime curProjectionEndTime = proj.StartTime.AddMinutes(curMovie.DurationMinutes);

                if (curProjectionEndTime >= nextProjection.StartTime)
                {
                    return new CreateProjectionSummary(false, $"Projection overlaps with next one: {nextProjectionMovie.Name} at {nextProjection.StartTime}");
                }
            }

            return await createProjection.Create(proj);
        }
    }
}
