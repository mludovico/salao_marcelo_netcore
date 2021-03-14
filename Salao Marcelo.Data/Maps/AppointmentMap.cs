using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salao_Marcelo.Domain;
using System;
namespace Salao_Marcelo.Data.Maps
{
    public class AppointmentMap : IEntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
        }

        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Scheduledtime)
                .IsRequired();
            builder.Property(x => x.Service)
                .IsRequired();
            builder.Property(x => x.Professional)
                .IsRequired();
            builder.Property(x => x.Client)
                .IsRequired();
            builder.HasOne(x => x.Professional);
            builder.HasOne(x => x.Client);
            builder.HasOne(x => x.Service);
        }
    }
}
