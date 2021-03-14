using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao_Marcelo.Domain;
using System;
namespace Salao_Marcelo.Data.Maps
{
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
        }

        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(x => x.TimeInMinutes)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.Price)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();
        }
    }
}
