namespace Cinema.Application.Features.Movie.Commands.CreateMovie
{
    using FluentValidation;

    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        private const int MinMovieNameLength = 2;
        private const int MinMovieDuration = 10;

        public CreateMovieCommandValidator() 
        {
            RuleFor(m => m.Name)
                .MinimumLength(MinMovieNameLength)
                .NotNull();

            RuleFor(m => m.DurationMinutes)
                .NotNull()
                .Must(m => m > MinMovieDuration)
                .WithMessage("Movie duration must be atleast 10 minutes!");
        }
    }
}
