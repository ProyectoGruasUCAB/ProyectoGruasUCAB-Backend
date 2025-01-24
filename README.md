# ProyectoGruasUCAB-Backend
Backend repository in the ProyectoGruasUCAB project


## Descripción

GruasUCAB es un proyecto de la asignatura **Desarrollo de Software** cuyo desarrollo se debe realizar haciendo uso de:
- Enfoque a microservicios
- .NET Core 8
- Arquitectura Hexagonal
- CQRS + Mediator
- Google API
- Postgres
- Firebase
- Keycloak
- React + React Native
- Yarp
- Docker para la virtualización de Keycloak


### Integrantes:
- **Oriana Zorrilla**
- **Renato Torella**
- **Marco Agrusa**

---

## Pre-requisitos

### Clonar el repositorio:

```
git clone <URL_DEL_REPOSITORIO>
```

Crear el archivo .appsettings.Development.json

A continuación, copia y pega este contenido para crear tu archivo .appsettings.Development.json . Esto es importante, para garantizar el funcionamiento del backend. A continuación se muestra un ejemplo:

```
{
  "EmailSettings": {
    "FromDisplayName": "Grúas UCAB",
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SmtpUsername": "your-email@gmail.com",
    "SmtpPassword": "your-password",
    "FromEmail": "your-email@gmail.com"
  }
}
```
¿Cómo ejecutar el proyecto?


Ejecuta Docker Compose:

Para construir y ejecutar los contenedores, usa el siguiente comando (con el flag -d si deseas ejecutarlo en segundo plano):

```
docker-compose up --build -d
```
Acceso a la aplicación:

Una vez que los contenedores están corriendo, keycloak estará disponible en:


http://localhost:8180

Luego debes ejecutar el siguiente comando desde ProyectoGruasUCAB-Backend ❯ API-GruasUCAB-main ❯ API-GruasUCAB:


```
dotnet clean
```

```
dotnet build
```
Ahora para realizar las migraciones a la base de datos, ingrese a su aplicación de PostgreSQL y mantenla abierta. Ejecute los siguientes comandos desde ProyectoGruasUCAB-Backend ❯:

```
dotnet tool install --global dotnet-ef 
```   
```
dotnet ef migrations add InitialCreate -p API-GruasUCAB-main/API-GruasUCAB.Auth -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef migrations add InitialCreate -p API-GruasUCAB-main/API-GruasUCAB.Supplier -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef migrations add InitialCreate -p API-GruasUCAB-main/API-GruasUCAB.Department -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef migrations add InitialCreate -p API-GruasUCAB-main/API-GruasUCAB.Users -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef migrations add InitialCreate -p API-GruasUCAB-main/API-GruasUCAB.Policy -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef migrations add InitialCreate -p API-GruasUCAB-main/API-GruasUCAB.ServiceOrder -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef migrations add InitialCreate -p API-GruasUCAB-main/API-GruasUCAB.Vehicle -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef migrations add InitialCreate -p API-GruasUCAB-main/API-GruasUCAB.ServiceFee -s API-GruasUCAB-main/API-GruasUCAB
```
    
```
dotnet ef database update -p API-GruasUCAB-main/API-GruasUCAB.Auth -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef database update -p API-GruasUCAB-main/API-GruasUCAB.Supplier -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef database update -p API-GruasUCAB-main/API-GruasUCAB.Department -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef database update -p API-GruasUCAB-main/API-GruasUCAB.ServiceFee -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef database update -p API-GruasUCAB-main/API-GruasUCAB.ServiceOrder -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef database update -p API-GruasUCAB-main/API-GruasUCAB.Vehicle -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef database update -p API-GruasUCAB-main/API-GruasUCAB.Policy -s API-GruasUCAB-main/API-GruasUCAB &&
dotnet ef database update -p API-GruasUCAB-main/API-GruasUCAB.Users -s API-GruasUCAB-main/API-GruasUCAB
```

Ahora, para correr el backend del proyecto ejecute el siguiente comando desde ProyectoGruasUCAB-Backend ❯ API-GruasUCAB-main ❯ API-GruasUCAB:
 
```
dotnet run
```

Si deseas verificar que todo está funcionando correctamente, puedes acceder al siguiente enlace:


http://localhost:5144
