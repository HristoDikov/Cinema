namespace Cinema.Infrastructure.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Application.Contracts.Services;
    using Cinema.Infrastructure.Persistance;
    using Application.Features.Movie.Commands.CreateMovie;
    using Cinema.Domain.EntitiesContracts;
    using Cinema.Domain.Entities;

    public class MovieService : IMovieService
    {
        private readonly CinemaDbContext db;

        public MovieService(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<MovieOutputModel> GetByNameAndDuration(string name, short duration)
        {
            return await this.db.Movies
               .Select(m => new MovieOutputModel
               {
                   Name = m.Name,
                   DurationMinutes = m.DurationMinutes,
               })
                .FirstOrDefaultAsync(m => m.Name == name &&
                                                m.DurationMinutes == duration);
        }

        public async Task<int> Create(IMovieCreation movie)
        {
            Movie newMovie = new Movie(movie.Name, movie.DurationMinutes);

            db.Movies.Add(newMovie);
            await this.db.SaveChangesAsync();

            return newMovie.Id;
        }

        public async Task<MovieOutputModel> GetById(int movieId)
        {
            return await this.db.Movies
                .Where(m => m.Id == movieId)
                 .Select(m => new MovieOutputModel
                 {
                     Name = m.Name,
                     DurationMinutes = m.DurationMinutes,
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<string> GetMovieName(int movieId)
        {
            return await this.db.Movies.Where(m => m.Id == movieId)
                .Select(m => m.Name)
                .FirstOrDefaultAsync();
        }
    }
}
