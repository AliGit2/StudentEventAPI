# 🎓 Student Event Management System — ASP.NET Core Web API

A complete backend RESTful API for managing student events, registrations, and feedback built with **ASP.NET Core 9.0** and **Entity Framework Core 8.0+**.

---

## 👥 Group Members

| # | Name | Student ID | Role |
|---|---|---|---|
| 1 | **Syed Ali Raza** | 67438 | Lead Developer — API, Services, Controllers |
| 2 | **Muneer Akhtar** | 67229 | Models, DTOs, Database Schema |
| 3 | **Iqrar Hussain** | 68099 | Testing, Documentation, Report |

| Field | Details |
|---|---|
| **Program** | BS Software Engineering |
| **University** | Iqra University, Karachi |
| **Department** | FEST — Faculty of Engineering Sciences & Technology |
| **Course** | Web Engineering |
| **Semester** | Spring 2026 |

---

## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [API Endpoints](#api-endpoints)
- [Usage Examples](#usage-examples)
- [Error Handling](#error-handling)
- [Architecture](#architecture)

---

## 📌 Project Overview

The **Student Event Management System** is a backend API that allows:

- ✅ Full CRUD operations for Events
- ✅ Student creation and management
- ✅ Many-to-many Student–Event Registration
- ✅ Duplicate registration prevention (409 Conflict)
- ✅ Post-event Feedback submission with date validation
- ✅ Search events by name or venue
- ✅ Filter and sort events by date
- ✅ Proper HTTP status codes and error messages
- ✅ Swagger UI for interactive API documentation

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|---|---|---|
| ASP.NET Core | 9.0 | Web API Framework |
| Entity Framework Core | 8.0+ | ORM & Database Access |
| SQL Server LocalDB | Latest | Relational Database |
| Swashbuckle / Swagger | 10.x | API Documentation |
| Visual Studio | 2022 | IDE |
| .NET SDK | 9.0+ | Build & Runtime |

---

## 📁 Project Structure

```
StudentEventAPI/
│
├── Controllers/
│   ├── EventsController.cs
│   ├── StudentsController.cs
│   ├── RegistrationsController.cs
│   └── FeedbackController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── DTOs/
│   ├── EventDto.cs
│   ├── StudentDto.cs
│   ├── RegistrationDto.cs
│   └── FeedbackDto.cs
│
├── Models/
│   ├── Event.cs
│   ├── Student.cs
│   ├── Registration.cs
│   └── Feedback.cs
│
├── Services/
│   ├── Interfaces/
│   │   ├── IEventService.cs
│   │   ├── IRegistrationService.cs
│   │   └── IFeedbackService.cs
│   │
│   ├── EventService.cs
│   ├── RegistrationService.cs
│   └── FeedbackService.cs
│
├── appsettings.json
└── Program.cs
```

---

## ✅ Prerequisites

Make sure you have these installed before running the project:

- [.NET SDK 9.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with ASP.NET workload)
- SQL Server LocalDB (comes with Visual Studio)

---

## 🚀 Setup Instructions

### Step 1 — Clone or Download the Project

```bash
git clone https://github.com/yourusername/StudentEventAPI.git
cd StudentEventAPI
```

### Step 2 — Open in Visual Studio

Open `StudentEventAPI.sln` in Visual Studio 2022.

### Step 3 — Check Connection String

Open `appsettings.json` and verify:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StudentEventDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Step 4 — Install NuGet Packages

Open **Package Manager Console** (Tools → NuGet Package Manager → Package Manager Console) and run:

```
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Swashbuckle.AspNetCore
```

### Step 5 — Run Migrations

In Package Manager Console:

```
Add-Migration InitialCreate
Update-Database
```

### Step 6 — Run the Project

Press **F5** or click the green **https** button.

Your browser will open. Navigate to:

```
https://localhost:7279/swagger
```

You should see the Swagger UI with all endpoints listed. ✅

---

## 📡 API Endpoints

### Students

| Method | Endpoint | Description | Status |
|---|---|---|---|
| POST | `/api/students` | Create a new student | 201 |
| GET | `/api/students` | Get all students | 200 |
| GET | `/api/students/{id}` | Get student by ID | 200 / 404 |

### Events

| Method | Endpoint | Description | Status |
|---|---|---|---|
| GET | `/api/events` | List all upcoming events | 200 |
| POST | `/api/events` | Create a new event | 201 |
| GET | `/api/events/{id}` | Get event by ID | 200 / 404 |
| PUT | `/api/events/{id}` | Update an event | 200 / 404 |
| DELETE | `/api/events/{id}` | Delete an event | 200 / 404 |
| GET | `/api/events/search?query=xyz` | Search by name or venue | 200 |
| GET | `/api/events/filter?sort=date` | Filter events by date | 200 |

### Registrations

| Method | Endpoint | Description | Status |
|---|---|---|---|
| POST | `/api/registrations` | Register student for event | 201 / 409 / 404 |

### Feedback

| Method | Endpoint | Description | Status |
|---|---|---|---|
| POST | `/api/feedback` | Submit feedback for an event | 201 / 400 / 404 |

---

## 💡 Usage Examples

### Create a Student
```http
POST /api/students
Content-Type: application/json

{
  "name": "Syed Ali Raza",
  "email": "ali@iqra.edu.pk",
  "studentNumber": "67438"
}
```

### Create an Event
```http
POST /api/events
Content-Type: application/json

{
  "title": "Tech Summit 2026",
  "description": "Annual technology conference",
  "venue": "Iqra University Karachi",
  "eventDate": "2026-12-01T10:00:00",
  "capacity": 100
}
```

### Register Student for Event
```http
POST /api/registrations
Content-Type: application/json

{
  "studentId": 1,
  "eventId": 1
}
```

### Search Events
```http
GET /api/events/search?query=Tech
```

### Filter Events by Date
```http
GET /api/events/filter?sort=date
```

### Submit Feedback (only works after event date)
```http
POST /api/feedback
Content-Type: application/json

{
  "eventId": 1,
  "studentId": 1,
  "rating": 5,
  "comment": "Amazing event!"
}
```

---

## ⚠️ Error Handling

| Scenario | HTTP Code | Message |
|---|---|---|
| Resource not found | 404 | `"Event not found."` / `"Student not found."` |
| Duplicate registration | 409 | `"Student is already registered for this event."` |
| Feedback before event date | 400 | `"Feedback can only be submitted after the event has occurred."` |
| Invalid rating (not 1–5) | 400 | `"Rating must be between 1 and 5."` |

---

## 🏗️ Architecture

The project follows a clean **layered architecture**:

```
Client Request
      ↓
  Controller        → Handles HTTP request/response
      ↓
   Service          → Business logic + validation
      ↓
  AppDbContext      → EF Core database operations
      ↓
  SQL Server        → Data persistence
```

### Layers

| Layer | Folder | Responsibility |
|---|---|---|
| Presentation | `Controllers/` | HTTP routing, request/response |
| Business Logic | `Services/` | Rules, validation, DTO mapping |
| Abstraction | `Services/Interfaces/` | Dependency inversion |
| Data Transfer | `DTOs/` | Decouple API from domain models |
| Domain | `Models/` | Core entities |
| Data Access | `Data/` | EF Core DbContext |

### Database Schema

```
Students ──< Registrations >── Events
                                  │
                               Feedbacks
```

- **Student ↔ Event** — Many-to-Many via Registration table
- **Event → Feedbacks** — One-to-Many
- **Registration** has unique index on (StudentId, EventId)

---

## 📖 Swagger Documentation

After running the project, visit:

```
https://localhost:7279/swagger
```

All endpoints are fully documented and testable directly from the browser.

---

## 📝 Recommended Testing Order

```
1.  POST /api/students          → Create student
2.  POST /api/events            → Create future event
3.  POST /api/events            → Create past event (2024 date)
4.  GET  /api/events            → List upcoming events
5.  GET  /api/events/{id}       → Get event by ID
6.  PUT  /api/events/{id}       → Update event
7.  POST /api/registrations     → Register student for event
8.  POST /api/registrations     → Same again → 409 Conflict ✅
9.  GET  /api/events/search     → query=Tech
10. GET  /api/events/filter     → sort=date
11. POST /api/feedback          → Future event → 400 ✅
12. POST /api/feedback          → Past event → 201 ✅
13. DELETE /api/events/{id}     → Delete event
```

---

## 🔮 Optional Future Enhancements

- [ ] JWT-based authentication and role-based access
- [ ] Pagination for event listings
- [ ] Deploy API on Azure or Render
- [ ] Unit tests with xUnit
- [ ] GET /api/registrations — list all registrations

---

*Student Event Management System — Web Engineering CCP — Iqra University 2026*
