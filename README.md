# MoviesAPI

## Description

MoviesAPI is a RESTful API designed for managing a collection of movies. It provides endpoints to create, read, update, and delete movie entries, making it a useful tool for movie enthusiasts and developers looking to integrate movie data into their applications.

## Features

- **CRUD Operations**: Create, read, update, and delete movie records.
- **Search Functionality**: Search for movies by title, genre, or release year.
- **User Authentication**: Secure your API with user authentication (if applicable).
- **Data Validation**: Ensure that all movie entries meet required formats and constraints.
- **Pagination**: Navigate through large sets of movie data easily.

## Technologies Used

- **Backend**: .NET Core
- **Database**: SQL Server (or specify the database used)
- **ORM**: Entity Framework (or specify the ORM used)
- **Authentication**: JWT (or specify the method used)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Seif302010/MoviesAPI.git
2. Restore the dependencies:
   ```bash
   dotnet restore
3. Set up the database connection string in the appsettings.json file:
   ```bash
   "ConnectionStrings": {
      "DefaultConnection": "Your_Connection_String_Here"
    }
4. Apply migrations to create the database schema:
   ```bash
   dotnet ef database update
5. Run the application:
   ```bash
   dotnet run
