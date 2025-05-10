# ConsultorioOPI
Repositorio par la prueba técnica de OPI

# ConsultorioOPI

Este es un sistema de gestión para un consultorio médico que permite administrar médicos, pacientes y turnos, desarrollado con .NET Core y arquitectura en capas.

---

## Tecnologías Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- AutoMapper
- SQL Server
- Swagger (OpenAPI)
- xUnit + Moq (para pruebas unitarias)
- Arquitectura en capas (API, Services, Repositories, Domain, Persistence)

## Arquitectura del Proyecto

├── Api → Controladores (Web API)
├── Logic → Servicios (negocio)
├── Domain → DTOs y entities
├── Repository → Acceso a datos
│ ├── Interfaces → Interfaces de repositorio
│ └── Persistence → EF Models y contexto
├── Tests → Pruebas unitarias e integración
└── ConsultorioOPI.sln → Solución principal

## Configuración del Entorno y despliegue

### 1. Clonar el repositorio
git clone https://github.com/tu-usuario/ConsultorioOPI.git
cd ConsultorioOPI

### Restaurar dependencias
dotnet restore

### Ejecutar proyecto 
dotnet run --project ConsultorioOPI.Api

### Mapear el modelo y actualizar el DBContext 
Scaffold-DbContext -Connection name=ConsultorioOPIDB -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Persistence\Models -ContextDir Persistence -Context ConsultorioOPIContext 

### Pruebas 
dotnet test

## Autor
Juan Camilo Zuluaga 
jzuluagau23@hotmail.com
