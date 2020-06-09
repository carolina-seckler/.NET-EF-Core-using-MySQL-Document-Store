using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Scaffold.Entities
{
    public partial class libraryContext : DbContext
    {
        public libraryContext()
        {
        }

        public libraryContext(DbContextOptions<libraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<book> book { get; set; }
        public virtual DbSet<publisher> publisher { get; set; }
        public virtual DbSet<volume> volume { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=library");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<book>(entity =>
            {
                entity.HasIndex(e => e.idpublisher)
                    .HasName("idpublisher");

                entity.Property(e => e.author)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.isbn)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.language)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.idpublisherNavigation)
                    .WithMany(p => p.book)
                    .HasForeignKey(d => d.idpublisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_ibfk_1");
            });

            modelBuilder.Entity<publisher>(entity =>
            {
                entity.Property(e => e.address).HasColumnType("json");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<volume>(entity =>
            {
                entity.HasIndex(e => e.idbook)
                    .HasName("idbook");

                entity.Property(e => e.title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.idbookNavigation)
                    .WithMany(p => p.volume)
                    .HasForeignKey(d => d.idbook)
                    .HasConstraintName("volume_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
