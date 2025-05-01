using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TUTOR.Model;

namespace TUTOR.Context
{
    public class TutorDbContext : DbContext
    {
        public TutorDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<HistorialTip> HistorialTips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Tip>()
                .HasKey(t => t.TipId);

            modelBuilder.Entity<HistorialTip>()
                .HasKey(h => h.HistorialTipId);

            // Relaciones (si decides usarlas explícitamente)
            modelBuilder.Entity<HistorialTip>()
                .HasOne(h => h.User)
                .WithMany(u => u.HistorialTips)
                .HasForeignKey(h => h.UserId);

            modelBuilder.Entity<HistorialTip>()
                .HasOne(h => h.Tip)
                .WithMany(t => t.Historiales)
                .HasForeignKey(h => h.TipId);
        }
    }
}
