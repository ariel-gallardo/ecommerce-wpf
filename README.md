# Ecommerce

Proyecto Ecommerce desarrollado con .NET 6 y WPF, siguiendo una arquitectura modular con capas separadas.

## Estructura del proyecto

- **Ecommerce.Application**: Contiene la lógica de negocio y servicios.
- **Ecommerce.Common**: Clases comunes y DTOs compartidos.
- **Ecommerce.Presentation**: Aplicación WPF, configuración de servicios y vistas principales.
- **Ecommerce.Views**: Controles de usuario (User Controls) para la interfaz.
- **Ecommerce.ViewModels**: ViewModels para la vinculación de datos en MVVM.

## Tecnologías

- .NET 6
- WPF
- AutoMapper
- Microsoft.Extensions.DependencyInjection
- JWT para autenticación

## Características

- Autenticación con JWT y manejo de cookies HTTP.
- Inyección de dependencias configurada con extensiones.
- Arquitectura MVVM para separación de responsabilidades.
- Servicios HTTP genéricos para consumo de APIs REST.

## Cómo ejecutar

1. Clonar el repositorio.
2. Abrir la solución `Ecommerce.sln` en Visual Studio 2022 o superior.
3. Restaurar paquetes NuGet.
4. Compilar y ejecutar el proyecto `Ecommerce.Presentation`.
