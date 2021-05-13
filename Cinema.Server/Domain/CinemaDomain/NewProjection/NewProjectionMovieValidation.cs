namespace Cinema.Server.Domain.CinemaDomain.NewProjection
{
    using Repositories.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;

    public class NewProjectionMovieValidation : INewProjection
    {
        private readonly IMovieRepository movieRepo;
        private readonly INewProjection newProj;

        public NewProjectionMovieValidation(IMovieRepository movieRepo, INewProjection newProj)
        {
            this.movieRepo = movieRepo;
            this.newProj = newProj;
        }

        public async Task<NewProjectionSummary> New(IProjectionCreation projection)
        {
            IMovie movie = await movieRepo.GetById(projection.MovieId);

            if (movie == null)
            {
                return new NewProjectionSummary(false, $"Movie with id: '{projection.MovieId}' does not exist!");
            }

            return await newProj.New(projection);
        }
    }
}
