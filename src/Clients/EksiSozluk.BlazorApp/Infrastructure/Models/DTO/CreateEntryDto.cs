namespace EksiSozluk.BlazorApp.Infrastructure.Models.DTO;

public class CreateEntryDto
{
    public string Subject { get; set; }

    public string Content { get; set; }

    public Guid? CreatedById { get; set; }

    public CreateEntryDto()
    {

    }

    public CreateEntryDto(string subject, string content, Guid? createdById)
    {
        Subject = subject;
        Content = content;
        CreatedById = createdById;
    }
}