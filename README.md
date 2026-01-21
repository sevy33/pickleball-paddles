# Pickleball Paddles Application

This is a full-stack application for browsing and reviewing pickleball paddles. It is built with:
- **Database**: PostgreSQL
- **Server**: ASP.NET Core Web API (.NET 9)
- **Client**: Angular

## Prerequisites

Before running the application, ensure you have the following installed:
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Node.js](https://nodejs.org/) (LTS version recommended) and npm

## Getting Started

Follow these steps to get the application running locally.

### 1. Database Setup

The database is containerized using Docker.

1. Open a terminal and navigate to the `CompletedApp` folder:
   ```bash
   cd CompletedApp
   ```
2. Start the database container:
   ```bash
   docker-compose up -d
   ```
   This will start a PostgreSQL instance on port `5432` and seed it with initial data from `database/init.sql`.

### 2. Server Setup

The backend is an ASP.NET Core Web API.

1. Navigate to the server directory:
   ```bash
   cd CompletedApp/server
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
   The API will be available at `http://localhost:5129`.
   
   *Note: The server is configured to connect to the database with the default credentials found in `appsettings.json` (`Password=password`).*

### 3. Client Setup

The frontend is an Angular application.

1. Navigate to the client directory:
   ```bash
   cd CompletedApp/client
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   npm start
   ```
   The application will automatically reload if you change any of the source files.
   Once compiled, navigate to `http://localhost:4200/` in your browser.