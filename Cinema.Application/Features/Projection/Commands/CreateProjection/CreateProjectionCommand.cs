namespace Cinema.Application.Features.Projection.Commands.CreateProjection
{
    using Domain.Entities;

    using System;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateProjectionCommand : IRequest<CreateProjectionSummary>
    {
        public int RoomId { get; set; }

        public int MovieId { get; set; }

        public DateTime StartTime { get; set; }
    }

    public class CreateProjectionCommandHandler : IRequestHandler<CreateProjectionCommand, CreateProjectionSummary>
    {
        private readonly ICreateProjection createProjection;

        public CreateProjectionCommandHandler(ICreateProjection createProjection)
        {
            this.createProjection = createProjection;
        }

        public async Task<CreateProjectionSummary> Handle(CreateProjectionCommand request, CancellationToken cancellationToken)
        {
            var summary = await this.createProjection.Create(new Projection(request.RoomId, request.MovieId, request.StartTime));

            return summary;
        }
    }
}
