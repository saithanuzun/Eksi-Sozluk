using AutoMapper;
using EksiSozluk.Api.Application.Features.Commands.User.Login;
using EksiSozluk.Api.Domain.Entities;

namespace EksiSozluk.Api.Application.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<User, LoginUserCommandResponse>()
            .ReverseMap();
    }
}