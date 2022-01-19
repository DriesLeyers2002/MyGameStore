using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGameStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("tblPeople", "Person").HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
               .HasColumnType("nvarchar")
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(p => p.LastName)
               .HasColumnType("nvarchar")
               .IsRequired()
               .HasMaxLength(70);

            builder.Property(p => p.Gender)
               .HasColumnType("int");

            builder.Property(p => p.Email)
               .HasColumnType("nvarchar")
               .HasColumnName("EmailAddress")
               .HasMaxLength(100);
        }
    }
}
