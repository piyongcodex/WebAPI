📌 Generic Web API (ASP.NET Core + Clean Architecture)

A sample Generic Web API built using ASP.NET Core, C#, and modern architecture practices.

This project is designed for learning and practicing:

Clean Architecture

Repository Pattern

Validation (FluentValidation)

Dependency Injection

Result Pattern

Separation of Concerns

🧩 Project Structure
src/
├── CQRSpattern.API/                  // Services and Middlewares
├── CQRSpattern.Presentation/         // Presentation layer (Controllers)
├── CQRSpattern.Application/          // Business logic, Use cases, DTOs
├── CQRSpattern.Domain/               // Entities, Value Objects, Enums, Interfaces
├── CQRSpattern.Infrastructure/       // Data access, EF Core, Repositories, Services, Migrations, Configurations
                                    

🚀 Key Features
✔️ Clean Architecture

Clear separation of layers.

Each layer has a specific responsibility.

Dependency direction is inward (outer layers depend on inner layers).

✔️ Repository Pattern

Centralized data access logic.

Abstraction of data operations.

Unit test friendly.

✔️ Validation

Request validation using FluentValidation or DataAnnotations

Ensures clean and reliable API input.

✔️ Dependency Injection

Built-in ASP.NET Core DI.

All dependencies are registered in Startup / Program.

✔️ Result Pattern

Standardized response structure.

Handles success & failure uniformly.

Example:

{
  "isSuccess": true,
  "message": "Operation completed successfully",
  "data": {...}
}

🧠 Layers Description
✅ Domain

Contains the core business models and rules.

Domain/
├── Entities/
├── ValueObjects/
└── Enums/

✅ Application

Contains business use cases and service interfaces.

Application/
├── DTOs/
├── Interfaces/
├── Services/
└── UseCases/

✅ Infrastructure

Contains database context, repository implementations, and external services.

Infrastructure/
├── Data/
├── Repositories/
└── Services/

✅ Api

Contains controllers and API configurations.

Api/
├── Controllers/
├── Middleware/
└── Program.cs

🔧 Technologies Used

ASP.NET Core Web API

C# (.NET 6/7/8)

Entity Framework Core

SQL Server / SQLite

FluentValidation

AutoMapper (optional)

Swagger (Swashbuckle)

🧪 Running the Project
✅ Prerequisites

.NET 6/7/8 SDK installed

SQL Server / SQLite

⏯ Run API
dotnet run --project src/Api

🧩 Example Endpoints
Method	Endpoint	Description
GET	/api/v1/products	Get all products
GET	/api/v1/products/{id}	Get product by ID
POST	/api/v1/products	Create new product
PUT	/api/v1/products/{id}	Update product
DELETE	/api/v1/products/{id}	Delete product
🧾 Result Pattern Example
Result Class
public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}

Controller Response
return Ok(new Result<ProductDto>
{
    IsSuccess = true,
    Message = "Product retrieved successfully",
    Data = productDto
});

🧰 Best Practices

✅ Use DTOs to avoid exposing domain entities
✅ Validate requests using FluentValidation
✅ Keep controllers thin (only handle HTTP + call use cases)
✅ Implement business rules in Application layer
✅ Use Repository pattern for DB access

🧩 Contribution

Feel free to contribute to improve the architecture, add features, or optimize the code.
