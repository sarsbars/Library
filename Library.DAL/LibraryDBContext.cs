using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.DAL {
    public class LibraryDBContext : IdentityDbContext {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
            : base(options) {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Book-Loan one-to-many
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Loans)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookID)
                .OnDelete(DeleteBehavior.Cascade);

            // Book-Location one-to-many
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Location)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .Property(b => b.Genre)
                .HasConversion<int>();

            modelBuilder.Entity<Book>()
                .Property(b => b.Condition)
                .HasConversion<int>();

            // Loan-Location one-to-many
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Location)
                .WithMany(loc => loc.Loans)
                .HasForeignKey(l => l.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            // Loan-User one-to-many
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .Property(l => l.LoanStatus)
                .HasConversion<int>();

            // User-Location one-to-many
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

            // Locations
            modelBuilder.Entity<Location>()
                .Property(l => l.LocationName)
                .HasConversion<int>();

            // Seed Data
            modelBuilder.Entity<Location>().HasData(
                new Location { LocationID = 1, LocationName = LocationNameType.BoyeOgundiyaAcademicLibrary, Address = "100 Boye-Ogundiya Way", PhoneNumber = "1234567890" },
                new Location { LocationID = 2, LocationName = LocationNameType.HallResearchCenter, Address = "200 Hall Street", PhoneNumber = "1234567891" },
                new Location { LocationID = 3, LocationName = LocationNameType.HuaKnowledgeInstitute, Address = "300 Hua Avenue", PhoneNumber = "1234567892" },
                new Location { LocationID = 4, LocationName = LocationNameType.MitchellMemorialLibrary, Address = "400 Mitchell Road", PhoneNumber = "1234567893" },
                new Location { LocationID = 5, LocationName = LocationNameType.SolomonLearningCommons, Address = "500 Solomon Boulevard", PhoneNumber = "1234567894" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, LocationID = 1, Name = "Admin User", Role = RoleType.Admin, Gender = GenderType.PreferNotToDisclose, Email = "admin@library.com", PhoneNumber = "1234567890", Address = "100 Boye-Ogundiya Way" },
                new User { UserID = 2, LocationID = 2, Name = "Staff User", Role = RoleType.Staff, Gender = GenderType.Male, Email = "staff@library.com", PhoneNumber = "1234567891", Address = "200 Hall Street" },
                new User { UserID = 3, LocationID = 3, Name = "Reader User", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader@library.com", PhoneNumber = "1234567892", Address = "300 Hua Avenue" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookID = 1, LocationID = 4, ISBN = "9780140186390", Title = "East of Eden", Author = "John Steinbeck", PublicationDate = new DateTime(1952, 9, 19), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 101 },
                new Book { BookID = 2, LocationID = 3, ISBN = "9781526630810", Title = "Piranesi", Author = "Susanna Clarke", PublicationDate = new DateTime(2020, 9, 15), Genre = GenreType.Fantasy, Condition = ConditionType.New, IsAvailable = false, LocationInLibrary = 102 },
                new Book { BookID = 3, LocationID = 3, ISBN = "9780765394866", Title = "All Systems Red", Author = "Martha Wells", PublicationDate = new DateTime(2017, 5, 2), Genre = GenreType.ScienceFiction, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 103 },
                new Book { BookID = 4, LocationID = 5, ISBN = "9780375508325", Title = "House of Leaves", Author = "Mark Z. Danielewski", PublicationDate = new DateTime(2000, 3, 7), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 104 },
                new Book { BookID = 5, LocationID = 2, ISBN = "9780765376671", Title = "Oathbringer", Author = "Brandon Sanderson", PublicationDate = new DateTime(2017, 11, 14), Genre = GenreType.Fantasy, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 105 },
                new Book { BookID = 6, LocationID = 1, ISBN = "9781423103349", Title = "One Piece, Vol. 1: Romance Dawn", Author = "Eiichiro Oda", PublicationDate = new DateTime(1997, 12, 24), Genre = GenreType.Manga, Condition = ConditionType.Used, IsAvailable = false, LocationInLibrary = 106 }
            );

            modelBuilder.Entity<Loan>().HasData(
                new Loan { LoanID = 1, LocationID = 3, BookID = 2, UserID = 3, DueDate = new DateTime(2025, 8, 15), DateBorrowed = new DateTime(2025, 8, 1), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 2, LocationID = 3, BookID = 3, UserID = 2, DueDate = new DateTime(2025, 7, 31), DateBorrowed = new DateTime(2025, 7, 17), LoanStatus = LoanStatusType.Overdue },
                new Loan { LoanID = 3, LocationID = 1, BookID = 6, UserID = 1, DueDate = new DateTime(2025, 8, 22), DateBorrowed = new DateTime(2025, 8, 8), LoanStatus = LoanStatusType.OnHold }
            );
        }
    }
}