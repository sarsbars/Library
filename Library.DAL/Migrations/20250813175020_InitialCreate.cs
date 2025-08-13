using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    LocationInLibrary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateBorrowed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "Address", "LocationName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "100 Boye-Ogundiya Way", 0, "1234567890" },
                    { 2, "200 Hall Street", 1, "1234567891" },
                    { 3, "300 Hua Avenue", 2, "1234567892" },
                    { 4, "400 Mitchell Road", 3, "1234567893" },
                    { 5, "500 Solomon Boulevard", 4, "1234567894" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "Condition", "Genre", "ISBN", "IsAvailable", "LocationID", "LocationInLibrary", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, "John Steinbeck", 2, 0, "9780140186390", true, 4, 101, new DateTime(1952, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "East of Eden" },
                    { 2, "Susanna Clarke", 1, 5, "9781526630810", false, 3, 102, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piranesi" },
                    { 3, "Martha Wells", 0, 2, "9780765394866", false, 3, 103, new DateTime(2017, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "All Systems Red" },
                    { 4, "Mark Z. Danielewski", 2, 0, "9780375508325", true, 5, 104, new DateTime(2000, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "House of Leaves" },
                    { 5, "Brandon Sanderson", 1, 5, "9780765376671", true, 2, 105, new DateTime(2017, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oathbringer" },
                    { 6, "Eiichiro Oda", 2, 13, "9781423103349", false, 1, 106, new DateTime(1997, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Piece, Vol. 1: Romance Dawn" },
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
                    { 67, "Hiromu Arakawa", 0, 13, "9781591161783", false, 2, 167, new DateTime(2005, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fullmetal Alchemist, Vol. 1" },
                    { 68, "J.D. Salinger", 2, 0, "9780140186857", true, 1, 168, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Catcher in the Rye" },
                    { 69, "Herman Melville", 2, 0, "9780142437179", true, 2, 169, new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moby-Dick" },
                    { 70, "Fyodor Dostoevsky", 1, 0, "9780140449112", false, 3, 170, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crime and Punishment" },
                    { 71, "Charles Dickens", 2, 0, "9780141439471", true, 4, 171, new DateTime(1861, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great Expectations" },
                    { 72, "Jane Austen", 0, 0, "9780141439600", true, 5, 172, new DateTime(1818, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Persuasion" },
                    { 73, "Fyodor Dostoevsky", 2, 0, "9780140449334", false, 1, 173, new DateTime(1880, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Brothers Karamazov" },
                    { 74, "Charles Dickens", 1, 0, "9780141439662", true, 2, 174, new DateTime(1859, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Tale of Two Cities" },
                    { 75, "F. Scott Fitzgerald", 2, 0, "9780140187076", false, 3, 175, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby" },
                    { 76, "Emily Brontë", 3, 0, "9780141441146", true, 4, 176, new DateTime(1847, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wuthering Heights" },
                    { 77, "William Golding", 2, 0, "9780142437209", true, 5, 177, new DateTime(1954, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Flies" },
                    { 78, "Leo Tolstoy", 1, 0, "9780140449242", false, 1, 178, new DateTime(1878, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna Karenina" },
                    { 79, "George Orwell", 0, 0, "9780141182636", true, 2, 179, new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Animal Farm" },
                    { 80, "Jane Austen", 2, 0, "9780141439747", true, 3, 180, new DateTime(1811, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sense and Sensibility" },
                    { 81, "Leo Tolstoy", 1, 0, "9780140449082", false, 4, 181, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "War and Peace" },
                    { 82, "Aldous Huxley", 2, 0, "9780141181233", true, 5, 182, new DateTime(1932, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brave New World" },
                    { 83, "Jane Austen", 0, 0, "9780141439556", true, 1, 183, new DateTime(1815, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma" },
                    { 84, "Alexandre Dumas", 2, 0, "9780140449174", false, 2, 184, new DateTime(1844, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Count of Monte Cristo" },
                    { 85, "Jane Austen", 1, 0, "9780141439594", true, 3, 185, new DateTime(1814, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mansfield Park" },
                    { 86, "Victor Hugo", 3, 0, "9780140449136", true, 4, 186, new DateTime(1862, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les Misérables" },
                    { 87, "Zora Neale Hurston", 2, 0, "9780140187656", false, 5, 187, new DateTime(1937, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Their Eyes Were Watching God" },
                    { 88, "George Eliot", 1, 0, "9780140449303", true, 1, 188, new DateTime(1872, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Middlemarch" },
                    { 89, "Nathaniel Hawthorne", 2, 0, "9780142437346", true, 2, 189, new DateTime(1850, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Scarlet Letter" },
                    { 90, "Miguel de Cervantes", 0, 0, "9780140449150", false, 3, 190, new DateTime(1605, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don Quixote" },
                    { 91, "Jane Austen", 2, 0, "9780141439624", true, 4, 191, new DateTime(1818, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northanger Abbey" },
                    { 92, "Gustave Flaubert", 1, 0, "9780140449129", false, 5, 192, new DateTime(1857, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madame Bovary" },
                    { 93, "Mark Twain", 2, 0, "9780142437148", true, 1, 193, new DateTime(1884, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Adventures of Huckleberry Finn" },
                    { 94, "Victor Hugo", 3, 0, "9780140449297", true, 2, 194, new DateTime(1831, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hunchback of Notre-Dame" },
                    { 95, "Ken Kesey", 1, 0, "9780141185064", false, 3, 195, new DateTime(1962, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Flew Over the Cuckoo's Nest" },
                    { 96, "Henry James", 2, 0, "9780140449266", true, 4, 196, new DateTime(1881, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Portrait of a Lady" },
                    { 97, "Charles Dickens", 0, 0, "9780141439648", true, 5, 197, new DateTime(1838, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver Twist" },
                    { 98, "Alexandre Dumas", 2, 0, "9780140449099", false, 1, 198, new DateTime(1844, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Three Musketeers" },
                    { 99, "Ralph Ellison", 1, 0, "9780140187649", true, 2, 199, new DateTime(1952, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invisible Man" },
                    { 100, "Jonathan Swift", 2, 0, "9780140449273", true, 3, 200, new DateTime(1726, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gulliver's Travels" },
                    { 101, "Charles Dickens", 3, 0, "9780141439679", true, 4, 201, new DateTime(1850, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Copperfield" },
                    { 102, "Stendhal", 1, 0, "9780140449143", false, 5, 202, new DateTime(1830, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Red and the Black" },
                    { 103, "E.M. Forster", 2, 0, "9780140187663", true, 1, 203, new DateTime(1908, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Room with a View" },
                    { 104, "William Makepeace Thackeray", 0, 0, "9780140449167", true, 2, 204, new DateTime(1848, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanity Fair" },
                    { 105, "Charles Dickens", 2, 0, "9780141439686", false, 3, 205, new DateTime(1853, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bleak House" },
                    { 106, "Edith Wharton", 1, 0, "9780140449181", true, 4, 206, new DateTime(1905, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The House of Mirth" },
                    { 107, "Sylvia Plath", 2, 0, "9780141185064", true, 5, 207, new DateTime(1963, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Bell Jar" },
                    { 108, "Thomas Hardy", 3, 0, "9780140449198", true, 1, 208, new DateTime(1891, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tess of the d'Urbervilles" },
                    { 109, "Charles Dickens", 1, 0, "9780141439693", false, 2, 209, new DateTime(1854, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hard Times" },
                    { 110, "Thomas Hardy", 2, 0, "9780140449204", true, 3, 210, new DateTime(1874, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Far from the Madding Crowd" },
                    { 111, "Kurt Vonnegut", 0, 0, "9780141185071", true, 4, 211, new DateTime(1969, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slaughterhouse-Five" },
                    { 112, "Thomas Hardy", 2, 0, "9780140449211", false, 4, 212, new DateTime(1895, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jude the Obscure" },
                    { 113, "E.M. Forster", 1, 0, "9780140187687", true, 1, 213, new DateTime(1910, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Howards End" },
                    { 114, "Thomas Hardy", 2, 0, "9780140449228", true, 2, 214, new DateTime(1878, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Return of the Native" },
                    { 115, "Charles Dickens", 3, 0, "9780141439709", true, 3, 215, new DateTime(1857, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Little Dorrit" },
                    { 116, "Thomas Hardy", 1, 0, "9780140449235", false, 4, 216, new DateTime(1886, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Mayor of Casterbridge" },
                    { 117, "E.M. Forster", 2, 0, "9780140187694", true, 5, 217, new DateTime(1924, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Passage to India" },
                    { 118, "Edith Wharton", 0, 0, "9780140449259", true, 1, 218, new DateTime(1920, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Age of Innocence" },
                    { 119, "Charles Dickens", 2, 0, "9780141439716", false, 2, 219, new DateTime(1839, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicholas Nickleby" },
                    { 120, "Wilkie Collins", 1, 0, "9780140449280", true, 3, 220, new DateTime(1860, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Woman in White" },
                    { 121, "Ernest Hemingway", 2, 0, "9780140187700", true, 4, 221, new DateTime(1926, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sun Also Rises" },
                    { 122, "Bram Stoker", 3, 0, "9780140449310", true, 5, 222, new DateTime(1897, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dracula" },
                    { 123, "Charles Dickens", 1, 0, "9780141439723", false, 1, 223, new DateTime(1837, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Pickwick Papers" },
                    { 124, "Mary Shelley", 2, 0, "9780140449327", true, 2, 224, new DateTime(1818, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frankenstein" },
                    { 125, "Ernest Hemingway", 0, 0, "9780140187717", true, 3, 225, new DateTime(1929, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Farewell to Arms" },
                    { 126, "Ernest Hemingway", 2, 0, "9780140449334", false, 4, 226, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Old Man and the Sea" },
                    { 127, "Charles Dickens", 1, 0, "9780141439730", true, 5, 227, new DateTime(1844, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Chuzzlewit" },
                    { 128, "Wilkie Collins", 2, 0, "9780140449341", true, 1, 228, new DateTime(1868, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Moonstone" },
                    { 129, "Ernest Hemingway", 3, 0, "9780140187724", true, 2, 229, new DateTime(1940, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "For Whom the Bell Tolls" },
                    { 130, "Anne Brontë", 1, 0, "9780140449358", false, 3, 230, new DateTime(1848, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Tenant of Wildfell Hall" },
                    { 131, "Isaac Asimov", 2, 2, "9780451462008", false, 1, 231, new DateTime(1951, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foundation" },
                    { 132, "Isaac Asimov", 1, 2, "9780553382563", false, 2, 232, new DateTime(1950, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "I, Robot" },
                    { 133, "Ursula K. Le Guin", 0, 2, "9780345347954", true, 3, 233, new DateTime(1969, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Left Hand of Darkness" },
                    { 134, "Philip K. Dick", 2, 2, "9780441013593", true, 4, 234, new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do Androids Dream of Electric Sheep?" },
                    { 135, "Walter M. Miller Jr.", 1, 2, "9780553573398", false, 5, 235, new DateTime(1959, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Canticle for Leibowitz" },
                    { 136, "Orson Scott Card", 2, 2, "9780345391810", true, 1, 236, new DateTime(1986, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Speaker for the Dead" },
                    { 137, "Dan Simmons", 0, 2, "9780553560244", true, 2, 237, new DateTime(1989, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hyperion" },
                    { 138, "Joe Haldeman", 2, 2, "9780553572940", false, 3, 238, new DateTime(1974, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Forever War" },
                    { 139, "Neal Stephenson", 1, 2, "9780345418975", true, 4, 239, new DateTime(1992, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snow Crash" },
                    { 140, "Ray Bradbury", 2, 2, "9780553382570", true, 5, 240, new DateTime(1950, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Martian Chronicles" },
                    { 141, "Daniel Keyes", 3, 2, "9780441016808", true, 1, 241, new DateTime(1966, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flowers for Algernon" },
                    { 142, "Ursula K. Le Guin", 1, 2, "9780345342966", false, 2, 242, new DateTime(1974, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dispossessed" },
                    { 143, "Larry Niven", 2, 2, "9780553563702", true, 3, 243, new DateTime(1970, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ringworld" },
                    { 144, "H.G. Wells", 0, 2, "9780345335289", true, 4, 244, new DateTime(1895, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Time Machine" },
                    { 145, "H.G. Wells", 2, 2, "9780345339737", false, 5, 245, new DateTime(1898, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The War of the Worlds" },
                    { 146, "Ray Bradbury", 1, 2, "9780553573428", true, 1, 246, new DateTime(1953, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fahrenheit 451" },
                    { 147, "Robert A. Heinlein", 2, 2, "9780345404473", true, 2, 247, new DateTime(1961, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stranger in a Strange Land" },
                    { 148, "Robert A. Heinlein", 0, 2, "9780441569595", true, 3, 248, new DateTime(1959, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Starship Troopers" },
                    { 149, "Arkady and Boris Strugatsky", 2, 2, "9780345345059", false, 4, 249, new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roadside Picnic" },
                    { 150, "Neal Stephenson", 1, 2, "9780553572995", true, 5, 250, new DateTime(1995, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Diamond Age" },
                    { 151, "Peter Watts", 2, 2, "9780441017720", true, 1, 251, new DateTime(2006, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blindsight" },
                    { 152, "John Scalzi", 3, 2, "9780765315243", true, 2, 252, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Old Man's War" },
                    { 153, "Iain M. Banks", 1, 2, "9780765316899", false, 3, 253, new DateTime(2004, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Algebraist" },
                    { 154, "Alfred Bester", 2, 2, "9780553573411", true, 4, 254, new DateTime(1956, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Stars My Destination" },
                    { 155, "Robert A. Heinlein", 0, 2, "9780345353146", true, 5, 255, new DateTime(1966, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Moon Is a Harsh Mistress" },
                    { 156, "Frederik Pohl", 2, 2, "9780441013593", false, 1, 256, new DateTime(1976, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Man Plus" },
                    { 157, "Alfred Bester", 1, 2, "9780553572957", true, 2, 257, new DateTime(1953, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Demolished Man" },
                    { 158, "George R. Stewart", 2, 2, "9780345347954", true, 3, 258, new DateTime(1949, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Earth Abides" },
                    { 159, "Joe Haldeman", 0, 2, "9780553572971", false, 4, 259, new DateTime(1997, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Forever Peace" },
                    { 160, "Larry Niven & Jerry Pournelle", 2, 2, "9780441016808", true, 5, 260, new DateTime(1974, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Mote in God's Eye" },
                    { 161, "Iain M. Banks", 1, 2, "9780765316905", true, 1, 261, new DateTime(1987, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consider Phlebas" },
                    { 162, "Iain M. Banks", 2, 2, "9780553572988", false, 2, 262, new DateTime(1988, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Player of Games" },
                    { 163, "Frederik Pohl", 0, 2, "9780345350497", true, 3, 263, new DateTime(1977, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gateway" },
                    { 164, "Iain M. Banks", 2, 2, "9780553573007", true, 4, 264, new DateTime(1990, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Use of Weapons" },
                    { 165, "Arthur C. Clarke", 1, 2, "9780441016808", false, 5, 265, new DateTime(1973, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rendezvous with Rama" },
                    { 166, "Arthur C. Clarke", 2, 2, "9780553573014", true, 1, 266, new DateTime(1968, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2001: A Space Odyssey" },
                    { 167, "Vernor Vinge", 0, 2, "9780345347954", true, 2, 267, new DateTime(1992, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Fire Upon the Deep" },
                    { 168, "Lois McMaster Bujold", 2, 2, "9780553573021", false, 3, 268, new DateTime(1991, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barrayar" },
                    { 169, "Lois McMaster Bujold", 1, 2, "9780345350503", true, 4, 269, new DateTime(1986, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shards of Honor" },
                    { 170, "Lois McMaster Bujold", 2, 2, "9780553573038", true, 5, 270, new DateTime(1994, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mirror Dance" },
                    { 171, "Mary Doria Russell", 3, 2, "9780441016808", true, 1, 271, new DateTime(1996, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sparrow" },
                    { 172, "Paolo Bacigalupi", 1, 2, "9780553573045", false, 2, 272, new DateTime(2009, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Windup Girl" },
                    { 173, "David Brin", 2, 2, "9780345350510", true, 3, 273, new DateTime(1983, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Startide Rising" },
                    { 174, "David Brin", 0, 2, "9780553573052", true, 4, 274, new DateTime(1987, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uplift War" },
                    { 175, "Arthur C. Clarke", 2, 2, "9780441016808", false, 5, 275, new DateTime(1979, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Fountains of Paradise" },
                    { 176, "Arthur C. Clarke", 1, 2, "9780553573069", true, 1, 276, new DateTime(1956, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The City and the Stars" },
                    { 177, "Vernor Vinge", 2, 2, "9780345350527", true, 2, 277, new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Deepness in the Sky" },
                    { 178, "Mary Doria Russell", 0, 2, "9780553573076", true, 3, 278, new DateTime(1998, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Children of God" },
                    { 179, "David Brin", 2, 2, "9780345350534", false, 4, 279, new DateTime(1987, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Uplift War" },
                    { 180, "Lois McMaster Bujold", 1, 2, "9780553573083", true, 5, 280, new DateTime(1998, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Komarr" },
                    { 181, "Tsugumi Ohba", 1, 13, "9781421500577", false, 1, 281, new DateTime(2005, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Death Note, Vol. 1" },
                    { 182, "Tite Kubo", 2, 13, "9781421500584", false, 2, 282, new DateTime(2004, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bleach, Vol. 1" },
                    { 183, "Yoshihiro Togashi", 0, 13, "9781421500591", true, 3, 283, new DateTime(2003, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yu Yu Hakusho, Vol. 1" },
                    { 184, "Yoshihiro Togashi", 2, 13, "9781421500607", true, 4, 284, new DateTime(2005, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunter x Hunter, Vol. 1" },
                    { 185, "ONE", 1, 13, "9781421500614", false, 5, 285, new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Punch Man, Vol. 1" },
                    { 186, "Kohei Horikoshi", 2, 13, "9781421500621", true, 1, 286, new DateTime(2015, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Hero Academia, Vol. 1" },
                    { 187, "Koyoharu Gotouge", 0, 13, "9781421500638", true, 2, 287, new DateTime(2018, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demon Slayer: Kimetsu no Yaiba, Vol. 1" },
                    { 188, "Sui Ishida", 1, 13, "9781421500645", false, 3, 288, new DateTime(2015, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokyo Ghoul, Vol. 1" },
                    { 189, "Akira Toriyama", 2, 13, "9781421500652", true, 4, 289, new DateTime(2003, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon Ball, Vol. 1" },
                    { 190, "Akira Toriyama", 1, 13, "9781421500669", true, 5, 290, new DateTime(2003, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon Ball Z, Vol. 1" },
                    { 191, "Naoko Takeuchi", 2, 13, "9781421500676", false, 1, 291, new DateTime(2011, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sailor Moon, Vol. 1" },
                    { 192, "Kentaro Miura", 0, 13, "9781421500683", true, 2, 292, new DateTime(2003, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berserk, Vol. 1" },
                    { 193, "Hirohiko Araki", 2, 13, "9781421500690", true, 3, 293, new DateTime(2015, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "JoJo's Bizarre Adventure, Vol. 1" },
                    { 194, "Hiro Mashima", 1, 13, "9781421500706", false, 4, 294, new DateTime(2008, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fairy Tail, Vol. 1" },
                    { 195, "Yuki Tabata", 2, 13, "9781421500713", true, 5, 295, new DateTime(2016, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Clover, Vol. 1" },
                    { 196, "Haruichi Furudate", 0, 13, "9781421500720", true, 1, 296, new DateTime(2016, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haikyu!!, Vol. 1" },
                    { 197, "Gege Akutami", 1, 13, "9781421500737", false, 2, 297, new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jujutsu Kaisen, Vol. 1" },
                    { 198, "Makoto Yukimura", 2, 13, "9781421500744", true, 3, 298, new DateTime(2013, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vinland Saga, Vol. 1" },
                    { 199, "Yoshihiro Togashi", 1, 13, "9781421500751", true, 4, 299, new DateTime(2005, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunter x Hunter, Vol. 2" },
                    { 200, "Wataru Watari", 2, 13, "9781421500768", false, 5, 300, new DateTime(2016, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Teen Romantic Comedy Yahari, Vol. 1" },
                    { 201, "Hajime Isayama", 0, 13, "9781421500775", true, 1, 301, new DateTime(2012, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attack on Titan, Vol. 2" },
                    { 202, "Masashi Kishimoto", 2, 13, "9781421500782", true, 2, 302, new DateTime(2003, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naruto, Vol. 2" },
                    { 203, "Tite Kubo", 1, 13, "9781421500799", false, 3, 303, new DateTime(2004, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bleach, Vol. 2" },
                    { 204, "Eiichiro Oda", 2, 13, "9781421500805", true, 4, 304, new DateTime(2003, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Piece, Vol. 2" },
                    { 205, "Tsugumi Ohba", 0, 13, "9781421500812", true, 5, 305, new DateTime(2005, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Death Note, Vol. 2" },
                    { 206, "Hiromu Arakawa", 1, 13, "9781421500829", false, 1, 306, new DateTime(2005, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fullmetal Alchemist, Vol. 2" },
                    { 207, "Sui Ishida", 2, 13, "9781421500836", true, 2, 307, new DateTime(2015, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokyo Ghoul, Vol. 2" },
                    { 208, "Koyoharu Gotouge", 1, 13, "9781421500843", true, 3, 308, new DateTime(2018, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Demon Slayer: Kimetsu no Yaiba, Vol. 2" },
                    { 209, "Kohei Horikoshi", 2, 13, "9781421500850", false, 4, 309, new DateTime(2015, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Hero Academia, Vol. 2" },
                    { 210, "Naoko Takeuchi", 0, 13, "9781421500867", true, 5, 310, new DateTime(2011, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sailor Moon, Vol. 2" },
                    { 211, "Kentaro Miura", 1, 13, "9781421500874", true, 1, 311, new DateTime(2004, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berserk, Vol. 2" },
                    { 212, "Hirohiko Araki", 2, 13, "9781421500881", false, 2, 312, new DateTime(2015, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "JoJo's Bizarre Adventure, Vol. 2" },
                    { 213, "Hiro Mashima", 1, 13, "9781421500898", true, 3, 313, new DateTime(2008, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fairy Tail, Vol. 2" },
                    { 214, "Yuki Tabata", 2, 13, "9781421500904", true, 4, 314, new DateTime(2016, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Clover, Vol. 2" },
                    { 215, "Haruichi Furudate", 0, 13, "9781421500911", false, 5, 315, new DateTime(2016, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haikyu!!, Vol. 2" },
                    { 216, "Gege Akutami", 1, 13, "9781421500928", true, 1, 316, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jujutsu Kaisen, Vol. 2" },
                    { 217, "Makoto Yukimura", 2, 13, "9781421500935", true, 2, 317, new DateTime(2013, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vinland Saga, Vol. 2" },
                    { 218, "ONE", 1, 13, "9781421500942", false, 3, 318, new DateTime(2015, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Punch Man, Vol. 2" },
                    { 219, "Akira Toriyama", 2, 13, "9781421500959", true, 4, 319, new DateTime(2003, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon Ball, Vol. 2" },
                    { 220, "Akira Toriyama", 0, 13, "9781421500966", true, 5, 320, new DateTime(2003, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon Ball Z, Vol. 2" },
                    { 221, "Yoshihiro Togashi", 1, 13, "9781421500973", false, 1, 321, new DateTime(2003, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yu Yu Hakusho, Vol. 2" },
                    { 222, "Yoshihiro Togashi", 2, 13, "9781421500980", true, 2, 322, new DateTime(2005, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunter x Hunter, Vol. 3" },
                    { 223, "Wataru Watari", 1, 13, "9781421500997", true, 3, 323, new DateTime(2016, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Teen Romantic Comedy Yahari, Vol. 2" },
                    { 224, "Hajime Isayama", 2, 13, "9781421501000", false, 4, 324, new DateTime(2012, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attack on Titan, Vol. 3" },
                    { 225, "Masashi Kishimoto", 0, 13, "9781421501017", true, 5, 325, new DateTime(2004, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naruto, Vol. 3" },
                    { 226, "Tite Kubo", 1, 13, "9781421501024", true, 1, 326, new DateTime(2004, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bleach, Vol. 3" },
                    { 227, "Eiichiro Oda", 2, 13, "9781421501031", false, 2, 327, new DateTime(2003, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Piece, Vol. 3" },
                    { 228, "Tsugumi Ohba", 1, 13, "9781421501048", true, 3, 328, new DateTime(2006, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Death Note, Vol. 3" },
                    { 229, "Hiromu Arakawa", 2, 13, "9781421501055", true, 4, 329, new DateTime(2005, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fullmetal Alchemist, Vol. 3" },
                    { 230, "Sui Ishida", 0, 13, "9781421501062", true, 5, 330, new DateTime(2015, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokyo Ghoul, Vol. 3" },
                    { 231, "Jared Diamond", 1, 1, "9780060935467", true, 1, 331, new DateTime(1997, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guns, Germs, and Steel" },
                    { 232, "Steven D. Levitt & Stephen J. Dubner", 2, 1, "9780143038252", true, 2, 332, new DateTime(2005, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Freakonomics" },
                    { 233, "Bill Bryson", 0, 1, "9780679734772", true, 3, 333, new DateTime(2003, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Short History of Nearly Everything" },
                    { 234, "Richard Dawkins", 1, 1, "9780385484510", false, 4, 334, new DateTime(2006, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The God Delusion" },
                    { 235, "Daniel Kahneman", 2, 1, "9780142000281", true, 5, 335, new DateTime(2011, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thinking, Fast and Slow" },
                    { 236, "Truman Capote", 1, 1, "9780679745587", true, 1, 336, new DateTime(1965, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Cold Blood" },
                    { 237, "Malcolm Gladwell", 2, 1, "9780143036555", false, 2, 337, new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Tipping Point" },
                    { 238, "Malcolm Gladwell", 0, 1, "9780143039945", true, 3, 338, new DateTime(2008, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outliers" },
                    { 239, "Susan Cain", 1, 1, "9780142001615", false, 4, 339, new DateTime(2012, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quiet: The Power of Introverts" },
                    { 240, "Charles Duhigg", 2, 1, "9780143114963", true, 5, 340, new DateTime(2012, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Power of Habit" },
                    { 241, "Richard Dawkins", 1, 1, "9780143111580", true, 1, 341, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 242, "Michael Pollan", 0, 1, "9780143113201", false, 2, 342, new DateTime(2006, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omnivore's Dilemma" },
                    { 243, "Elizabeth Kolbert", 2, 1, "9780143114895", true, 3, 343, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sixth Extinction" },
                    { 244, "Charles Duhigg", 1, 1, "9780143114963", true, 4, 344, new DateTime(2012, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Power of Habit" },
                    { 245, "Richard Dawkins", 2, 1, "9780143111580", false, 5, 345, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 246, "Michael Pollan", 0, 1, "9780143113201", true, 1, 346, new DateTime(2006, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omnivore's Dilemma" },
                    { 247, "Elizabeth Kolbert", 1, 1, "9780143114895", true, 2, 347, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sixth Extinction" },
                    { 248, "Richard Dawkins", 2, 1, "9780143111580", false, 3, 348, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 249, "Michael Pollan", 0, 1, "9780143113201", true, 4, 349, new DateTime(2006, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omnivore's Dilemma" },
                    { 250, "Elizabeth Kolbert", 1, 1, "9780143114895", true, 5, 350, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sixth Extinction" },
                    { 251, "Susan Cain", 2, 1, "9780142001615", true, 1, 351, new DateTime(2012, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quiet: The Power of Introverts" },
                    { 252, "Charles Duhigg", 1, 1, "9780143114963", false, 2, 352, new DateTime(2012, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Power of Habit" },
                    { 253, "Richard Dawkins", 2, 1, "9780143111580", true, 3, 353, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 254, "Michael Pollan", 0, 1, "9780143113201", true, 4, 354, new DateTime(2006, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omnivore's Dilemma" },
                    { 255, "Elizabeth Kolbert", 1, 1, "9780143114895", true, 5, 355, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sixth Extinction" },
                    { 256, "Richard Dawkins", 2, 1, "9780143111580", false, 1, 356, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 257, "Michael Pollan", 0, 1, "9780143113201", true, 2, 357, new DateTime(2006, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omnivore's Dilemma" },
                    { 258, "Elizabeth Kolbert", 1, 1, "9780143114895", true, 3, 358, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sixth Extinction" },
                    { 259, "Richard Dawkins", 2, 1, "9780143111580", false, 4, 359, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 260, "Michael Pollan", 0, 1, "9780143113201", true, 5, 360, new DateTime(2006, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omnivore's Dilemma" },
                    { 261, "Elizabeth Kolbert", 1, 1, "9780143114895", true, 1, 361, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sixth Extinction" },
                    { 262, "Richard Dawkins", 2, 1, "9780143111580", false, 2, 362, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 263, "Michael Pollan", 0, 1, "9780143113201", true, 3, 363, new DateTime(2006, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omnivore's Dilemma" },
                    { 264, "Elizabeth Kolbert", 1, 1, "9780143114895", true, 4, 364, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sixth Extinction" },
                    { 265, "Richard Dawkins", 2, 1, "9780143111580", false, 5, 365, new DateTime(1976, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Selfish Gene" },
                    { 266, "Michael Pollan", 0, 1, "9780143113201", true, 1, 366, new DateTime(2006, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Omnivore's Dilemma" },
                    { 267, "Elizabeth Kolbert", 1, 1, "9780143114895", true, 2, 367, new DateTime(2014, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sixth Extinction" },
                    { 268, "Alex Michaelides", 1, 3, "9780062457806", true, 3, 368, new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Silent Patient" },
                    { 269, "Thomas Harris", 2, 3, "9780316769488", false, 4, 369, new DateTime(1988, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Silence of the Lambs" },
                    { 270, "Gillian Flynn", 0, 3, "9780312367541", true, 5, 370, new DateTime(2012, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gone Girl" },
                    { 271, "Paula Hawkins", 2, 3, "9780316769488", true, 1, 371, new DateTime(2015, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Girl on the Train" },
                    { 272, "Umberto Eco", 1, 3, "9780140449266", false, 2, 372, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Name of the Rose" },
                    { 273, "Liane Moriarty", 2, 3, "9780062457806", true, 3, 373, new DateTime(2014, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Big Little Lies" },
                    { 274, "Dan Brown", 0, 3, "9780316769488", true, 4, 374, new DateTime(2003, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Da Vinci Code" },
                    { 275, "Gillian Flynn", 1, 3, "9780312367541", false, 5, 375, new DateTime(2006, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharp Objects" },
                    { 276, "A.J. Finn", 2, 3, "9780062457806", true, 1, 376, new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Woman in the Window" },
                    { 277, "Stieg Larsson", 1, 3, "9780316769488", true, 2, 377, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Girl Who Played with Fire" },
                    { 278, "Agatha Christie", 2, 3, "9780140449266", false, 3, 378, new DateTime(1926, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Murder of Roger Ackroyd" },
                    { 279, "Shari Lapena", 0, 3, "9780062457806", true, 4, 379, new DateTime(2016, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Couple Next Door" },
                    { 280, "Stieg Larsson", 2, 3, "9780316769488", true, 5, 380, new DateTime(2007, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Girl Who Kicked the Hornet's Nest" },
                    { 281, "Stephen King", 1, 3, "9780062457806", false, 1, 381, new DateTime(2018, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Outsider" },
                    { 282, "Alexander McCall Smith", 2, 3, "9780316769488", true, 2, 382, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The No. 1 Ladies' Detective Agency" },
                    { 283, "Dashiell Hammett", 0, 3, "9780140449266", true, 3, 383, new DateTime(1930, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Maltese Falcon" },
                    { 284, "Ruth Ware", 1, 3, "9780062457806", false, 4, 384, new DateTime(2016, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Woman in Cabin 10" },
                    { 285, "Raymond Chandler", 2, 3, "9780316769488", true, 5, 385, new DateTime(1939, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Big Sleep" },
                    { 286, "Lucy Foley", 1, 3, "9780062457806", true, 1, 386, new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hunting Party" },
                    { 287, "Donna Tartt", 0, 3, "9780316769488", false, 2, 387, new DateTime(1992, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Secret History" },
                    { 288, "Wilkie Collins", 2, 3, "9780140449266", true, 3, 388, new DateTime(1868, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Moonstone" },
                    { 289, "Lucy Foley", 1, 3, "9780062457806", true, 4, 389, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Guest List" },
                    { 290, "Michael Connelly", 2, 3, "9780316769488", false, 5, 390, new DateTime(2010, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Reversal" },
                    { 291, "Diana Gabaldon", 1, 4, "9780451529305", true, 1, 391, new DateTime(1991, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Outlander" },
                    { 292, "Nicholas Sparks", 2, 4, "9780143111580", false, 2, 392, new DateTime(1996, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Notebook" },
                    { 293, "Jojo Moyes", 0, 4, "9780142001615", true, 3, 393, new DateTime(2012, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Me Before You" },
                    { 294, "Jane Austen", 1, 4, "9780143114895", true, 4, 394, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice" },
                    { 295, "Audrey Niffenegger", 2, 4, "9780062457806", false, 5, 395, new DateTime(2003, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Time Traveler's Wife" },
                    { 296, "Julia Quinn", 1, 4, "9780316769488", true, 1, 396, new DateTime(2000, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bridgerton: The Duke and I" },
                    { 297, "Charlotte Brontë", 0, 4, "9780140449266", true, 2, 397, new DateTime(1847, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Eyre" },
                    { 298, "John Green", 2, 4, "9780062457806", false, 3, 398, new DateTime(2012, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Fault in Our Stars" },
                    { 299, "Graeme Sim sion", 1, 4, "9780316769488", true, 4, 399, new DateTime(2013, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Rosie Project" },
                    { 300, "Jane Austen", 2, 4, "9780140449266", true, 5, 400, new DateTime(1811, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sense and Sensibility" },
                    { 301, "Jenny Han", 0, 4, "9780062457806", false, 1, 401, new DateTime(2014, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "To All the Boys I've Loved Before" },
                    { 302, "Sally Thorne", 1, 4, "9780316769488", true, 2, 402, new DateTime(2016, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hating Game" },
                    { 303, "Jane Austen", 2, 4, "9780140449266", true, 3, 403, new DateTime(1815, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma" },
                    { 304, "Helen Hoang", 1, 4, "9780062457806", false, 4, 404, new DateTime(2018, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Kiss Quotient" },
                    { 305, "Casey McQuiston", 0, 4, "9780316769488", true, 5, 405, new DateTime(2019, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red, White & Royal Blue" },
                    { 306, "Jane Austen", 2, 4, "9780140449266", true, 1, 406, new DateTime(1814, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mansfield Park" },
                    { 307, "Emily Henry", 1, 4, "9780062457806", false, 2, 407, new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beach Read" },
                    { 308, "Taylor Jenkins Reid", 2, 4, "9780316769488", true, 3, 408, new DateTime(2017, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Seven Husbands of Evelyn Hugo" },
                    { 309, "Jane Austen", 0, 4, "9780140449266", true, 4, 409, new DateTime(1817, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northanger Abbey" },
                    { 310, "Emily Henry", 1, 4, "9780062457806", true, 5, 410, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "People We Meet on Vacation" },
                    { 311, "Daphne du Maurier", 2, 4, "9780140449266", false, 1, 411, new DateTime(1938, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rebecca" },
                    { 312, "Robert James Waller", 1, 4, "9780316769488", true, 2, 412, new DateTime(1992, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Bridges of Madison County" },
                    { 313, "Michelle Obama", 0, 4, "9780062457806", true, 3, 413, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Light We Carry" },
                    { 314, "Boris Pasternak", 2, 4, "9780140449266", false, 4, 414, new DateTime(1957, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor Zhivago" },
                    { 315, "Nicholas Sparks", 1, 4, "9780316769488", true, 5, 415, new DateTime(1996, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Notebook" },
                    { 316, "William Goldman", 2, 4, "9780062457806", true, 1, 416, new DateTime(1973, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Princess Bride" },
                    { 317, "Margaret Mitchell", 0, 4, "9780316769488", false, 2, 417, new DateTime(1936, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gone with the Wind" },
                    { 318, "Colleen McCullough", 1, 4, "9780140449266", true, 3, 418, new DateTime(1977, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Thorn Birds" },
                    { 319, "Nicholas Sparks", 2, 4, "9780062457806", true, 4, 419, new DateTime(1996, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Notebook" },
                    { 320, "Audrey Niffenegger", 1, 4, "9780316769488", false, 5, 420, new DateTime(2003, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Time Traveler's Wife" },
                    { 321, "J.R.R. Tolkien", 1, 5, "9780544003415", true, 1, 421, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit" },
                    { 322, "J.R.R. Tolkien", 2, 5, "9780547928227", false, 2, 422, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings" },
                    { 323, "J.K. Rowling", 0, 5, "9780439064874", true, 3, 423, new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Chamber of Secrets" },
                    { 324, "J.K. Rowling", 1, 5, "9780439136365", true, 4, 424, new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" },
                    { 325, "J.K. Rowling", 2, 5, "9780439139601", false, 5, 425, new DateTime(2000, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Goblet of Fire" },
                    { 326, "J.K. Rowling", 0, 5, "9780439358071", true, 1, 426, new DateTime(2003, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Order of the Phoenix" },
                    { 327, "J.K. Rowling", 1, 5, "9780439785969", true, 2, 427, new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Half-Blood Prince" },
                    { 328, "J.K. Rowling", 2, 5, "9780545139700", false, 3, 428, new DateTime(2007, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Deathly Hallows" },
                    { 329, "Brandon Sanderson", 1, 5, "9780765376671", true, 4, 429, new DateTime(2010, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Stormlight Archive: The Way of Kings" },
                    { 330, "Brandon Sanderson", 2, 5, "9780765376671", true, 5, 430, new DateTime(2014, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Stormlight Archive: Words of Radiance" },
                    { 331, "Brandon Sanderson", 0, 5, "9780765376671", false, 1, 431, new DateTime(2017, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Stormlight Archive: Oathbringer" },
                    { 332, "Brandon Sanderson", 1, 5, "9780765376671", true, 2, 432, new DateTime(2020, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Stormlight Archive: Rhythm of War" },
                    { 333, "C.S. Lewis", 2, 5, "9780061122415", true, 3, 433, new DateTime(1950, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Chronicles of Narnia: The Lion, the Witch and the Wardrobe" },
                    { 334, "C.S. Lewis", 1, 5, "9780061122422", false, 4, 434, new DateTime(1951, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Chronicles of Narnia: Prince Caspian" },
                    { 335, "C.S. Lewis", 0, 5, "9780061122439", true, 5, 435, new DateTime(1952, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Chronicles of Narnia: The Voyage of the Dawn Treader" },
                    { 336, "C.S. Lewis", 2, 5, "9780061122446", true, 1, 436, new DateTime(1953, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Chronicles of Narnia: The Silver Chair" },
                    { 337, "C.S. Lewis", 1, 5, "9780061122453", false, 2, 437, new DateTime(1954, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Chronicles of Narnia: The Horse and His Boy" },
                    { 338, "C.S. Lewis", 2, 5, "9780061122460", true, 3, 438, new DateTime(1955, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Chronicles of Narnia: The Magician's Nephew" },
                    { 339, "C.S. Lewis", 0, 5, "9780061122477", true, 4, 439, new DateTime(1956, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Chronicles of Narnia: The Last Battle" },
                    { 340, "Brandon Sanderson", 1, 5, "9780765376671", false, 5, 440, new DateTime(2006, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistborn: The Final Empire" },
                    { 341, "Brandon Sanderson", 2, 5, "9780765316882", true, 1, 441, new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistborn: The Well of Ascension" },
                    { 342, "Brandon Sanderson", 0, 5, "9780765316899", true, 2, 442, new DateTime(2008, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistborn: The Hero of Ages" },
                    { 343, "Brandon Sanderson", 1, 5, "9780765316905", false, 3, 443, new DateTime(2011, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistborn: The Alloy of Law" },
                    { 344, "Brandon Sanderson", 2, 5, "9780765316912", true, 4, 444, new DateTime(2015, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistborn: Shadows of Self" },
                    { 345, "Brandon Sanderson", 0, 5, "9780765316929", true, 5, 445, new DateTime(2016, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistborn: The Bands of Mourning" },
                    { 346, "Rick Riordan", 1, 5, "9780061122415", true, 1, 446, new DateTime(2005, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Percy Jackson & the Olympians: The Lightning Thief" },
                    { 347, "Rick Riordan", 2, 5, "9780061122422", false, 2, 447, new DateTime(2006, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Percy Jackson & the Olympians: The Sea of Monsters" },
                    { 348, "Rick Riordan", 0, 5, "9780061122439", true, 3, 448, new DateTime(2007, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Percy Jackson & the Olympians: The Titan's Curse" },
                    { 349, "Rick Riordan", 1, 5, "9780061122446", true, 4, 449, new DateTime(2008, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Percy Jackson & the Olympians: The Battle of the Labyrinth" },
                    { 350, "Rick Riordan", 2, 5, "9780061122453", false, 5, 450, new DateTime(2009, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Percy Jackson & the Olympians: The Last Olympian" },
                    { 351, "Erin Morgenstern", 1, 5, "9780062457806", true, 1, 451, new DateTime(2011, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Night Circus" },
                    { 352, "Neil Gaiman", 2, 5, "9780316769488", true, 2, 452, new DateTime(2001, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Gods" },
                    { 353, "Patrick Rothfuss", 0, 5, "9780140449266", false, 3, 453, new DateTime(2007, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Name of the Wind" },
                    { 354, "Neil Gaiman", 1, 5, "9780062457806", true, 4, 454, new DateTime(2013, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ocean at the End of the Lane" },
                    { 355, "Neil Gaiman & Terry Pratchett", 2, 5, "9780316769488", true, 5, 455, new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Omens" },
                    { 356, "Patrick Rothfuss", 1, 5, "9780140449266", false, 1, 456, new DateTime(2011, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wise Man's Fear" },
                    { 357, "Neil Gaiman", 0, 5, "9780062457806", true, 2, 457, new DateTime(1996, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neverwhere" },
                    { 358, "Lev Grossman", 2, 5, "9780316769488", true, 3, 458, new DateTime(2009, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Magicians" },
                    { 359, "Scott Lynch", 1, 5, "9780140449266", false, 4, 459, new DateTime(2006, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lies of Locke Lamora" },
                    { 360, "Neil Gaiman", 2, 5, "9780062457806", true, 5, 460, new DateTime(1999, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stardust" },
                    { 361, "Lev Grossman", 1, 5, "9780316769488", true, 1, 461, new DateTime(2011, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Magician King" },
                    { 362, "Scott Lynch", 0, 5, "9780140449266", false, 2, 462, new DateTime(2013, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Republic of Thieves" },
                    { 363, "Neil Gaiman", 2, 5, "9780062457806", true, 3, 463, new DateTime(2002, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coraline" },
                    { 364, "Lev Grossman", 1, 5, "9780316769488", true, 4, 464, new DateTime(2014, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Magician's Land" },
                    { 365, "Scott Lynch", 2, 5, "9780140449266", false, 5, 465, new DateTime(2007, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Red Seas Under Red Skies" },
                    { 366, "Neil Gaiman", 1, 5, "9780062457806", true, 1, 466, new DateTime(2005, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anansi Boys" },
                    { 367, "Neil Gaiman", 0, 5, "9780316769488", true, 2, 467, new DateTime(2013, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ocean at the End of the Lane" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "Email", "Gender", "LocationID", "Name", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "100 Boye-Ogundiya Way", "admin1@library.com", 3, 1, "Admin User1", "1234567890", 0 },
                    { 2, "200 Hall Street", "staff2@library.com", 1, 2, "Staff User", "1234567891", 1 },
                    { 3, "100 Boye-Ogundiya Way", "reader1@library.com", 0, 1, "Reader User1", "1111111111", 2 },
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
                    { 35, "500 Solomon Boulevard", "reader25@library.com", 1, 5, "Reader User25", "1111111135", 2 },
                    { 36, "100 Boye-Ogundiya Way", "reader26@library.com", 0, 1, "Reader User26", "1111111136", 2 },
                    { 37, "100 Boye-Ogundiya Way", "reader27@library.com", 1, 1, "Reader User27", "1111111137", 2 },
                    { 38, "100 Boye-Ogundiya Way", "reader28@library.com", 2, 1, "Reader User28", "1111111138", 2 },
                    { 39, "100 Boye-Ogundiya Way", "reader29@library.com", 0, 1, "Reader User29", "1111111139", 2 },
                    { 40, "100 Boye-Ogundiya Way", "reader30@library.com", 1, 1, "Reader User30", "1111111140", 2 },
                    { 41, "200 Hall Street", "reader31@library.com", 0, 2, "Reader User31", "1111111141", 2 },
                    { 42, "200 Hall Street", "reader32@library.com", 1, 2, "Reader User32", "1111111142", 2 },
                    { 43, "200 Hall Street", "reader33@library.com", 2, 2, "Reader User33", "1111111143", 2 },
                    { 44, "200 Hall Street", "reader34@library.com", 0, 2, "Reader User34", "1111111144", 2 },
                    { 45, "200 Hall Street", "reader35@library.com", 1, 2, "Reader User35", "1111111145", 2 },
                    { 46, "300 Hua Avenue", "reader36@library.com", 0, 3, "Reader User36", "1111111146", 2 },
                    { 47, "300 Hua Avenue", "reader37@library.com", 1, 3, "Reader User37", "1111111147", 2 },
                    { 48, "300 Hua Avenue", "reader38@library.com", 2, 3, "Reader User38", "1111111148", 2 },
                    { 49, "300 Hua Avenue", "reader39@library.com", 0, 3, "Reader User39", "1111111149", 2 },
                    { 50, "300 Hua Avenue", "reader40@library.com", 1, 3, "Reader User40", "1111111150", 2 },
                    { 51, "400 Mitchell Road", "reader41@library.com", 0, 4, "Reader User41", "1111111151", 2 },
                    { 52, "400 Mitchell Road", "reader42@library.com", 1, 4, "Reader User42", "1111111152", 2 },
                    { 53, "400 Mitchell Road", "reader43@library.com", 2, 4, "Reader User43", "1111111153", 2 },
                    { 54, "400 Mitchell Road", "reader44@library.com", 0, 4, "Reader User44", "1111111154", 2 },
                    { 55, "400 Mitchell Road", "reader45@library.com", 1, 4, "Reader User45", "1111111155", 2 },
                    { 56, "500 Solomon Boulevard", "reader46@library.com", 0, 5, "Reader User46", "1111111156", 2 },
                    { 57, "500 Solomon Boulevard", "reader47@library.com", 1, 5, "Reader User47", "1111111157", 2 },
                    { 58, "500 Solomon Boulevard", "reader48@library.com", 2, 5, "Reader User48", "1111111158", 2 },
                    { 59, "500 Solomon Boulevard", "reader49@library.com", 0, 5, "Reader User49", "1111111159", 2 },
                    { 60, "500 Solomon Boulevard", "reader50@library.com", 1, 5, "Reader User50", "1111111160", 2 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "BookID", "DateBorrowed", "DueDate", "LoanStatus", "LocationID", "UserID" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 3 },
                    { 2, 3, new DateTime(2025, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 2 },
                    { 3, 6, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1 },
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
                    { 36, 33, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 25 },
                    { 37, 68, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 3 },
                    { 38, 69, new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 3 },
                    { 39, 70, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 3 },
                    { 40, 71, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 3 },
                    { 41, 72, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 3 },
                    { 42, 73, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 43, 74, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 44, 75, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 12 },
                    { 45, 76, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, 12 },
                    { 46, 77, new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 12 },
                    { 47, 78, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 13 },
                    { 48, 79, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 13 },
                    { 49, 80, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 13 },
                    { 50, 81, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 14 },
                    { 51, 82, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 14 },
                    { 52, 83, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 14 },
                    { 53, 84, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 15 },
                    { 54, 85, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 15 },
                    { 55, 86, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, 15 },
                    { 56, 87, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 16 },
                    { 57, 88, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 16 },
                    { 58, 89, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 16 },
                    { 59, 90, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 17 },
                    { 60, 91, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 17 },
                    { 61, 92, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 17 },
                    { 62, 93, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 18 },
                    { 63, 94, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 18 },
                    { 64, 95, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 18 },
                    { 65, 96, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 19 },
                    { 66, 97, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 19 },
                    { 67, 98, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 19 },
                    { 68, 99, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 20 },
                    { 69, 100, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 20 },
                    { 70, 101, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 20 },
                    { 71, 102, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 21 },
                    { 72, 103, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 21 },
                    { 73, 104, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 21 },
                    { 74, 105, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 22 },
                    { 75, 106, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, 22 },
                    { 76, 107, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 22 },
                    { 77, 108, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 23 },
                    { 78, 109, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 23 },
                    { 79, 110, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 23 },
                    { 81, 112, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 24 },
                    { 82, 113, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 24 },
                    { 83, 114, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 25 },
                    { 84, 115, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 25 },
                    { 85, 116, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 25 },
                    { 86, 117, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 26 },
                    { 87, 118, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 26 },
                    { 88, 119, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 26 },
                    { 89, 120, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 27 },
                    { 90, 121, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 27 },
                    { 91, 122, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 27 },
                    { 92, 123, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 28 },
                    { 93, 124, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 28 },
                    { 94, 125, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 28 },
                    { 95, 126, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, 29 },
                    { 96, 127, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 29 },
                    { 97, 128, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 29 },
                    { 98, 129, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 30 },
                    { 99, 130, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 30 },
                    { 100, 131, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 30 },
                    { 101, 132, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 31 },
                    { 102, 133, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 31 },
                    { 103, 134, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 31 },
                    { 104, 135, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 32 },
                    { 105, 136, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 32 },
                    { 106, 137, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 32 },
                    { 107, 138, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 33 },
                    { 108, 139, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 33 },
                    { 109, 140, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 33 },
                    { 110, 141, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 34 },
                    { 111, 142, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 34 },
                    { 112, 143, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 34 },
                    { 113, 144, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 35 },
                    { 114, 145, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 35 },
                    { 115, 146, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, 35 },
                    { 116, 147, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 36 },
                    { 117, 148, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 36 },
                    { 118, 149, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 36 },
                    { 119, 150, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, 37 },
                    { 120, 151, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 37 },
                    { 121, 152, new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 37 },
                    { 122, 153, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 38 },
                    { 123, 154, new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 38 },
                    { 124, 155, new DateTime(2025, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 38 },
                    { 125, 156, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 39 },
                    { 126, 157, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 39 },
                    { 127, 158, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 39 },
                    { 128, 159, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 40 },
                    { 129, 160, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 40 },
                    { 130, 161, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 40 },
                    { 131, 162, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 41 },
                    { 132, 163, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 41 },
                    { 133, 164, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 41 },
                    { 134, 165, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 42 },
                    { 135, 166, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, 42 },
                    { 136, 167, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 42 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LocationID",
                table: "Books",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookID",
                table: "Loans",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LocationID",
                table: "Loans",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserID",
                table: "Loans",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationID",
                table: "Users",
                column: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
