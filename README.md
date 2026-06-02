# E-Commerce API - Backend (Clean Architecture)

Proyecto final de la asignatura Backend (Optativa II) - Tecnicatura Universitaria en Desarrollo de Software.

## Tecnologías utilizadas
- .NET 8
- Clean Architecture
- Entity Framework Core + SQLite
- MediatR + CQRS
- FluentValidation
- Global Exception Handler + ProblemDetails

## Endpoints Principales

### Auth
- `POST /api/auth/login` → Login de usuarios

### Products
- `POST /api/products` → Crear producto
- `GET /api/products` → Listar productos
- `GET /api/products/{id}` → Obtener por ID
- `PUT /api/products/{id}` → Actualizar producto
- `DELETE /api/products/{id}` → Eliminar producto

### Orders
- `POST /api/orders` → Crear orden
- `GET /api/orders/{id}` → Obtener orden por ID
- `GET /api/orders/user/{userId}` → Órdenes de un usuario

## Arquitectura del Proyecto

El proyecto está organizado en **4 capas** siguiendo Clean Architecture:

- **Domain**: Entidades, Value Objects, Excepciones de dominio, Interfaces (Ports) y reglas de negocio.
- **Application**: Casos de uso (Commands y Queries), Validaciones con FluentValidation y MediatR.
- **Infrastructure**: Implementaciones concretas (EF Core, Repositorios), DbContext y configuraciones.
- **Api (Presentation)**: Controladores, Middleware y configuración de servicios.

## Principios aplicados
- Dependency Inversion Principle (DIP)
- Separación de responsabilidades
- Reglas de negocio encapsuladas en las entidades
- Validaciones centralizadas
- Manejo global de excepciones

## Cómo ejecutar el proyecto

1. Clonar el repositorio
2. Ejecutar `dotnet restore`
3. Ejecutar `dotnet ef database update --project ECommerce.Infrastructure --startup-project ECommerce.Api`
4. Ejecutar `dotnet run --project ECommerce.Api`
5. Abrir Swagger: `https://localhost:xxxx/swagger`
