# Tienda.
El presente proyecto es una tienda donde se pueden consultar productos y crear ordenes.

## Arquitectura del proyecto.
### Backend.
Esta divido en varios proyectos:
- Store.Domain: Aquí se encuentran las entidades que se mapean de la base de datos y los puertos que contienen las interfaces de los repositorios.
- Store.Infrastructure: Configuración y conexión con la base de datos.
- Store.Application: interfaces, servicios y DTO's con la logica del negocio.
- Store.Api: Controladores, es el punto de entrada del proyecto.

## Tecnologías utilizadas.
- Base de datos: SQL Server.
- Backend: .NET 9
- Peticiones: Postman.

## Iniciar el proyecto.
- Ejecutar el archivo `script.sql` ubicado en la carpeta `Database` del proyecto Library.Infrastructure en una isntancia de SQL Server.
- Configurar la cadena de conexión en los secretos de usuario, puede tomar de referencia la estructura agregada en el `appsettings.json` del proyecto Store.Api.
