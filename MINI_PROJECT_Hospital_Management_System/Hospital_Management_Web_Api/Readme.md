
# 🏥 Hospital Management System API

A Hospital Management System developed using **ASP.NET Core Web API**, **ADO.NET**, **SQL Server**, and **Stored Procedures** following a clean **Layered Architecture**.

The system manages **Patients**, **Doctors**, and **Appointments** while implementing business validations, global exception handling, logging middleware, and dependency injection.

---

## 🚀 Features

### Patient Management
- Add Patient
- Update Patient
- View All Patients
- Deactivate Patient (Soft Delete)

### Doctor Management
- Add Doctor
- View Doctors
- Search Doctors by Specialization

### Appointment Management
- Book Appointment
- Cancel Appointment
- View Upcoming Appointments
- View Doctor Appointments

### Reports
- Appointment Report
- Revenue by Specialization
- Doctors with More Than 2 Appointments

---

## 🏗️ Architecture

The project follows a **3-Layer Architecture**:

```text
Client/Postman
       ↓
Controller Layer
       ↓
Service Layer
       ↓
Repository Layer
       ↓
Stored Procedures
       ↓
SQL Server Database
```

### Responsibilities

| Layer | Responsibility |
|---------|---------------|
| Controller | Handles HTTP Requests/Responses |
| Service | Business Logic & Validation |
| Repository | Database Access using ADO.NET |
| Database | SQL Server + Stored Procedures |

---

## 📁 Project Structure

```text
HospitalManagementAPI
│
├── Controllers
│   ├── PatientController.cs
│   ├── DoctorController.cs
│   └── AppointmentController.cs
│
├── Models
│   ├── Common
│   │   └── PersonBase.cs
│   │
│   ├── Patient.cs
│   ├── Doctor.cs
│   ├── Appointment.cs
│   │
│   └── DTOs
│
├── Services
│   ├── Interfaces
│   ├── PatientService.cs
│   ├── DoctorService.cs
│   └── AppointmentService.cs
│
├── Repositories
│   ├── Interfaces
│   ├── PatientRepository.cs
│   ├── DoctorRepository.cs
│   └── AppointmentRepository.cs
│
├── Middleware
│   ├── ExceptionMiddleware.cs
│   └── RequestLoggingMiddleware.cs
│
├── Exceptions
│
├── Database
│   ├── Tables.sql
│   ├── Procedures.sql
│   └── SampleData.sql
│
├── Program.cs
└── appsettings.json
```

---

## 🗄️ Database Design

### Patients

| Column |
|----------|
| PatientId (PK) |
| PatientCode |
| FullName |
| DOB |
| Gender |
| Phone |
| Email |
| IsActive |
| CreatedAt |

### Doctors

| Column |
|----------|
| DoctorId (PK) |
| DoctorCode |
| FullName |
| Specialization |
| Phone |
| ConsultationFee |
| IsAvailable |

### Appointments

| Column |
|----------|
| AppointmentId (PK) |
| PatientId (FK) |
| DoctorId (FK) |
| AppointmentDate |
| Status |
| CancelledAt |
| CreatedAt |

---

## 🔑 Key Concepts Implemented

### Layered Architecture

```text
Controller
   ↓
Service
   ↓
Repository
   ↓
Database
```

### Stored Procedures

All database operations are performed through Stored Procedures.

Examples:

```sql
sp_AddPatient
sp_UpdatePatient
sp_DeactivatePatient

sp_AddDoctor
sp_GetDoctors

sp_BookAppointment
sp_CancelAppointment

sp_GetAppointmentReport
```

### Soft Delete

Patients are not permanently deleted.

```sql
IsActive = 0
```

This helps preserve historical appointment records.

### Dependency Injection

Repositories and Services are registered using ASP.NET Core Dependency Injection.

```csharp
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
```

### Middleware

Implemented:

- Global Exception Handling
- Request Logging

---

## ⚙️ Technologies Used

- ASP.NET Core Web API
- C#
- ADO.NET
- SQL Server
- Stored Procedures
- Dependency Injection
- Middleware
- Swagger
- Postman

---

## 🧠 Business Validations

### Appointment Booking

- Appointment date cannot be in the past
- Doctor must be available
- Patient must be active
- Invalid requests throw custom exceptions

Example:

```csharp
if (appointmentDate < DateTime.Now)
{
    throw new InvalidAppointmentException(
        "Past appointments are not allowed");
}
```

---

## 🔄 API Endpoints

### Patient APIs

| Method | Endpoint |
|----------|----------|
| POST | /api/patient |
| GET | /api/patient |
| PUT | /api/patient/{id} |
| DELETE | /api/patient/{id} |

### Doctor APIs

| Method | Endpoint |
|----------|----------|
| POST | /api/doctor |
| GET | /api/doctor |
| GET | /api/doctor/specialization/{specialization} |

### Appointment APIs

| Method | Endpoint |
|----------|----------|
| POST | /api/appointment |
| DELETE | /api/appointment/{id} |
| GET | /api/appointment/upcoming |
| GET | /api/appointment/doctor/{doctorId} |

---

## ▶️ Running the Project

### Clone Repository

```bash
git clone <repository-url>
```

### Restore Packages

```bash
dotnet restore
```

### Configure Connection String

Update `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### Run Database Scripts

Execute:

```sql
Tables.sql
Procedures.sql
SampleData.sql
```

### Run Project

```bash
dotnet run
```

### Open Swagger

```text
https://localhost:<port>/swagger
```

---

## 🧪 Testing

API testing was performed using:

- Swagger UI
- Postman

Test Scenarios:

- Add Patient
- Update Patient
- Add Doctor
- Book Appointment
- Cancel Appointment
- Generate Reports

---

## 📚 Learning Outcomes

This project helped in understanding:

- ASP.NET Core Web API
- ADO.NET
- SQL Server
- Stored Procedures
- Repository Pattern
- Service Layer Pattern
- Dependency Injection
- Middleware
- Exception Handling
- Layered Architecture

---

## 👨‍💻 Author

**Nandeesh Hiremath**
ASP.NET Core | SQL Server | ADO.NET | Web API
