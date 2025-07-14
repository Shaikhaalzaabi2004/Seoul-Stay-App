
# Seoul Stay WPF Application

Welcome to **Seoul Stay**, a Windows Presentation Foundation (WPF) application designed for hotel management.

## Features

- User registration and management
- Room booking and availability


## Getting Started

### Prerequisites

- [.NET Framework](https://dotnet.microsoft.com/download)
- SQL Server or compatible database

### Database Setup

1. Locate the `DATABASE_SCRIPT.sql` file in the project directory.
2. Execute the script in your SQL Server to create the required database and tables.

### Configuration

1. Open `Models/Ih04Context.cs`.
2. Update the connection string to match your database settings:
    ```csharp
    optionsBuilder.UseSqlServer("Your_Connection_String_Here");
    ```

## Running the Application

1. Build the solution in Visual Studio.
2. Run the application.

## Support

For issues or feature requests, please open an issue in this repository.

---

**Seoul Stay** © 2024