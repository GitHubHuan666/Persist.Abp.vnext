using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Abp.vnext.Domain.Book.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Persist.Abp.vnext.EntityFrameworkCore.Mappings
{
    public class ChapterTextMap : IEntityTypeConfiguration<ChapterText>
    {
        public void Configure(EntityTypeBuilder<ChapterText> builder)
        {
            builder.ToTable(nameof(ChapterText));

            builder.ConfigureByConvention();

            builder.Property(text => text.Content)
                .HasColumnType("ntext")
                .HasMaxLength(8000)
                .IsRequired();

        }
    }
}
