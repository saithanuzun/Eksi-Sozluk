using EksiSozluk.Api.Application.Interfaces.Repositories;
using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.User.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQueryRequest,GetUserDetailsQueryResponse>
{
    private IUserRepository _userRepository;

    public GetUserDetailsQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<GetUserDetailsQueryResponse> Handle(GetUserDetailsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}