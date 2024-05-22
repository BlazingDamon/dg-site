using FluentValidation;

namespace Statistics.Models.Players;

public class PlayerUpdateRequestValidator : AbstractValidator<PlayerUpdateRequest>
{
    public PlayerUpdateRequestValidator()
    {
        Include(new PlayerRequestBaseValidator());
    }
}
