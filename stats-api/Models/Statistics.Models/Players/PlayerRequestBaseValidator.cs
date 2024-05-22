using FluentValidation;

namespace Statistics.Models.Players;

public class PlayerRequestBaseValidator : AbstractValidator<PlayerRequestBase>
{
    public PlayerRequestBaseValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.EventsCompleted).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Wins).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Wins).LessThanOrEqualTo(x=> x.EventsCompleted);
    }
}
