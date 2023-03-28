using MediatR;

namespace EksiSozluk.Api.Application.Features.Queries.User.GetUserDetails;

public class GetUserDetailsQueryRequest : IRequest<GetUserDetailsQueryResponse>
{
    public Guid? UserId { get; set; }
    public string Username { get; set; }
}