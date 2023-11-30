# IncidentManagement

Test task for the Junior .NET Developer position. This project includes EventGenerator background service, EventProcessor (both have REST api supporting Swagger), docker orchestration (docker-compose), EF Core Code First, PostgreSQL, settings (using appsettings.json when running services without docker or using docker env files for containers), services health checks, and some other features.

# Build and run

To build and run the project, use docker-compose

```
docker-compose build
docker-compose up
```

After the EventProcessor is started, the database IncidentManagement will be created to store added incidents and related events.

# Demo

After running the containers you can access generator and processor Swagger UI by http://localhost:10001/api/index.html and http://localhost:10000/api/index.html respectively. You can also stop docker container and run the service in Visual Studio (consider that appsettings.json settings will be used).
