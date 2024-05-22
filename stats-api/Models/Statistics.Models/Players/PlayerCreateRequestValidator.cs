using FluentValidation;

namespace Statistics.Models.Players;

public class PlayerCreateRequestValidator : AbstractValidator<PlayerCreateRequest>
{
    public PlayerCreateRequestValidator()
    {
        Include(new PlayerRequestBaseValidator());
    }
}
