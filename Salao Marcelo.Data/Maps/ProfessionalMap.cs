using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace Salao_Marcelo.Data.Maps
{
    public class ProfessionalMap : IEntityTypeConfiguration<Professional>
    {
        public ProfessionalMap()
        {
        }

        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.ToTable("Professional");
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
            builder.Property(x => x.Commission)
                .HasColumnType("Decimal(10, 2)")
                .IsRequired();
        }
    }
}
