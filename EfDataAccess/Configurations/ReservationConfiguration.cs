using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {

            builder.Property(g => g.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(r => r.BookReservations)
                .WithOne(br => br.Reservation)
                .HasForeignKey(bg => bg.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
