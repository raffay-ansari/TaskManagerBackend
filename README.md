# TaskManager Backend (.NET 9 + GraphQL + EF Core + SQLite)

This is a sample backend application built with **.NET 9**, **ASP.NET Core**, **HotChocolate GraphQL**, and **Entity Framework Core (SQLite)**. It provides a GraphQL API to manage tasks with the ability to create tasks, update their status, and query all tasks.

---

## Features

- Task model with fields: `id`, `title`, `description`, and `status` (`Pending`, `InProgress`, `Completed`)
- GraphQL API with:
  - Queries: `getAllTasks`
  - Mutations: `createTask`, `updateTaskStatus`
- Data persistence with EF Core and SQLite
- GraphQL playground available at `/graphql`

---

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Optional: [SQLite CLI](https://sqlite.org/download.html) (to inspect the database)

### Setup & Run

1. Clone the repository (or download the source code)

2. Navigate to the project directory

3. Restore dependencies and run:

   ```bash
   dotnet restore
   dotnet run
