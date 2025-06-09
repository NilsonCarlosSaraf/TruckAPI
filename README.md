# TruckAPI

This is a simple .NET 8 Web API project that manages a fleet of vehicles, including cars, buses, and trucks. The project follows clean architecture principles and includes unit tests using xUnit, FluentAssertions, and Bogus.

## 🚀 Features

- Insert a new vehicle
- Update vehicle color by chassis ID
- List all vehicles
- Get vehicle details by chassis ID
- In-memory data store (no database required)
- Modular architecture (Domain, Application, Infrastructure, API)

---

## ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or later (with ASP.NET and test tools workloads)
- Optional: `curl` or Postman for testing the API

---

## Example of a working payload for the POST endpoint:

the field "type" will only accept "car","bus" or "truck" as a value.
{
"series": "cr25",
"number": 0,
"type": "car",
"color": "blue"
}

## 📦 How to Run

1. **Clone the repository**

```bash
git clone https://github.com/NilsonCarlosSaraf/TruckAPI.git
cd TruckAPI
```

2. **Select ProgrammingExercise.Api as STARTUP project in the Visual Studio**

3. **Run the API**

🗂 Project Structure

src/
├── ProgrammingExercise.Api # Web API (controllers)
├── ProgrammingExercise.Application # Business logic (services)
├── ProgrammingExercise.Communication # DTOs and contracts
├── ProgrammingExercise.Domain # Core domain entities and interfaces
├── ProgrammingExercise.Infrastructure # In-memory repository
├── ProgrammingExercise.Exception # Custom exception types

tests/
├── ProgrammingExercise.Application.Test # Unit tests for Application layer

🧠 Notes
No external database required — data is stored in memory.

Ideal for testing API patterns, unit testing, and clean code practices.

Ready to evolve to use EF Core and MySQL if needed.
