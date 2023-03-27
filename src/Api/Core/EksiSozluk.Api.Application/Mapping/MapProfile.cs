using AutoMapper;
using EksiSozluk.Api.Application.Features.Commands.Entry.Create;
using EksiSozluk.Api.Application.Features.Commands.User.Create;
using EksiSozluk.Api.Application.Features.Commands.User.Login;
using EksiSozluk.Api.Application.Features.Commands.User.Update;
using EksiSozluk.Api.Domain.Entities;

namespace EksiSozluk.Api.Application.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<User, LoginUserCommandResponse>()
            .ReverseMap();
        CreateMap<CreateUserCommandRequest, User>();
        
        CreateMap<UpdateUserCommandRequest, User>();
        CreateMap<CreateEntryCommandRequest, Entry>();

 
    }
}