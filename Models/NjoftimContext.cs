using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Njoftime_API.Models
{
    public partial class NjoftimContext : DbContext
    {
        public NjoftimContext()
        {
        }

        public NjoftimContext(DbContextOptions<NjoftimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ministrite> Ministrite { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ORLAND-KARAMANI;Database=Njoftim;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ministrite>(entity =>
            {
                entity.Property(e => e.Ministria)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasOne(d => d.Ministria)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.MinistriaId)
                    .HasConstraintName("FK_Tags_Ministrite");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Tags_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Emer).HasMaxLength(50);

                entity.Property(e => e.Gjinia)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Mbiemer).HasMaxLength(50);
            });
        }
    }
}
