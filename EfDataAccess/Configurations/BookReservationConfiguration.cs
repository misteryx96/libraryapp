using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class BookReservationConfiguration : IEntityTypeConfiguration<BookReservation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BookReservation> builder)
        {
            builder.HasKey(br => new { br.BookId, br.ReservationId });
        }
    }
}
