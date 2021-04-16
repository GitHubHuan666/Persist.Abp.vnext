using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Abp.vnext.Domain.Book.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Persist.Abp.vnext.EntityFrameworkCore.Mappings
{
    public class ChapterMap : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable(nameof(Chapter));

            builder.ConfigureByConvention();

            builder.Property(chapter => chapter.Title)
                .HasMaxLength(30)
                .IsRequired();


        }
    }
}
