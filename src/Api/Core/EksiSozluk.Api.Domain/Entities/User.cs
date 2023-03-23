namespace EksiSozluk.Api.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }

    public ICollection<Entry> Entries { get; set; }
    public ICollection<EntryComment> EntryComments { get; set; }
    public ICollection<EntryFavorite> EntryFavorites { get; set; }
    public ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; }

}