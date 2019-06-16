using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.Property(w => w.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(w => w.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
