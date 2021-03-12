using System;
using Microsoft.EntityFrameworkCore;
using Salao_Marcelo.Domain;

namespace Salao_Marcelo.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CashFlow> CashFlows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
