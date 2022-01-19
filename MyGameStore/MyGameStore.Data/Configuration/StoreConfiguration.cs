using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGameStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Data.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("tblStores", "Store").HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Street)
               .HasColumnType("nvarchar")
               .IsRequired()
               .HasMaxLength(60);

            builder.Property(p => p.Number)
              .HasColumnType("nvarchar")
              .IsRequired()
              .HasMaxLength(5);

            builder.Property(p => p.Addition)
             .HasColumnType("nvarchar")
             .HasMaxLength(2);

            builder.Property(p => p.Zipcode)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(6);

            builder.Property(p => p.City)
            .HasColumnType("nvarchar")
            .HasColumnName("Place")
            .HasMaxLength(60);

            builder.Property(p => p.IsFranchiseStore)
           .HasColumnType("bit");
        }
    }
}
