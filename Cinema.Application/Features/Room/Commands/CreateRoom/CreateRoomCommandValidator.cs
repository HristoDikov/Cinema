namespace Cinema.Application.Features.Room.Commands.CreateRoom
{
    using FluentValidation;

    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        private const int MinCinemaId = 1;
        private const int MinNumberSeat = 1;
        private const int MinSeatPerRowNumber = 1;
        private const int MinRows = 1;

        public CreateRoomCommandValidator() 
        {
            RuleFor(r => r.CinemaId)
                .NotNull()
                .Must(cId => cId >= MinCinemaId);

            RuleFor(r => r.Number)
                .NotNull()
                .Must(n => n > MinNumberSeat);

            RuleFor(r => r.SeatsPerRow)
               .NotNull()
               .Must(s => s > MinSeatPerRowNumber);

            RuleFor(r => r.Rows)
               .NotNull()
               .Must(r => r > MinRows);
        }
    }
}
