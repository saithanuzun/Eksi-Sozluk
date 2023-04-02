namespace EksiSozluk.BlazorApp.Infrastructure.Models.DTO;

public class CreateEntryCommentDto
{
    public Guid? EntryId { get; set; }

    public string Content { get; set; }

    public Guid? CreatedById { get; set; }

    public CreateEntryCommentDto()
    {

    }

    public CreateEntryCommentDto(Guid entryId, string content, Guid createdById)
    {
        EntryId = entryId;
        Content = content;
        CreatedById = createdById;
    }
}