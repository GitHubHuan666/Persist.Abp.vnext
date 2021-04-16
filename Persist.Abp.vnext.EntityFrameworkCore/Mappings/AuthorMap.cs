using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Abp.vnext.Domain.Author.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Persist.Abp.vnext.EntityFrameworkCore.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(nameof(Author));

            builder.ConfigureByConvention();

            builder.Property(author => author.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(author => author.Description)
                .HasMaxLength(100);
        }
    }
}
