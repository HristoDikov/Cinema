namespace Cinema.Application.Features.Projection.Commands.CreateProjection.Validations
{
    using Contracts.Services;
    using Features.Movie.Commands.CreateMovie;
    using Domain.EntitiesContracts;

    using System.Threading.Tasks;

    public class CreateProjectionMovieValidation : ICreateProjection
    {
        private readonly IMovieService movieService;
        private readonly ICreateProjection createProjection;

        public CreateProjectionMovieValidation(IMovieService movieService, ICreateProjection createProjection)
        {
            this.movieService = movieService;
            this.createProjection = createProjection;
        }

        public async Task<CreateProjectionSummary> Create(IProjectionCreation projection)
        {
            MovieOutputModel movie = await movieService.GetById(projection.MovieId);

            if (movie == null)
            {
                return new CreateProjectionSummary(false, $"Movie with id: '{projection.MovieId}' does not exist!");
            }

            return await createProjection.Create(projection);
        }
    }
}
