using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(b => b.Title).IsUnique();

            builder.Property(b => b.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(b => b.BookGenres)
                .WithOne(bg => bg.Book)
                .HasForeignKey(bg => bg.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.BookReservations)
                .WithOne(br => br.Book)
                .HasForeignKey(bg => bg.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
