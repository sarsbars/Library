using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.DAL {
    public class LibraryDbContext : IdentityDbContext {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Book Configuration
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Location)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Loan)
                .WithOne(l => l.Book)
                .HasForeignKey<Book>(b => b.LoanID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
                .Property(b => b.Genre)
                .HasConversion<int>();

            modelBuilder.Entity<Book>()
                .Property(b => b.Condition)
                .HasConversion<int>();

            // Loan Configuration
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Location)
                .WithMany(loc => loc.Loans)
                .HasForeignKey(l => l.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithOne(b => b.Loan)
                .HasForeignKey<Loan>(l => l.BookID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .Property(l => l.LoanStatus)
                .HasConversion<int>();

            // User Configuration
            modelBuilder.Entity<User>()
                .HasOne(u => u.Location)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<int>();

            modelBuilder.Entity<User>()
                .Property(u => u.Gender)
                .HasConversion<int>();

            // Location Configuration
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Books)
                .WithOne(b => b.Location)
                .HasForeignKey(b => b.LocationID);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.Loans)
                .WithOne(l => l.Location)
                .HasForeignKey(l => l.LocationID);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.Users)
                .WithOne(u => u.Location)
                .HasForeignKey(u => u.LocationID);
        }
    }
}