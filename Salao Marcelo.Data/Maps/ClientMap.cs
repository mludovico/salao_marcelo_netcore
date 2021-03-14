using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao_Marcelo.Domain;
using System;
namespace Salao_Marcelo.Data.Maps
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
        }

        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(x => x.Phone)
                .HasColumnType("varchar(15)")
                .IsRequired();
            builder.Property(x => x.Address)
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}
