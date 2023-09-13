using Microsoft.EntityFrameworkCore;
using System;
using ModelsProject.Models;

namespace DataProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Publisher>? Publishers { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<BooksUsers>? BooksUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksUsers>()
                .HasKey(bu => new { bu.BookId, bu.UserId });

            modelBuilder.Entity<BooksUsers>()
                .HasOne(b => b.Book)
                .WithMany(bu => bu.BooksUsers)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BooksUsers>()
                .HasOne(u => u.User)
                .WithMany(bu => bu.BooksUsers)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithOne(b => b.Publisher);
        }
    }
}
