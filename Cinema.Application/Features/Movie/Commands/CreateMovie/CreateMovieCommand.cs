namespace Cinema.Application.Features.Movie.Commands.CreateMovie
{
    using Domain.Entities;

    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateMovieCommand : IRequest<CreateMovieSummary>
    {
        public string Name { get; set; }

        public short DurationMinutes { get; set; }
    }

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieSummary>
    {
        private readonly ICreateMovie createMovie;

        public CreateMovieCommandHandler(ICreateMovie createMovie)
        {
            this.createMovie = createMovie;
        }

        public async Task<CreateMovieSummary> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var summary = await this.createMovie.Create(new Movie(request.Name, request.DurationMinutes));

            return summary;
        }
    }

}
