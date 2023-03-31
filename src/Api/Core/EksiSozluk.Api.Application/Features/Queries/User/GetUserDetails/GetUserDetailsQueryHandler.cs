using AutoMapper;
using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.User.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQueryRequest, GetUserDetailsQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserDetailsQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserDetailsQueryResponse> Handle(GetUserDetailsQueryRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.User dbUser = null;

        if (request.UserId is not null)
            dbUser = await _userRepository.GetByIdAsync(request.UserId.Value);
        else if (!string.IsNullOrEmpty(request.Username))
            dbUser = await _userRepository.GetSingleAsync(i => i.Username == request.Username);
        else
            throw new Exception("requestModel is null");

        return _mapper.Map<GetUserDetailsQueryResponse>(dbUser);
    }
}