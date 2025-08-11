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
                new User { UserID = 1, LocationID = 1, Name = "Admin User1", Role = RoleType.Admin, Gender = GenderType.PreferNotToDisclose, Email = "admin1@library.com", PhoneNumber = "1234567890", Address = "100 Boye-Ogundiya Way" },
                new User { UserID = 4, LocationID = 2, Name = "Admin User2", Role = RoleType.Admin, Gender = GenderType.Female, Email = "admin2@library.com", PhoneNumber = "1234567891", Address = "200 Hall Street"},     
                new User { UserID = 5, LocationID = 3, Name = "Admin User3", Role = RoleType.Admin, Gender = GenderType.Male, Email = "admin3@library.com", PhoneNumber = "1234567892", Address = "300 Hua Street" },
                new User { UserID = 6, LocationID = 4, Name = "Admin User4", Role = RoleType.Admin, Gender = GenderType.Female, Email = "admin4@library.com", PhoneNumber = "1234567893", Address = "400 Mitchell Road" },
                new User { UserID = 7, LocationID = 5, Name = "Admin User5", Role = RoleType.Admin, Gender = GenderType.Female, Email = "admin5@library.com", PhoneNumber = "1234567894", Address = "500 Solomon Boulevard" },

                new User { UserID = 8, LocationID = 1, Name = "Staff User", Role = RoleType.Staff, Gender = GenderType.Female, Email = "staff1@library.com", PhoneNumber = "1234567890", Address = "100 Boye-Ogundiya Way" },
                new User { UserID = 2, LocationID = 2, Name = "Staff User", Role = RoleType.Staff, Gender = GenderType.Female, Email = "staff2@library.com", PhoneNumber = "1234567891", Address = "200 Hall Street" },
                new User { UserID = 9, LocationID = 3, Name = "Staff User", Role = RoleType.Staff, Gender = GenderType.Male, Email = "staff3@library.com", PhoneNumber = "1234567892", Address = "300 Hua Street" },
                new User { UserID = 10, LocationID = 4, Name = "Staff User", Role = RoleType.Staff, Gender = GenderType.PreferNotToDisclose, Email = "staff4@library.com", PhoneNumber = "1234567893", Address = "400 Mitchell Road" },
                new User { UserID = 11, LocationID = 5, Name = "Staff User", Role = RoleType.Staff, Gender = GenderType.Male, Email = "staff5@library.com", PhoneNumber = "1234567894", Address = "500 Solomon Boulevard" },

                new User { UserID = 3, LocationID = 1, Name = "Reader User1", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader1@library.com", PhoneNumber = "1111111111", Address = "100 Boye-Ogundiya Way" },
                new User { UserID = 12, LocationID = 1, Name = "Reader User2", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader2@library.com", PhoneNumber = "1111111112", Address = "100 Boye-Ogundiya Way" },
                new User { UserID = 13, LocationID = 1, Name = "Reader User3", Role = RoleType.Reader, Gender = GenderType.NonBinary, Email = "reader3@library.com", PhoneNumber = "1111111113", Address = "100 Boye-Ogundiya Way" },
                new User { UserID = 14, LocationID = 1, Name = "Reader User4", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader4@library.com", PhoneNumber = "11111111114", Address = "100 Boye-Ogundiya Way" },
                new User { UserID = 15, LocationID = 1, Name = "Reader User5", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader5@library.com", PhoneNumber = "1111111115", Address = "100 Boye-Ogundiya Way" },

                new User { UserID = 16, LocationID = 2, Name = "Reader User6", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader6@library.com", PhoneNumber = "1111111116", Address = "200 Hall Street" },
                new User { UserID = 17, LocationID = 2, Name = "Reader User7", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader7@library.com", PhoneNumber = "1111111117", Address = "200 Hall Street" },
                new User { UserID = 18, LocationID = 2, Name = "Reader User8", Role = RoleType.Reader, Gender = GenderType.NonBinary, Email = "reader8@library.com", PhoneNumber = "1111111118", Address = "200 Hall Street" },
                new User { UserID = 19, LocationID = 2, Name = "Reader User9", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader9@library.com", PhoneNumber = "11111111119", Address = "200 Hall Street" },
                new User { UserID = 20, LocationID = 2, Name = "Reader User10", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader10@library.com", PhoneNumber = "1111111110", Address = "200 Hall Street" },

                new User { UserID = 21, LocationID = 3, Name = "Reader User11", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader11@library.com", PhoneNumber = "1111111121", Address = "300 Hua Street" },
                new User { UserID = 22, LocationID = 3, Name = "Reader User12", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader12@library.com", PhoneNumber = "1111111122", Address = "300 Hua Street" },
                new User { UserID = 23, LocationID = 3, Name = "Reader User13", Role = RoleType.Reader, Gender = GenderType.NonBinary, Email = "reader13@library.com", PhoneNumber = "1111111123", Address = "300 Hua Street" },
                new User { UserID = 24, LocationID = 3, Name = "Reader User14", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader14@library.com", PhoneNumber = "11111111124", Address = "300 Hua Street" },
                new User { UserID = 25, LocationID = 3, Name = "Reader User15", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader15@library.com", PhoneNumber = "1111111125", Address = "300 Hua Street" },

                new User { UserID = 26, LocationID = 4, Name = "Reader User16", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader16@library.com", PhoneNumber = "1111111126", Address = "400 Mitchell Road" },
                new User { UserID = 27, LocationID = 4, Name = "Reader User17", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader17@library.com", PhoneNumber = "1111111127", Address = "400 Mitchell Road" },
                new User { UserID = 28, LocationID = 4, Name = "Reader User18", Role = RoleType.Reader, Gender = GenderType.NonBinary, Email = "reader18@library.com", PhoneNumber = "1111111128", Address = "400 Mitchell Road" },
                new User { UserID = 29, LocationID = 4, Name = "Reader User19", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader19@library.com", PhoneNumber = "11111111129", Address = "400 Mitchell Road" },
                new User { UserID = 30, LocationID = 4, Name = "Reader User20", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader20@library.com", PhoneNumber = "1111111130", Address = "400 Mitchell Road" },

                new User { UserID = 31, LocationID = 5, Name = "Reader User21", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader21@library.com", PhoneNumber = "1111111131", Address = "500 Solomon Boulevard" },
                new User { UserID = 32, LocationID = 5, Name = "Reader User22", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader22@library.com", PhoneNumber = "1111111132", Address = "500 Solomon Boulevard" },
                new User { UserID = 33, LocationID = 5, Name = "Reader User23", Role = RoleType.Reader, Gender = GenderType.NonBinary, Email = "reader23@library.com", PhoneNumber = "1111111133", Address = "500 Solomon Boulevard" },
                new User { UserID = 34, LocationID = 5, Name = "Reader User24", Role = RoleType.Reader, Gender = GenderType.Male, Email = "reader24@library.com", PhoneNumber = "11111111134", Address = "500 Solomon Boulevard" },
                new User { UserID = 35, LocationID = 5, Name = "Reader User25", Role = RoleType.Reader, Gender = GenderType.Female, Email = "reader25@library.com", PhoneNumber = "1111111135", Address = "500 Solomon Boulevard" }

            );

            modelBuilder.Entity<Book>().HasData(
                // Existing Books
                new Book { BookID = 1, LocationID = 4, ISBN = "9780140186390", Title = "East of Eden", Author = "John Steinbeck", PublicationDate = new DateTime(1952, 9, 19), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 101 },
                new Book { BookID = 2, LocationID = 3, ISBN = "9781526630810", Title = "Piranesi", Author = "Susanna Clarke", PublicationDate = new DateTime(2020, 9, 15), Genre = GenreType.Fantasy, Condition = ConditionType.New, IsAvailable = false, LocationInLibrary = 102 },
                new Book { BookID = 3, LocationID = 3, ISBN = "9780765394866", Title = "All Systems Red", Author = "Martha Wells", PublicationDate = new DateTime(2017, 5, 2), Genre = GenreType.ScienceFiction, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 103 },
                new Book { BookID = 4, LocationID = 5, ISBN = "9780375508325", Title = "House of Leaves", Author = "Mark Z. Danielewski", PublicationDate = new DateTime(2000, 3, 7), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 104 },
                new Book { BookID = 5, LocationID = 2, ISBN = "9780765376671", Title = "Oathbringer", Author = "Brandon Sanderson", PublicationDate = new DateTime(2017, 11, 14), Genre = GenreType.Fantasy, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 105 },
                new Book { BookID = 6, LocationID = 1, ISBN = "9781423103349", Title = "One Piece, Vol. 1: Romance Dawn", Author = "Eiichiro Oda", PublicationDate = new DateTime(1997, 12, 24), Genre = GenreType.Manga, Condition = ConditionType.Used, IsAvailable = false, LocationInLibrary = 106 },
                // Additional John Steinbeck (Fiction)
                new Book { BookID = 7, LocationID = 4, ISBN = "9780142000670", Title = "The Grapes of Wrath", Author = "John Steinbeck", PublicationDate = new DateTime(1939, 4, 14), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 107 },
                new Book { BookID = 8, LocationID = 1, ISBN = "9780140177398", Title = "Of Mice and Men", Author = "John Steinbeck", PublicationDate = new DateTime(1937, 2, 6), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 108 },
                new Book { BookID = 9, LocationID = 2, ISBN = "9780143039631", Title = "Cannery Row", Author = "John Steinbeck", PublicationDate = new DateTime(1945, 1, 2), Genre = GenreType.Fiction, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 109 },
                new Book { BookID = 10, LocationID = 5, ISBN = "9780140186420", Title = "Tortilla Flat", Author = "John Steinbeck", PublicationDate = new DateTime(1935, 5, 28), Genre = GenreType.Fiction, Condition = ConditionType.Damaged, IsAvailable = true, LocationInLibrary = 110 },
                // Additional Susanna Clarke (Fantasy)
                new Book { BookID = 11, LocationID = 3, ISBN = "9781582344164", Title = "Jonathan Strange & Mr Norrell", Author = "Susanna Clarke", PublicationDate = new DateTime(2004, 9, 8), Genre = GenreType.Fantasy, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 111 },
                new Book { BookID = 12, LocationID = 2, ISBN = "9780747593119", Title = "The Ladies of Grace Adieu", Author = "Susanna Clarke", PublicationDate = new DateTime(2006, 10, 16), Genre = GenreType.Fantasy, Condition = ConditionType.Used, IsAvailable = false, LocationInLibrary = 112 },
                // Additional Brandon Sanderson (Fantasy)
                new Book { BookID = 13, LocationID = 2, ISBN = "9780765316882", Title = "The Way of Kings", Author = "Brandon Sanderson", PublicationDate = new DateTime(2010, 8, 31), Genre = GenreType.Fantasy, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 113 },
                new Book { BookID = 14, LocationID = 5, ISBN = "9780765356352", Title = "Mistborn: The Final Empire", Author = "Brandon Sanderson", PublicationDate = new DateTime(2006, 7, 17), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 114 },
                new Book { BookID = 15, LocationID = 3, ISBN = "9780765365279", Title = "Warbreaker", Author = "Brandon Sanderson", PublicationDate = new DateTime(2009, 6, 9), Genre = GenreType.Fantasy, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 115 },
                // Fiction (10 total)
                new Book { BookID = 16, LocationID = 4, ISBN = "9780141185101", Title = "1984", Author = "George Orwell", PublicationDate = new DateTime(1949, 6, 8), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 116 },
                new Book { BookID = 17, LocationID = 1, ISBN = "9780061120084", Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationDate = new DateTime(1960, 7, 11), Genre = GenreType.Fiction, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 117 },
                new Book { BookID = 18, LocationID = 5, ISBN = "9780141439518", Title = "Pride and Prejudice", Author = "Jane Austen", PublicationDate = new DateTime(1813, 1, 28), Genre = GenreType.Fiction, Condition = ConditionType.Used, IsAvailable = false, LocationInLibrary = 118 },
                // NonFiction (4)
                new Book { BookID = 19, LocationID = 3, ISBN = "9780143127574", Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", PublicationDate = new DateTime(2014, 9, 4), Genre = GenreType.NonFiction, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 119 },
                new Book { BookID = 20, LocationID = 2, ISBN = "9780679645573", Title = "Educated", Author = "Tara Westover", PublicationDate = new DateTime(2018, 2, 20), Genre = GenreType.NonFiction, Condition = ConditionType.Mint, IsAvailable = true, LocationInLibrary = 120 },
                new Book { BookID = 21, LocationID = 1, ISBN = "9780385534246", Title = "Becoming", Author = "Michelle Obama", PublicationDate = new DateTime(2018, 11, 13), Genre = GenreType.NonFiction, Condition = ConditionType.Used, IsAvailable = false, LocationInLibrary = 121 },
                new Book { BookID = 22, LocationID = 4, ISBN = "9780140449266", Title = "The Prince", Author = "Niccolò Machiavelli", PublicationDate = new DateTime(1532, 1, 1), Genre = GenreType.NonFiction, Condition = ConditionType.Damaged, IsAvailable = true, LocationInLibrary = 122 },
                // ScienceFiction (5)
                new Book { BookID = 23, LocationID = 3, ISBN = "9780553293357", Title = "Dune", Author = "Frank Herbert", PublicationDate = new DateTime(1965, 8, 1), Genre = GenreType.ScienceFiction, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 123 },
                new Book { BookID = 24, LocationID = 5, ISBN = "9780345391803", Title = "Ender's Game", Author = "Orson Scott Card", PublicationDate = new DateTime(1985, 1, 15), Genre = GenreType.ScienceFiction, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 124 },
                new Book { BookID = 25, LocationID = 2, ISBN = "9780441172719", Title = "Neuromancer", Author = "William Gibson", PublicationDate = new DateTime(1984, 7, 1), Genre = GenreType.ScienceFiction, Condition = ConditionType.Used, IsAvailable = false, LocationInLibrary = 125 },
                new Book { BookID = 26, LocationID = 1, ISBN = "9780060850524", Title = "Brave New World", Author = "Aldous Huxley", PublicationDate = new DateTime(1932, 1, 1), Genre = GenreType.ScienceFiction, Condition = ConditionType.Mint, IsAvailable = true, LocationInLibrary = 126 },
                // Mystery (4)
                new Book { BookID = 27, LocationID = 4, ISBN = "9780446310789", Title = "And Then There Were None", Author = "Agatha Christie", PublicationDate = new DateTime(1939, 11, 6), Genre = GenreType.Mystery, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 127 },
                new Book { BookID = 28, LocationID = 3, ISBN = "9780312971342", Title = "The Girl with the Dragon Tattoo", Author = "Stieg Larsson", PublicationDate = new DateTime(2005, 8, 1), Genre = GenreType.Mystery, Condition = ConditionType.New, IsAvailable = false, LocationInLibrary = 128 },
                new Book { BookID = 29, LocationID = 2, ISBN = "9780141192666", Title = "The Hound of the Baskervilles", Author = "Arthur Conan Doyle", PublicationDate = new DateTime(1902, 4, 25), Genre = GenreType.Mystery, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 129 },
                new Book { BookID = 30, LocationID = 1, ISBN = "9780062073488", Title = "Gone Girl", Author = "Gillian Flynn", PublicationDate = new DateTime(2012, 5, 24), Genre = GenreType.Mystery, Condition = ConditionType.Mint, IsAvailable = true, LocationInLibrary = 130 },
                // Romance (4)
                new Book { BookID = 31, LocationID = 5, ISBN = "9780451524935", Title = "Jane Eyre", Author = "Charlotte Brontë", PublicationDate = new DateTime(1847, 10, 16), Genre = GenreType.Romance, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 131 },
                new Book { BookID = 32, LocationID = 3, ISBN = "9780143107729", Title = "Wuthering Heights", Author = "Emily Brontë", PublicationDate = new DateTime(1847, 12, 1), Genre = GenreType.Romance, Condition = ConditionType.Damaged, IsAvailable = true, LocationInLibrary = 132 },
                new Book { BookID = 33, LocationID = 4, ISBN = "9780062358202", Title = "Me Before You", Author = "Jojo Moyes", PublicationDate = new DateTime(2012, 1, 5), Genre = GenreType.Romance, Condition = ConditionType.New, IsAvailable = false, LocationInLibrary = 133 },
                new Book { BookID = 34, LocationID = 2, ISBN = "9780143125235", Title = "The Fault in Our Stars", Author = "John Green", PublicationDate = new DateTime(2012, 1, 10), Genre = GenreType.Romance, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 134 },
                // Fantasy (6)
                new Book { BookID = 35, LocationID = 1, ISBN = "9780547928197", Title = "The Hobbit", Author = "J.R.R. Tolkien", PublicationDate = new DateTime(1937, 9, 21), Genre = GenreType.Fantasy, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 135 },
                new Book { BookID = 36, LocationID = 5, ISBN = "9780553573404", Title = "A Game of Thrones", Author = "George R.R. Martin", PublicationDate = new DateTime(1996, 8, 6), Genre = GenreType.Fantasy, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 136 },
                // Childrens (4)
                new Book { BookID = 37, LocationID = 3, ISBN = "9780590353427", Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", PublicationDate = new DateTime(1997, 6, 26), Genre = GenreType.Childrens, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 137 },
                new Book { BookID = 38, LocationID = 4, ISBN = "9780064400558", Title = "Charlotte's Web", Author = "E.B. White", PublicationDate = new DateTime(1952, 10, 15), Genre = GenreType.Childrens, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 138 },
                new Book { BookID = 39, LocationID = 2, ISBN = "9780142402511", Title = "Matilda", Author = "Roald Dahl", PublicationDate = new DateTime(1988, 10, 1), Genre = GenreType.Childrens, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 139 },
                new Book { BookID = 40, LocationID = 1, ISBN = "9780064404990", Title = "The Lion, the Witch and the Wardrobe", Author = "C.S. Lewis", PublicationDate = new DateTime(1950, 10, 16), Genre = GenreType.Childrens, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 140 },
                // Humour (4)
                new Book { BookID = 41, LocationID = 5, ISBN = "9780140287028", Title = "Good Omens", Author = "Neil Gaiman & Terry Pratchett", PublicationDate = new DateTime(1990, 5, 1), Genre = GenreType.Humour, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 141 },
                new Book { BookID = 42, LocationID = 3, ISBN = "9780393355529", Title = "Catch-22", Author = "Joseph Heller", PublicationDate = new DateTime(1961, 10, 10), Genre = GenreType.Humour, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 142 },
                new Book { BookID = 43, LocationID = 4, ISBN = "9780142437261", Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams", PublicationDate = new DateTime(1979, 10, 12), Genre = GenreType.Humour, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 143 },
                new Book { BookID = 44, LocationID = 2, ISBN = "9781594483295", Title = "Bossypants", Author = "Tina Fey", PublicationDate = new DateTime(2011, 4, 5), Genre = GenreType.Humour, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 144 },
                // Technology (4)
                new Book { BookID = 45, LocationID = 1, ISBN = "9780596523022", Title = "Clean Code", Author = "Robert C. Martin", PublicationDate = new DateTime(2008, 8, 1), Genre = GenreType.Technology, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 145 },
                new Book { BookID = 46, LocationID = 3, ISBN = "9780135957059", Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas", PublicationDate = new DateTime(1999, 10, 20), Genre = GenreType.Technology, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 146 },
                new Book { BookID = 47, LocationID = 5, ISBN = "9780134685991", Title = "Designing Data-Intensive Applications", Author = "Martin Kleppmann", PublicationDate = new DateTime(2017, 3, 16), Genre = GenreType.Technology, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 147 },
                new Book { BookID = 48, LocationID = 2, ISBN = "9781492052203", Title = "Site Reliability Engineering", Author = "Niall Murphy", PublicationDate = new DateTime(2016, 4, 18), Genre = GenreType.Technology, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 148 },
                // Science (4)
                new Book { BookID = 49, LocationID = 4, ISBN = "9780393355628", Title = "A Brief History of Time", Author = "Stephen Hawking", PublicationDate = new DateTime(1988, 3, 1), Genre = GenreType.Science, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 149 },
                new Book { BookID = 50, LocationID = 1, ISBN = "9780143111580", Title = "The Selfish Gene", Author = "Richard Dawkins", PublicationDate = new DateTime(1976, 6, 1), Genre = GenreType.Science, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 150 },
                new Book { BookID = 51, LocationID = 3, ISBN = "9780374533557", Title = "The Immortal Life of Henrietta Lacks", Author = "Rebecca Skloot", PublicationDate = new DateTime(2010, 2, 2), Genre = GenreType.Science, Condition = ConditionType.Used, IsAvailable = false, LocationInLibrary = 151 },
                new Book { BookID = 52, LocationID = 2, ISBN = "9780141988511", Title = "The Order of Time", Author = "Carlo Rovelli", PublicationDate = new DateTime(2018, 5, 8), Genre = GenreType.Science, Condition = ConditionType.Mint, IsAvailable = true, LocationInLibrary = 152 },
                // Textbooks (4)
                new Book { BookID = 53, LocationID = 5, ISBN = "9780131103627", Title = "Calculus: Early Transcendentals", Author = "James Stewart", PublicationDate = new DateTime(2002, 6, 7), Genre = GenreType.Textbooks, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 153 },
                new Book { BookID = 54, LocationID = 1, ISBN = "9780134438986", Title = "Computer Networking: A Top-Down Approach", Author = "James Kurose", PublicationDate = new DateTime(2016, 3, 4), Genre = GenreType.Textbooks, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 154 },
                new Book { BookID = 55, LocationID = 3, ISBN = "9780133594140", Title = "Organic Chemistry", Author = "Paula Yurkanis Bruice", PublicationDate = new DateTime(2013, 1, 5), Genre = GenreType.Textbooks, Condition = ConditionType.Used, IsAvailable = false, LocationInLibrary = 155 },
                new Book { BookID = 56, LocationID = 4, ISBN = "9780134093413", Title = "Introduction to Psychology", Author = "James W. Kalat", PublicationDate = new DateTime(2016, 1, 1), Genre = GenreType.Textbooks, Condition = ConditionType.Mint, IsAvailable = true, LocationInLibrary = 156 },
                // GraphicNovel (4)
                new Book { BookID = 57, LocationID = 2, ISBN = "9781401225759", Title = "Watchmen", Author = "Alan Moore", PublicationDate = new DateTime(1987, 9, 1), Genre = GenreType.GraphicNovel, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 157 },
                new Book { BookID = 58, LocationID = 1, ISBN = "9781401238964", Title = "V for Vendetta", Author = "Alan Moore", PublicationDate = new DateTime(1989, 5, 1), Genre = GenreType.GraphicNovel, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 158 },
                new Book { BookID = 59, LocationID = 5, ISBN = "9780785190219", Title = "Saga, Vol. 1", Author = "Brian K. Vaughan", PublicationDate = new DateTime(2012, 10, 10), Genre = GenreType.GraphicNovel, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 159 },
                new Book { BookID = 60, LocationID = 3, ISBN = "9781401248192", Title = "Maus I", Author = "Art Spiegelman", PublicationDate = new DateTime(1986, 8, 1), Genre = GenreType.GraphicNovel, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 160 },
                // Magazine (4)
                new Book { BookID = 61, LocationID = 4, ISBN = "9770028088008", Title = "National Geographic, Jan 2025", Author = "Various", PublicationDate = new DateTime(2025, 1, 1), Genre = GenreType.Magazine, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 161 },
                new Book { BookID = 62, LocationID = 2, ISBN = "9770028088015", Title = "The New Yorker, Feb 2025", Author = "Various", PublicationDate = new DateTime(2025, 2, 1), Genre = GenreType.Magazine, Condition = ConditionType.Mint, IsAvailable = true, LocationInLibrary = 162 },
                new Book { BookID = 63, LocationID = 1, ISBN = "9770028088022", Title = "Scientific American, Mar 2025", Author = "Various", PublicationDate = new DateTime(2025, 3, 1), Genre = GenreType.Magazine, Condition = ConditionType.New, IsAvailable = false, LocationInLibrary = 163 },
                new Book { BookID = 64, LocationID = 3, ISBN = "9770028088039", Title = "Time, Apr 2025", Author = "Various", PublicationDate = new DateTime(2025, 4, 1), Genre = GenreType.Magazine, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 164 },
                // Manga (5)
                new Book { BookID = 65, LocationID = 1, ISBN = "9781421501680", Title = "Naruto, Vol. 1", Author = "Masashi Kishimoto", PublicationDate = new DateTime(2003, 7, 7), Genre = GenreType.Manga, Condition = ConditionType.Used, IsAvailable = true, LocationInLibrary = 165 },
                new Book { BookID = 66, LocationID = 5, ISBN = "9781421520544", Title = "Attack on Titan, Vol. 1", Author = "Hajime Isayama", PublicationDate = new DateTime(2012, 6, 19), Genre = GenreType.Manga, Condition = ConditionType.New, IsAvailable = true, LocationInLibrary = 166 },
                new Book { BookID = 67, LocationID = 2, ISBN = "9781591161783", Title = "Fullmetal Alchemist, Vol. 1", Author = "Hiromu Arakawa", PublicationDate = new DateTime(2005, 5, 3), Genre = GenreType.Manga, Condition = ConditionType.Mint, IsAvailable = false, LocationInLibrary = 167 }
            );

            modelBuilder.Entity<Loan>().HasData(
                // Existing Loans
                new Loan { LoanID = 1, LocationID = 3, BookID = 2, UserID = 3, DueDate = new DateTime(2025, 8, 15), DateBorrowed = new DateTime(2025, 8, 1), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 2, LocationID = 3, BookID = 3, UserID = 2, DueDate = new DateTime(2025, 7, 31), DateBorrowed = new DateTime(2025, 7, 17), LoanStatus = LoanStatusType.Overdue },
                new Loan { LoanID = 3, LocationID = 1, BookID = 6, UserID = 1, DueDate = new DateTime(2025, 8, 22), DateBorrowed = new DateTime(2025, 8, 8), LoanStatus = LoanStatusType.OnHold },
                // New Loans for UserID 3 (Reader User)
                new Loan { LoanID = 4, LocationID = 3, BookID = 11, UserID = 3, DueDate = new DateTime(2025, 9, 10), DateBorrowed = new DateTime(2025, 8, 27), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 5, LocationID = 3, BookID = 15, UserID = 3, DueDate = new DateTime(2025, 7, 15), DateBorrowed = new DateTime(2025, 7, 1), LoanStatus = LoanStatusType.Overdue },
                new Loan { LoanID = 6, LocationID = 2, BookID = 12, UserID = 3, DueDate = new DateTime(2025, 9, 20), DateBorrowed = new DateTime(2025, 8, 6), LoanStatus = LoanStatusType.OnHold },
                new Loan { LoanID = 7, LocationID = 4, BookID = 16, UserID = 3, DueDate = new DateTime(2025, 6, 30), DateBorrowed = new DateTime(2025, 6, 16), LoanStatus = LoanStatusType.Returned },
                new Loan { LoanID = 8, LocationID = 3, BookID = 19, UserID = 3, DueDate = new DateTime(2025, 9, 15), DateBorrowed = new DateTime(2025, 8, 31), LoanStatus = LoanStatusType.TakenOut },
                // Loans for UserID 12
                new Loan { LoanID = 9, LocationID = 2, BookID = 9, UserID = 12, DueDate = new DateTime(2025, 9, 5), DateBorrowed = new DateTime(2025, 8, 22), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 10, LocationID = 2, BookID = 25, UserID = 12, DueDate = new DateTime(2025, 7, 20), DateBorrowed = new DateTime(2025, 7, 6), LoanStatus = LoanStatusType.Overdue },
                // Loans for UserID 13
                new Loan { LoanID = 11, LocationID = 3, BookID = 23, UserID = 13, DueDate = new DateTime(2025, 9, 12), DateBorrowed = new DateTime(2025, 8, 29), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 12, LocationID = 3, BookID = 28, UserID = 13, DueDate = new DateTime(2025, 9, 25), DateBorrowed = new DateTime(2025, 8, 11), LoanStatus = LoanStatusType.OnHold },
                // Loans for UserID 14
                new Loan { LoanID = 13, LocationID = 4, BookID = 27, UserID = 14, DueDate = new DateTime(2025, 6, 15), DateBorrowed = new DateTime(2025, 6, 1), LoanStatus = LoanStatusType.Returned },
                new Loan { LoanID = 14, LocationID = 4, BookID = 33, UserID = 14, DueDate = new DateTime(2025, 7, 10), DateBorrowed = new DateTime(2025, 6, 26), LoanStatus = LoanStatusType.Overdue },
                // Loans for UserID 15
                new Loan { LoanID = 15, LocationID = 5, BookID = 37, UserID = 15, DueDate = new DateTime(2025, 9, 8), DateBorrowed = new DateTime(2025, 8, 25), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 16, LocationID = 5, BookID = 47, UserID = 15, DueDate = new DateTime(2025, 9, 30), DateBorrowed = new DateTime(2025, 8, 16), LoanStatus = LoanStatusType.OnHold },
                // Loans for UserID 16
                new Loan { LoanID = 17, LocationID = 1, BookID = 35, UserID = 16, DueDate = new DateTime(2025, 6, 20), DateBorrowed = new DateTime(2025, 6, 6), LoanStatus = LoanStatusType.Returned },
                new Loan { LoanID = 18, LocationID = 1, BookID = 45, UserID = 16, DueDate = new DateTime(2025, 7, 25), DateBorrowed = new DateTime(2025, 7, 11), LoanStatus = LoanStatusType.Overdue },
                // Loans for UserID 17
                new Loan { LoanID = 19, LocationID = 2, BookID = 39, UserID = 17, DueDate = new DateTime(2025, 9, 10), DateBorrowed = new DateTime(2025, 8, 27), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 20, LocationID = 2, BookID = 57, UserID = 17, DueDate = new DateTime(2025, 9, 15), DateBorrowed = new DateTime(2025, 8, 1), LoanStatus = LoanStatusType.OnHold },
                // Loans for UserID 18
                new Loan { LoanID = 21, LocationID = 3, BookID = 51, UserID = 18, DueDate = new DateTime(2025, 6, 25), DateBorrowed = new DateTime(2025, 6, 11), LoanStatus = LoanStatusType.Returned },
                new Loan { LoanID = 22, LocationID = 3, BookID = 55, UserID = 18, DueDate = new DateTime(2025, 7, 30), DateBorrowed = new DateTime(2025, 7, 16), LoanStatus = LoanStatusType.Overdue },
                // Loans for UserID 19
                new Loan { LoanID = 23, LocationID = 4, BookID = 43, UserID = 19, DueDate = new DateTime(2025, 9, 5), DateBorrowed = new DateTime(2025, 8, 22), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 24, LocationID = 4, BookID = 61, UserID = 19, DueDate = new DateTime(2025, 9, 20), DateBorrowed = new DateTime(2025, 8, 6), LoanStatus = LoanStatusType.OnHold },
                // Loans for UserID 20
                new Loan { LoanID = 25, LocationID = 5, BookID = 59, UserID = 20, DueDate = new DateTime(2025, 6, 30), DateBorrowed = new DateTime(2025, 6, 16), LoanStatus = LoanStatusType.Returned },
                new Loan { LoanID = 26, LocationID = 5, BookID = 53, UserID = 20, DueDate = new DateTime(2025, 7, 15), DateBorrowed = new DateTime(2025, 7, 1), LoanStatus = LoanStatusType.Overdue },
                // Loans for UserID 21
                new Loan { LoanID = 27, LocationID = 1, BookID = 65, UserID = 21, DueDate = new DateTime(2025, 9, 12), DateBorrowed = new DateTime(2025, 8, 29), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 28, LocationID = 1, BookID = 63, UserID = 21, DueDate = new DateTime(2025, 9, 25), DateBorrowed = new DateTime(2025, 8, 11), LoanStatus = LoanStatusType.OnHold },
                // Loans for UserID 22
                new Loan { LoanID = 29, LocationID = 2, BookID = 67, UserID = 22, DueDate = new DateTime(2025, 6, 15), DateBorrowed = new DateTime(2025, 6, 1), LoanStatus = LoanStatusType.Returned },
                new Loan { LoanID = 30, LocationID = 2, BookID = 20, UserID = 22, DueDate = new DateTime(2025, 7, 10), DateBorrowed = new DateTime(2025, 6, 26), LoanStatus = LoanStatusType.Overdue },
                // Loans for UserID 23
                new Loan { LoanID = 31, LocationID = 3, BookID = 28, UserID = 23, DueDate = new DateTime(2025, 9, 8), DateBorrowed = new DateTime(2025, 8, 25), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 32, LocationID = 3, BookID = 19, UserID = 23, DueDate = new DateTime(2025, 6, 20), DateBorrowed = new DateTime(2025, 6, 6), LoanStatus = LoanStatusType.Returned },
                // Loans for UserID 24
                new Loan { LoanID = 33, LocationID = 4, BookID = 49, UserID = 24, DueDate = new DateTime(2025, 9, 10), DateBorrowed = new DateTime(2025, 8, 27), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 34, LocationID = 4, BookID = 27, UserID = 24, DueDate = new DateTime(2025, 7, 25), DateBorrowed = new DateTime(2025, 7, 11), LoanStatus = LoanStatusType.Overdue },
                // Loans for UserID 25
                new Loan { LoanID = 35, LocationID = 5, BookID = 41, UserID = 25, DueDate = new DateTime(2025, 9, 15), DateBorrowed = new DateTime(2025, 8, 31), LoanStatus = LoanStatusType.TakenOut },
                new Loan { LoanID = 36, LocationID = 5, BookID = 33, UserID = 25, DueDate = new DateTime(2025, 9, 20), DateBorrowed = new DateTime(2025, 8, 6), LoanStatus = LoanStatusType.OnHold }
            );
        }
    }
}