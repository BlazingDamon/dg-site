using AutoMapper;
using Statistics.Domain.Players;
using Statistics.Entities.Players;

namespace StatisticsRepository.MongoDB.Players;
public class PlayerEntityProfile : Profile
{
    public PlayerEntityProfile()
    {
        CreateMap<Player, PlayerDTO>().ReverseMap();
    }
}
