# API Prueba Asis

API REST desarrollada en **.NET 8** siguiendo una arquitectura por capas (Clean Architecture), implementando autenticación JWT, CRUD para Productos, Categorías y Proveedores, pruebas unitarias, pruebas de integración y despliegue mediante Docker.

---

# Tecnologías

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- AutoMapper
- JWT Authentication
- xUnit
- Moq
- FluentAssertions
- Docker
- Docker Compose
- GitHub Actions

---

# Arquitectura

La solución se encuentra dividida en los siguientes proyectos:

```
ApiPruebaAsis
│
├── ApiPruebaAsis                 -> API
├── ApiPruebaAsis.Application     -> Casos de uso, DTOs, Interfaces
├── ApiPruebaAsis.Domain          -> Entidades
├── ApiPruebaAsis.Infrastructure  -> DbContext, Repositorios
├── ApiPruebaAsis.UnitTests
└── ApiPruebaAsis.IntegrationTests
```

---

# Requisitos

- .NET SDK 8
- PostgreSQL 16+
- Docker Desktop (Opcional)
- Git

---

# Configuración

Modificar el archivo:

```
appsettings.json
```

Configurando la cadena de conexión.

Ejemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=PruebasAsis;Username=postgres;Password=1234"
}
```

---

# Ejecutar localmente

## Restaurar paquetes

```bash
dotnet restore
```

## Compilar

```bash
dotnet build
```

## Ejecutar la API

```bash
dotnet run --project ApiPruebaAsis
```

La API estará disponible en:

```
https://localhost:5001
```

o

```
http://localhost:5000
```

(según la configuración del proyecto)

Swagger:

```
https://localhost:5001/swagger
```

---

# Pruebas

## Pruebas Unitarias

```bash
dotnet test ApiPruebaAsis.UnitTests
```

## Pruebas de Integración

```bash
dotnet test ApiPruebaAsis.IntegrationTests
```

---

# Docker

## Construir la imagen

```bash
docker build -t apipruebaasis .
```

## Ejecutar con Docker Compose

```bash
docker compose up --build
```

La API quedará disponible en:

```
http://localhost:8080
```

Swagger:

```
http://localhost:8080/swagger
```

La base de datos PostgreSQL quedará disponible en:

```
Host: localhost
Puerto: 5432
Base de datos: PruebasAsis
Usuario: postgres
Contraseña: 1234
```

## Detener los contenedores

```bash
docker compose down
```

Eliminar también los volúmenes:

```bash
docker compose down -v
```

---

# Autenticación

La API utiliza JWT.

Para consumir los endpoints protegidos:

1. Realizar Login.
2. Obtener el token.
3. Enviar el header:

```
Authorization: Bearer {token}
```

---

# Funcionalidades

- Login con JWT
- CRUD Productos
- CRUD Categorías
- CRUD Proveedores
- Paginación
- Validaciones de entrada
- Manejo centralizado de excepciones
- Generación masiva de productos
- Documentación Swagger

---

# Versionamiento

Se utiliza **Git** con una estrategia basada en ramas.

Ramas principales:

- **main**: versión estable.
- **develop**: integración de nuevas funcionalidades.

Convención de commits:

```
feat: nueva funcionalidad

fix: corrección de errores

refactor: mejora de código

test: pruebas

docs: documentación

style: formato de código

chore: tareas de mantenimiento
```

Ejemplos:

```
feat: add supplier CRUD

fix: validate unit price

refactor: improve product service

test: add integration tests
```

---

# CI/CD

Se incluye un pipeline de GitHub Actions ubicado en:

```
.github/workflows/ci.yml
```

El pipeline realiza automáticamente:

- Restauración de dependencias
- Compilación
- Ejecución de pruebas unitarias
- Ejecución de pruebas de integración
- Publicación del proyecto
- (Opcional) Construcción de la imagen Docker

---
#Escabilidad

La aplicación puede escalar horizontalmente desplegando múltiples instancias de la API en contenedores Docker detrás de un balanceador de carga. 
La base de datos PostgreSQL se alojaría en un servicio administrado con posibilidad de réplicas de lectura. 
Para mejorar el rendimiento se podría incorporar Redis como caché para consultas frecuentes y utilizar Kubernetes o Azure App Service con escalado automático basado en CPU, memoria o número de solicitudes. 
Esta arquitectura permite aumentar la capacidad de procesamiento sin modificar el código de la aplicación.

# Autor

Desarrollado por

**Julian David Rangel Arévalo**