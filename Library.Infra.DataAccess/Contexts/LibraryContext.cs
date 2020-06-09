using Microsoft.EntityFrameworkCore;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infra.DataAccess.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Volume> Volume { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySQL("server=18.229.29.219;port=3306;database=Library;user=libraryuser;password=G6Wu^X+T");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.IdPublisher)
                    .HasName("idpublisher");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ISBN)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPublisherNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdPublisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_ibfk_1");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.Address).HasColumnType("json");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.HasIndex(e => e.IdBook)
                    .HasName("idbook");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Volumes)
                    .HasForeignKey(d => d.IdBook)
                    .HasConstraintName("volume_ibfk_1")
                    .OnDelete(DeleteBehavior.ClientCascade);
            });
        }
    }
}
