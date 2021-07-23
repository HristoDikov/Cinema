namespace Cinema.Application.Features.Movie.Commands.CreateMovie
{
    using FluentValidation;

    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        private const int minMovieNameLength = 2;
        private const int minMovieDuration = 10;
        public CreateMovieCommandValidator() 
        {
            RuleFor(m => m.Name)
                .MinimumLength(minMovieNameLength)
                .NotNull();

            RuleFor(m => m.DurationMinutes)
                .NotNull()
                .Must(m => m > minMovieDuration)
                .WithMessage("Movie duration must be atleast 10 minutes!");
        }
    }
}
