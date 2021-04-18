using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Abp.vnext.Domain.Book.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Persist.Abp.vnext.EntityFrameworkCore.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));

            builder.ConfigureByConvention();

            builder.Property(book => book.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(book => book.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(book => book.AuthorName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(book => book.CategoryName)
                .HasMaxLength(10)
                .IsRequired();

            // builder
        }
    }
}
