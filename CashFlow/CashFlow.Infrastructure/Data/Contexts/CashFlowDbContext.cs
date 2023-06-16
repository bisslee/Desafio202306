using Microsoft.EntityFrameworkCore;
using CashFlow.Domain.Models;
using System.Collections.Generic;

namespace CashFlow.Infrastructure.Data.Contexts
{
    public class CashFlowDbContext : DbContext
    {
        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Transaction>()
                .Property(e => e.Description)
                .HasMaxLength(120)
                .IsRequired();

            builder.Entity<Transaction>()
                .Property(e => e.CreatedAt)
                .IsRequired();

            builder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

        }
    }
}
