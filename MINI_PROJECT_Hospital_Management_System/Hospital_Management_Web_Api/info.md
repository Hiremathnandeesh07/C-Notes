Flow


Incoming Request
       ↓
RequestLoggingMiddleware
       ↓
ExceptionMiddleware
       ↓
Controller
       ↓
Service
       ↓
Repository
       ↓
Database

Response
       ↑
Repository
       ↑
Service
       ↑
Controller
       ↑
ExceptionMiddleware
       ↑
RequestLoggingMiddleware
       ↑
Client