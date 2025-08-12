using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "Condition", "Genre", "ISBN", "IsAvailable", "LocationID", "LocationInLibrary", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 7, "John Steinbeck", 2, 0, "9780142000670", true, 4, 107, new DateTime(1939, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Grapes of Wrath" },
                    { 8, "John Steinbeck", 2, 0, "9780140177398", true, 1, 108, new DateTime(1937, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Of Mice and Men" },
                    { 9, "John Steinbeck", 0, 0, "9780143039631", false, 2, 109, new DateTime(1945, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cannery Row" },
                    { 10, "John Steinbeck", 3, 0, "9780140186420", true, 5, 110, new DateTime(1935, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tortilla Flat" },
                    { 11, "Susanna Clarke", 1, 5, "9781582344164", true, 3, 111, new DateTime(2004, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jonathan Strange & Mr Norrell" },
                    { 12, "Susanna Clarke", 2, 5, "9780747593119", false, 2, 112, new DateTime(2006, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ladies of Grace Adieu" },
                    { 13, "Brandon Sanderson", 1, 5, "9780765316882", true, 2, 113, new DateTime(2010, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Way of Kings" },
                    { 14, "Brandon Sanderson", 2, 0, "9780765356352", true, 5, 114, new DateTime(2006, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistborn: The Final Empire" },
                    { 15, "Brandon Sanderson", 0, 5, "9780765365279", false, 3, 115, new DateTime(2009, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warbreaker" },
                    { 16, "George Orwell", 2, 0, "9780141185101", true, 4, 116, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984" },
                    { 17, "Harper Lee", 1, 0, "9780061120084", true, 1, 117, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird" },
                    { 18, "Jane Austen", 2, 0, "9780141439518", false, 5, 118, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice" },
                    { 19, "Yuval Noah Harari", 1, 1, "9780143127574", true, 3, 119, new DateTime(2014, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sapiens: A Brief History of Humankind" },
                    { 20, "Tara Westover", 0, 1, "9780679645573", true, 2, 120, new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educated" },
                    { 21, "Michelle Obama", 2, 1, "9780385534246", false, 1, 121, new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Becoming" },
                    { 22, "Niccolò Machiavelli", 3, 1, "9780140449266", true, 4, 122, new DateTime(1532, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Prince" },
                    { 23, "Frank Herbert", 2, 2, "9780553293357", true, 3, 123, new DateTime(1965, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune" },
                    { 24, "Orson Scott Card", 1, 2, "9780345391803", true, 5, 124, new DateTime(1985, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ender's Game" },
                    { 25, "William Gibson", 2, 2, "9780441172719", false, 2, 125, new DateTime(1984, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neuromancer" },
                    { 26, "Aldous Huxley", 0, 2, "9780060850524", true, 1, 126, new DateTime(1932, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brave New World" },
                    { 27, "Agatha Christie", 2, 3, "9780446310789", true, 4, 127, new DateTime(1939, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "And Then There Were None" },
                    { 28, "Stieg Larsson", 1, 3, "9780312971342", false, 3, 128, new DateTime(2005, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Girl with the Dragon Tattoo" },
                    { 29, "Arthur Conan Doyle", 2, 3, "9780141192666", true, 2, 129, new DateTime(1902, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hound of the Baskervilles" },
                    { 30, "Gillian Flynn", 0, 3, "9780062073488", true, 1, 130, new DateTime(2012, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gone Girl" },
                    { 31, "Charlotte Brontë", 2, 4, "9780451524935", true, 5, 131, new DateTime(1847, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Eyre" },
                    { 32, "Emily Brontë", 3, 4, "9780143107729", true, 3, 132, new DateTime(1847, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wuthering Heights" },
                    { 33, "Jojo Moyes", 1, 4, "9780062358202", false, 4, 133, new DateTime(2012, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me Before You" },
                    { 34, "John Green", 2, 4, "9780143125235", true, 2, 134, new DateTime(2012, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Fault in Our Stars" },
                    { 35, "J.R.R. Tolkien", 2, 5, "9780547928197", true, 1, 135, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit" },
                    { 36, "George R.R. Martin", 1, 5, "9780553573404", true, 5, 136, new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" },
                    { 37, "J.K. Rowling", 1, 6, "9780590353427", true, 3, 137, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Sorcerer's Stone" },
                    { 38, "E.B. White", 2, 6, "9780064400558", true, 4, 138, new DateTime(1952, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlotte's Web" },
                    { 39, "Roald Dahl", 0, 6, "9780142402511", false, 2, 139, new DateTime(1988, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matilda" },
                    { 40, "C.S. Lewis", 2, 6, "9780064404990", true, 1, 140, new DateTime(1950, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lion, the Witch and the Wardrobe" },
                    { 41, "Neil Gaiman & Terry Pratchett", 1, 7, "9780140287028", true, 5, 141, new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Omens" },
                    { 42, "Joseph Heller", 2, 7, "9780393355529", true, 3, 142, new DateTime(1961, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Catch-22" },
                    { 43, "Douglas Adams", 0, 7, "9780142437261", false, 4, 143, new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hitchhiker's Guide to the Galaxy" },
                    { 44, "Tina Fey", 1, 7, "9781594483295", true, 2, 144, new DateTime(2011, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bossypants" },
                    { 45, "Robert C. Martin", 1, 8, "9780596523022", true, 1, 145, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean Code" },
                    { 46, "Andrew Hunt & David Thomas", 2, 8, "9780135957059", true, 3, 146, new DateTime(1999, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Pragmatic Programmer" },
                    { 47, "Martin Kleppmann", 0, 8, "9780134685991", false, 5, 147, new DateTime(2017, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Designing Data-Intensive Applications" },
                    { 48, "Niall Murphy", 1, 8, "9781492052203", true, 2, 148, new DateTime(2016, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Site Reliability Engineering" },
                    { 49, "Stephen Hawking", 2, 9, "9780393355628", true, 4, 149, new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Brief History of Time" },
                    { 50, "Richard Dawkins", 1, 9, "9780143111580", true, 1, 150, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 51, "Rebecca Skloot", 2, 9, "9780374533557", false, 3, 151, new DateTime(2010, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Immortal Life of Henrietta Lacks" },
                    { 52, "Carlo Rovelli", 0, 9, "9780141988511", true, 2, 152, new DateTime(2018, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Order of Time" },
                    { 53, "James Stewart", 2, 10, "9780131103627", true, 5, 153, new DateTime(2002, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calculus: Early Transcendentals" },
                    { 54, "James Kurose", 1, 10, "9780134438986", true, 1, 154, new DateTime(2016, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Networking: A Top-Down Approach" },
                    { 55, "Paula Yurkanis Bruice", 2, 10, "9780133594140", false, 3, 155, new DateTime(2013, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organic Chemistry" },
                    { 56, "James W. Kalat", 0, 10, "9780134093413", true, 4, 156, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to Psychology" },
                    { 57, "Alan Moore", 2, 11, "9781401225759", true, 2, 157, new DateTime(1987, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Watchmen" },
                    { 58, "Alan Moore", 1, 11, "9781401238964", true, 1, 158, new DateTime(1989, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "V for Vendetta" },
                    { 59, "Brian K. Vaughan", 0, 11, "9780785190219", false, 5, 159, new DateTime(2012, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saga, Vol. 1" },
                    { 60, "Art Spiegelman", 2, 11, "9781401248192", true, 3, 160, new DateTime(1986, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maus I" },
                    { 61, "Various", 1, 12, "9770028088008", true, 4, 161, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "National Geographic, Jan 2025" },
                    { 62, "Various", 0, 12, "9770028088015", true, 2, 162, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The New Yorker, Feb 2025" },
                    { 63, "Various", 1, 12, "9770028088022", false, 1, 163, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scientific American, Mar 2025" },
                    { 64, "Various", 2, 12, "9770028088039", true, 3, 164, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time, Apr 2025" },
                    { 65, "Masashi Kishimoto", 2, 13, "9781421501680", true, 1, 165, new DateTime(2003, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naruto, Vol. 1" },
                    { 66, "Hajime Isayama", 1, 13, "9781421520544", true, 5, 166, new DateTime(2012, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attack on Titan, Vol. 1" },
                    { 67, "Hiromu Arakawa", 0, 13, "9781591161783", false, 2, 167, new DateTime(2005, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fullmetal Alchemist, Vol. 1" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "admin1@library.com", "Admin User1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "Email", "Gender" },
                values: new object[] { "staff2@library.com", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "Address", "Email", "Gender", "LocationID", "Name", "PhoneNumber" },
                values: new object[] { "100 Boye-Ogundiya Way", "reader1@library.com", 0, 1, "Reader User1", "1111111111" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "Email", "Gender", "LocationID", "Name", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 4, "200 Hall Street", "admin2@library.com", 1, 2, "Admin User2", "1234567891", 0 },
                    { 5, "300 Hua Street", "admin3@library.com", 0, 3, "Admin User3", "1234567892", 0 },
                    { 6, "400 Mitchell Road", "admin4@library.com", 1, 4, "Admin User4", "1234567893", 0 },
                    { 7, "500 Solomon Boulevard", "admin5@library.com", 1, 5, "Admin User5", "1234567894", 0 },
                    { 8, "100 Boye-Ogundiya Way", "staff1@library.com", 1, 1, "Staff User", "1234567890", 1 },
                    { 9, "300 Hua Street", "staff3@library.com", 0, 3, "Staff User", "1234567892", 1 },
                    { 10, "400 Mitchell Road", "staff4@library.com", 3, 4, "Staff User", "1234567893", 1 },
                    { 11, "500 Solomon Boulevard", "staff5@library.com", 0, 5, "Staff User", "1234567894", 1 },
                    { 12, "100 Boye-Ogundiya Way", "reader2@library.com", 1, 1, "Reader User2", "1111111112", 2 },
                    { 13, "100 Boye-Ogundiya Way", "reader3@library.com", 2, 1, "Reader User3", "1111111113", 2 },
                    { 14, "100 Boye-Ogundiya Way", "reader4@library.com", 0, 1, "Reader User4", "11111111114", 2 },
                    { 15, "100 Boye-Ogundiya Way", "reader5@library.com", 1, 1, "Reader User5", "1111111115", 2 },
                    { 16, "200 Hall Street", "reader6@library.com", 0, 2, "Reader User6", "1111111116", 2 },
                    { 17, "200 Hall Street", "reader7@library.com", 1, 2, "Reader User7", "1111111117", 2 },
                    { 18, "200 Hall Street", "reader8@library.com", 2, 2, "Reader User8", "1111111118", 2 },
                    { 19, "200 Hall Street", "reader9@library.com", 0, 2, "Reader User9", "11111111119", 2 },
                    { 20, "200 Hall Street", "reader10@library.com", 1, 2, "Reader User10", "1111111110", 2 },
                    { 21, "300 Hua Street", "reader11@library.com", 0, 3, "Reader User11", "1111111121", 2 },
                    { 22, "300 Hua Street", "reader12@library.com", 1, 3, "Reader User12", "1111111122", 2 },
                    { 23, "300 Hua Street", "reader13@library.com", 2, 3, "Reader User13", "1111111123", 2 },
                    { 24, "300 Hua Street", "reader14@library.com", 0, 3, "Reader User14", "11111111124", 2 },
                    { 25, "300 Hua Street", "reader15@library.com", 1, 3, "Reader User15", "1111111125", 2 },
                    { 26, "400 Mitchell Road", "reader16@library.com", 0, 4, "Reader User16", "1111111126", 2 },
                    { 27, "400 Mitchell Road", "reader17@library.com", 1, 4, "Reader User17", "1111111127", 2 },
                    { 28, "400 Mitchell Road", "reader18@library.com", 2, 4, "Reader User18", "1111111128", 2 },
                    { 29, "400 Mitchell Road", "reader19@library.com", 0, 4, "Reader User19", "11111111129", 2 },
                    { 30, "400 Mitchell Road", "reader20@library.com", 1, 4, "Reader User20", "1111111130", 2 },
                    { 31, "500 Solomon Boulevard", "reader21@library.com", 0, 5, "Reader User21", "1111111131", 2 },
                    { 32, "500 Solomon Boulevard", "reader22@library.com", 1, 5, "Reader User22", "1111111132", 2 },
                    { 33, "500 Solomon Boulevard", "reader23@library.com", 2, 5, "Reader User23", "1111111133", 2 },
                    { 34, "500 Solomon Boulevard", "reader24@library.com", 0, 5, "Reader User24", "11111111134", 2 },
                    { 35, "500 Solomon Boulevard", "reader25@library.com", 1, 5, "Reader User25", "1111111135", 2 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "BookID", "DateBorrowed", "DueDate", "LoanStatus", "LocationID", "UserID" },
                values: new object[,]
                {
                    { 4, 11, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 3 },
                    { 5, 15, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 3 },
                    { 6, 12, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 7, 16, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3 },
                    { 8, 19, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 3 },
                    { 9, 9, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 12 },
                    { 10, 25, new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 12 },
                    { 11, 23, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 13 },
                    { 12, 28, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 13 },
                    { 13, 27, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 14 },
                    { 14, 33, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 14 },
                    { 15, 37, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 15 },
                    { 16, 47, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 15 },
                    { 17, 35, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 16 },
                    { 18, 45, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 16 },
                    { 19, 39, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 17 },
                    { 20, 57, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 17 },
                    { 21, 51, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 18 },
                    { 22, 55, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 18 },
                    { 23, 43, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, 19 },
                    { 24, 61, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 19 },
                    { 25, 59, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 20 },
                    { 26, 53, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 20 },
                    { 27, 65, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 21 },
                    { 28, 63, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 21 },
                    { 29, 67, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 22 },
                    { 30, 20, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 22 },
                    { 31, 28, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 23 },
                    { 32, 19, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 23 },
                    { 33, 49, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, 24 },
                    { 34, 27, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 24 },
                    { 35, 41, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 25 },
                    { 36, 33, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "LoanID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "admin@library.com", "Admin User" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "Email", "Gender" },
                values: new object[] { "staff@library.com", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "Address", "Email", "Gender", "LocationID", "Name", "PhoneNumber" },
                values: new object[] { "300 Hua Avenue", "reader@library.com", 1, 3, "Reader User", "1234567892" });
        }
    }
}
