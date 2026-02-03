# 🚀 Generic Web API

A production-ready RESTful API built with .NET 8.0, showcasing modern architecture patterns and enterprise-grade tooling.

## 📋 Overview

This project demonstrates a scalable, maintainable API solution following industry best practices. Built as a personal portfolio project to showcase full-stack backend development capabilities with a focus on clean code, security, and observability.

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core 8.0 (C#)
- **Database:** MySQL
- **Containerization:** Podman
- **Logging & Analytics:** ELK Stack + Seq
- **Authentication:** Keycloak (Identity Provider)
- **API Testing:** Postman

## 🏗️ Architecture & Design Patterns

This project follows **Clean Architecture** principles and implements:

- ✅ **SOLID Principles** - Maintainable, testable, and scalable code
- ✅ **CQRS Pattern** - Separation of read and write operations
- ✅ **Repository Pattern** - Abstraction of data access logic
- ✅ **Result Pattern** - Type-safe error handling
- ✅ **Clean Architecture** - Domain-centric design with clear separation of concerns

## 🔐 Security

- OAuth 2.0 / OpenID Connect via **Keycloak**
- Token-based authentication
- Secure API endpoints with role-based access control

## 📊 Observability

- **ELK Stack** (Elasticsearch, Logstash, Kibana) for centralized logging
- **Seq** for structured log analytics and debugging
- Request/response logging and performance monitoring

## 📂 Project Structure
```
WebAPI/
├── src/
│   ├── CQRSpattern.API/              # Register Services
│   ├── CQRSpattern.Application/      # Business logic (CQRS handlers)
│   ├── CQRSpattern.Domain/           # Core entities and interfaces
│   ├── CQRSpattern.Infrastructure/   # Data access, external services
|   ├── CQRSpattern.Presentation/     # Controllers

```

## 🎯 Key Features

- RESTful API design following OpenAPI standards
- Centralized error handling and logging
- Containerized deployment with Podman
- Scalable architecture for enterprise applications
- Comprehensive authentication and authorization

## 📧 Contact

**Rio Sumandal (PiyongX)**  
📧 rio.sumandal0907@gmail.com  
💼 [LinkedIn](https://www.linkedin.com/in/rio-sumandal-479042253/)

## 📝 License

This project is licensed under a proprietary license - all rights reserved.

---
