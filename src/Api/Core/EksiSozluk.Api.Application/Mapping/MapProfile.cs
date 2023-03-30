using AutoMapper;
using EksiSozluk.Api.Application.Features.Commands.Entry.Create;
using EksiSozluk.Api.Application.Features.Commands.EntryComment.Create;
using EksiSozluk.Api.Application.Features.Commands.User.Create;
using EksiSozluk.Api.Application.Features.Commands.User.Login;
using EksiSozluk.Api.Application.Features.Commands.User.Update;
using EksiSozluk.Api.Application.Features.Queries.Entry.GetEntries;
using EksiSozluk.Api.Application.Features.Queries.User.GetUserDetails;
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

        CreateMap<GetUserDetailsQueryResponse, User>();
        
        
        CreateMap<CreateEntryCommandRequest, Entry>();

        CreateMap<CreateEntryCommentCommandRequest, EntryComment>()
            .ReverseMap();

        CreateMap<User, GetUserDetailsQueryResponse>();

        CreateMap<Entry, GetEntriesQueryResponse>()
            .ForMember(i => i.CommentCount, k => k.MapFrom(z => z.EntryComments.Count));
        
        


    }
}