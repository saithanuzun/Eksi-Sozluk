using EksiSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EksiSozluk.Api.Infrastructure.Persistence.Configurations.EntryComment;

public class EntryCommentEntityConfiguration : BaseEntityConfiguration<Domain.Entities.EntryComment>
{
    public override void Configure(EntityTypeBuilder<Domain.Entities.EntryComment> builder)
    {
        base.Configure(builder);

        builder.ToTable("entrycomment", EksiSozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Entry)
            .WithMany(i => i.EntryComments)
            .HasForeignKey(i => i.EntryId);

        builder.HasOne(i => i.User)
            .WithMany(i => i.EntryComments)
            .HasForeignKey(i => i.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}