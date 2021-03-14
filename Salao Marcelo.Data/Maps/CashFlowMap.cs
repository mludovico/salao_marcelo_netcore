using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao_Marcelo.Domain.Models;
using System;
namespace Salao_Marcelo.Data.Maps
{
    public class CashFlowMap : IEntityTypeConfiguration<CashFlow>
    {
        public CashFlowMap()
        {

        }

        public void Configure(EntityTypeBuilder<CashFlow> builder)
        {
            builder.ToTable("CashFlow");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Timestamp)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(x => x.Value)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();
        }
    }
}
