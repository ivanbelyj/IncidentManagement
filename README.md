# IncidentManagement
Test task for the Junior .NET Developer position. This project includes EventGenerator background service, EventProcessor (both with REST api supporting Swagger), docker orchestration (docker-compose), EF Core Code First, settings (with appsettings.json for running services without docker or docker env files used by containers), services health checks, and some other features.

# Build and setup
To build the project, use docker-compose
```
docker-compose build
docker-compose up
```
# Demo
After running the containers you can access generator and processor Swagger UI by http://localhost:10001/api/index.html and http://localhost:10000/api/index.html respectively.
You can also stop service container and run the service in Visual Studio (consider that appsettings.json settings will be used).
