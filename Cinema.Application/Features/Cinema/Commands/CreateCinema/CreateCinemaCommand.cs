namespace Cinema.Application.Features.Cinema.Commands.CreateCinema
{
    using Domain.Entities;

    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCinemaCommand : IRequest<CreateCinemaSummary>
    {
        public string Name { get; set; }

        public string  Address { get; set; }
    }

    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, CreateCinemaSummary>
    {
        private readonly ICreateCinema createCinema;

        public CreateCinemaCommandHandler(ICreateCinema createCinema)
        {
            this.createCinema = createCinema;
        }

        public async Task<CreateCinemaSummary> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {
            var summary = await this.createCinema.Create(new Cinema(request.Name, request.Address));

            return summary;
        }
    }
}
