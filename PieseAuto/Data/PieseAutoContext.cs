using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PieseAuto.Models;

namespace PieseAuto.Data
{
    public class PieseAutoContext : DbContext
    {
        public PieseAutoContext (DbContextOptions<PieseAutoContext> options)
            : base(options)
        {
        }

        public DbSet<PieseAuto.Models.Book> Book { get; set; } = default!;
        public DbSet<PieseAuto.Models.Category> Category { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // coalana pentru Price
            modelBuilder.Entity<PieseAuto.Models.Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)"); // decimale 18 2
        }
    }
}
