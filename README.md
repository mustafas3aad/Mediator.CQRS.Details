# Mediator.CQRS.Details

A practical implementation of the **CQRS (Command Query Responsibility Segregation)** and **Mediator Pattern** using **ASP.NET Core Web API** and **MediatR**.

This project demonstrates how to build a clean and scalable backend architecture by separating read and write operations into commands and queries while using MediatR to decouple request handling logic.

---

## 🚀 Features

- Clean CQRS Architecture
- MediatR Integration
- ASP.NET Core Web API
- Separation of Commands & Queries
- Request / Response Handling
- Dependency Injection
- Scalable and Maintainable Structure
- RESTful API Design

---

## 🛠️ Technologies Used

<p align="center">
  <img src="https://img.shields.io/badge/ASP.NET_Core_Web_API-512BD4?style=flat-square&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white" />
  <img src="https://img.shields.io/badge/MediatR-Mediator_Pattern-7c3aed?style=flat-square" />
  <img src="https://img.shields.io/badge/CQRS-Architecture-9333EA?style=flat-square" />
  <img src="https://img.shields.io/badge/Entity_Framework_Core-6B46C1?style=flat-square&logo=.net&logoColor=white" />
  <img src="https://img.shields.io/badge/SQL_Server-Database-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white" />
  <img src="https://img.shields.io/badge/LINQ-Queries-0C54C2?style=flat-square&logo=csharp&logoColor=white" />
</p>

---

## 📂 Project Structure

```bash
Mediator.CQRS.Details
│
├── Commands
│   ├── Create
│   ├── Update
│   └── Delete
│
├── Queries
│   ├── GetAll
│   └── GetById
│
├── Handlers
├── Models
├── Data
├── Controllers
└── Program.cs
```

---

## 📌 CQRS Overview

CQRS separates application operations into:

- **Commands** → Change application state (Create, Update, Delete)
- **Queries** → Read data without modifying it

Using the **Mediator Pattern**, requests are sent through a mediator instead of calling services directly, resulting in loose coupling and cleaner architecture.

---

## 📬 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/products | Get all products |
| GET | /api/products/{id} | Get product by id |
| POST | /api/products | Create new product |
| PUT | /api/products/{id} | Update product |
| DELETE | /api/products/{id} | Delete product |

---

## 🎯 Learning Goals

This project is useful for understanding:

- CQRS Pattern
- Mediator Pattern
- MediatR in ASP.NET Core
- Clean architecture principles
- Scalable API structure

---

## 📖 References

- MediatR Documentation
- Microsoft CQRS Documentation
- ASP.NET Core Documentation

---

## 🤝 Contributing

Pull requests are welcome. Feel free to fork the repository and improve the project.

---

## ⭐ Support

If you found this project useful, consider giving it a star ⭐ on GitHub.
