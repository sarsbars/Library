# Library Management System

## Overview
The Library Management System is a web application developed for the **Advanced Database and ORM Concepts** course (SD-330-W25) at Manitoba Institute of Trades and Technology

### Purpose
- Manage library resources with CRUD operations for books, users, loans, and locations.
- Implement role-based access: Admins (full CRUD), Staff (read/edit), Readers (read only)

### Key Features
- **Database**: SQL Server with EF Core Code-First, seeding 367 books, 60 users, 135 loans, 5 locations.
- **Authentication**: ASP.NET Core Identity with roles (Admin, Staff, Reader).
- **Recommendations**: Suggests books for Readers based on borrowed authors, genres, or available books at their library.
- **UI**: Bootstrap-based with role-based rendering 
- **Composite Views**: Dashboard (statistics), CheckOut/Rentals (holds/loans), Recommendation Center (loan history/recommendations).

## Group Contributions
- **Sarah Mitchell**:
  - Configured Git repository and managed version control.
  - Designed `LibraryDBContext` with EF Core relationships (e.g., `Book-Loan` one-to-many).
  - Seeded sample data and handled migrations
  - Implemented Identity with roles (Admin, Staff, Reader) 
  - Drafted README and presentation slides.
  - Built Locations CRUD (index, details, create, update, delete)
- **Connor Hall**:
  - Built Books CRUD (index, details, create, update, delete).
  - Developed Recommendation Center showing loan history, popular genres/authors.
- **Ayomide Boye-Ogundiya**:
  - Built Users CRUD (index, details, create, update, delete).
  - Created CheckOut/Rentals + Holds page (holds, current loans, recent books).
- **Ashedzi Solomon**:
  - Built Loans CRUD (index, details, create, update, delete).
  - Developed Dashboard with statistics (books, users, loans, overdue books).
  - Designed UI 


<img width="1331" height="819" alt="image" src="https://github.com/user-attachments/assets/edd4894c-d5f9-43c9-b698-c275bd72777f" />

<img width="1364" height="728" alt="image" src="https://github.com/user-attachments/assets/e81db7e0-6baf-4faa-a71c-d1b3b97604b1" />

<img width="1322" height="381" alt="image" src="https://github.com/user-attachments/assets/23cd3943-1f62-4424-a62a-7ba8be754f83" />

##Test Accounts:

-Admin: admin1@library.com (password: Admin@123)
-Staff: staff1@library.com (password: Staff@123)
-Reader: reader1@library.com (password: Reader@123)
