using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao_Marcelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao_Marcelo.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.Mail)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.Password)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
