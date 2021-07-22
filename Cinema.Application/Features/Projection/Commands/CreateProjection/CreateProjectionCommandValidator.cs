namespace Cinema.Application.Features.Projection.Commands.CreateProjection
{
    using FluentValidation;
    using System;

    public class CreateProjectionCommandValidator : AbstractValidator<CreateProjectionCommand>
    {
        private const int MinMovieId = 1;
        private const int MinCinemaId = 1;
        private const string InvalidStartTimeMessage = "Start time is not valid!";

        public CreateProjectionCommandValidator()
        {
            RuleFor(p => p.MovieId)
                .GreaterThanOrEqualTo(MinMovieId);

            RuleFor(p => p.RoomId)
                .GreaterThanOrEqualTo(MinCinemaId);

            RuleFor(p => p.StartTime)
                .Must(startTime => startTime > DateTime.Now)
                .WithMessage(InvalidStartTimeMessage);
        }
    }
}
