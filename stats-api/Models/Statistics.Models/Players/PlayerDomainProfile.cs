using AutoMapper;
using Statistics.Domain.Players;

namespace Statistics.Models.Players;
public class PlayerDomainProfile : Profile
{
    public PlayerDomainProfile()
    {
        CreateMap<PlayerDTO, Player>().ReverseMap();
    }
}
