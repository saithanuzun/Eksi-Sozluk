namespace EksiSozluk.Api.Application.Features.Queries.User.GetUserDetails;

public class GetUserDetailsQueryResponse
{
    public Guid Id { get; set; }

    public DateTime CreateDate { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public bool EmailConfirmed { get; set; }
}