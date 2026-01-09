# PokeAPI

Este proyecto es una **API REST** de ejemplo que implementa una Pokedex de la primera generación de Pokémon (1-151), permitiendo la lectura de datos de cada Pokémon y la gestión de equipos para usuarios autenticados.

## Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Arquitectura](#arquitectura)
- [Características Principales](#características-principales)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Endpoints Principales](#endpoints-principales)
- [Créditos y Licencia](#créditos-y-licencia)

---

## Descripción General

**PokeAPI** es un proyecto de demostración desarrollado en **.NET**, utilizando una arquitectura limpia (Clean Architecture) y caracterizado por:

- Exponer información de Pokémon de la primera generación.
- Permitir a usuarios anónimos consultar la lista de Pokémon.
- Permitir registro e identificación de usuarios
- Ofrecer la creación y gestión de equipos Pokémon a usuarios registrados (vía Identity + JWT).

---

## Arquitectura

La solución está dividida en **cuatro proyectos**:

1. **PokeApi.Domain**  
   - Define las **entidades** del dominio (`Pokemon`, `Team`, `TeamPokemon`).
   - Contiene la lógica de negocio.

2. **PokeApi.Application**  
   - Contiene **interfaces** y **servicios** que orquestan la lógica de aplicación, por ejemplo `IPokedexService`, `ITeamService`, etc.
   - Usa los **repositorios** (interfaces) definidos aquí, que se implementan en Infrastructure.

3. **PokeApi.Infrastructure**  
   - Maneja la persistencia de datos con **Entity Framework Core** y **SQL Server**.
   - Implementa las **interfaces de repositorio** con EF Core.
   - Define el **`ApplicationDbContext`** (hereda de `IdentityDbContext` para manejar usuarios, roles, etc.).

4. **PokeApi.Web**  
   - Contiene los **controladores** (`AuthController`, `PokedexController`, `TeamsController`) y la configuración (Identity, JWT, Swagger, NLog, etc.).
   - Es el **proyecto de arranque** (startup) que se ejecuta y expone la API.

## Características Principales

- **Autenticación y Autorización**  
  - .NET Identity + JWT tokens.  
  - Endpoints públicos y privados para usuarios registrados.
  
- **CRUD de Pokémon (Público)**  
  - Lectura de información de la primera generación de Pokemon (nombre, tipos, stats, etc.).

- **Gestión de Equipos (Privado)**
  - Crear equipos (máximo 6 Pokémon).  
  - Editar y eliminar equipos.  
  - Cada equipo se asocia al `UserId` del usuario logueado.

- **Logging**  
  - Integrado con NLog para el registro de información de la aplicación.

- **Estructura de Capas (Clean Architecture)**  
  - Separación de responsabilidades y desacoplamiento entre la lógica de negocio, la infraestructura y la capa de presentación.

- **Swagger**  
  - Documentación y pruebas de la API en tiempo real.

---

## Tecnologías Utilizadas

- **.NET 8 **
- **ASP.NET Core** (Web API)
- **Entity Framework Core** (SQL Server)
- **ASP.NET Identity** (gestión de usuarios/roles, con JWT)
- **NLog** (logging)
- **Swashbuckle (Swagger)** (documentación)
- **Docker** (contenedorización de SQL Server, y de la API)
- **Azure** (despliegue)

---

## Endpoints Principales

| Endpoint                | Método  | Descripción                                                   | Autenticación |
|-------------------------|---------|---------------------------------------------------------------|---------------|
| **Auth**                                                                                           |
| `/api/Auth/register`    | **POST** | Registra un nuevo usuario y devuelve un token JWT si se desea | Ninguna       |
| `/api/Auth/login`       | **POST** | Inicia sesión con credenciales y devuelve un token JWT        | Ninguna       |
| **Pokedex**                                                                                         |
| `/api/Pokedex`          | **GET**  | Retorna la lista completa de Pokémon de la primera generación | Ninguna       |
| `/api/Pokedex/{id}`     | **GET**  | Retorna información de un Pokémon específico por su ID        | Ninguna       |
| `/api/Pokedex`          | **POST** | Crea un nuevo Pokémon                                         | JWT (Obligatorio) |
| `/api/Pokedex/{id}`     | **PUT**  | Actualiza datos de un Pokémon existente                       | JWT (Obligatorio) |
| `/api/Pokedex/{id}`     | **DELETE** | Elimina un Pokémon de la base de datos                     | JWT (Obligatorio) |
| **Equipos (Teams)**                                                                                 |
| `/api/Teams`            | **GET**  | Lista todos los equipos pertenecientes al usuario autenticado | JWT (Obligatorio) |
| `/api/Teams`            | **POST** | Crea un nuevo equipo (hasta 6 Pokémon) asociado al usuario    | JWT (Obligatorio) |
| `/api/Teams/{id}`       | **PUT**  | Actualiza el equipo (cambiar miembros, etc.)                  | JWT (Obligatorio) |
| `/api/Teams/{id}`       | **DELETE** | Elimina un equipo por su ID                                 | JWT (Obligatorio) |

---

## Créditos y Licencia

- Proyecto desarrollado por **Diego Rodriguez Barcala**
- **Pokémon © 1995–2023 Nintendo/Creatures Inc./GAME FREAK inc.**  
- Datos de Pokémon basados en material público.
- Licencia del código: [MIT License](LICENSE)
