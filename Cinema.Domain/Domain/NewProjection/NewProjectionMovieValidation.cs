namespace Cinema.Domain.Domain.NewProjection
{
    using Models;
    using Contracts;
    using Services.Contracts;
    using Data.ModelsContracts;

    using System.Threading.Tasks;

    public class NewProjectionMovieValidation : INewProjection
    {
        private readonly IMovieService movieService;
        private readonly INewProjection newProj;

        public NewProjectionMovieValidation(IMovieService movieService, INewProjection newProj)
        {
            this.movieService = movieService;
            this.newProj = newProj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation projection)
        {
            IMovie movie = await movieService.GetById(projection.MovieId);

            if (movie == null)
            {
                return new NewProjectionSummary(false, $"Movie with id: '{projection.MovieId}' does not exist!");
            }

            return await newProj.New(projection);
        }
    }
}
