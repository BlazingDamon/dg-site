using AutoMapper;
using Statistics.Domain.Players;

namespace Statistics.Models.Players;
public class PlayerDomainProfile : Profile
{
    public PlayerDomainProfile()
    {
        // Responses
        CreateMap<PlayerDTO, PlayerResponse>();

        // Requests
        CreateMap<PlayerRequestBase, PlayerDTO>();
        CreateMap<PlayerCreateRequest, PlayerDTO>()
            .IncludeBase<PlayerRequestBase, PlayerDTO>();
        CreateMap<PlayerUpdateRequest, PlayerDTO>()
            .IncludeBase<PlayerRequestBase, PlayerDTO>();
    }
}
