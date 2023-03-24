using EksiSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EksiSozluk.Api.Infrastructure.Persistence.Configurations.Entry;

public class EntryEntityConfiguration : BaseEntityConfiguration<Domain.Entities.Entry>
{
    public override void Configure(EntityTypeBuilder<Domain.Entities.Entry> builder)
    {
        base.Configure(builder);

        builder.ToTable("entry", EksiSozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.CreatedBy)
            .WithMany(i => i.Entries)
            .HasForeignKey(i => i.CreatedById);
    }
}