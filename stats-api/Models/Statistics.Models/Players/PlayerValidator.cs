using FluentValidation;

namespace Statistics.Models.Players;

public class PlayerValidator : AbstractValidator<PlayerResponse>
{
    public PlayerValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.EventsCompleted).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Wins).GreaterThanOrEqualTo(0);
    }
}
