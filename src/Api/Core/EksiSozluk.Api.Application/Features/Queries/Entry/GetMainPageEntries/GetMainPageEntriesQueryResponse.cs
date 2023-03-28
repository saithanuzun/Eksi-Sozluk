namespace EksiSozluk.Api.Application.Features.Queries.Entry.GetMainPageEntries;

public class GetMainPageEntriesQueryResponse
{
    public Guid Id { get; set; }

    public string Subject { get; set; }
    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedByUserName { get; set; }
}