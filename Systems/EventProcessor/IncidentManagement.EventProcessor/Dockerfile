#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/EventProcessor/IncidentManagement.EventProcessor/IncidentManagement.EventProcessor.csproj", "Systems/EventProcessor/IncidentManagement.EventProcessor/"]
COPY ["Data/IncidentManagement.Context/IncidentManagement.Context.csproj", "Data/IncidentManagement.Context/"]
COPY ["Shared/IncidentManagement.Common/IncidentManagement.Common.csproj", "Shared/IncidentManagement.Common/"]
COPY ["Data/IncidentManagement.Context.Entities/IncidentManagement.Context.Entities.csproj", "Data/IncidentManagement.Context.Entities/"]
COPY ["Data/Migrations/IncidentManagement.Context.MigrationsPostgreSQL/IncidentManagement.Context.MigrationsPostgreSQL.csproj", "Data/Migrations/IncidentManagement.Context.MigrationsPostgreSQL/"]
RUN dotnet restore "Systems/EventProcessor/IncidentManagement.EventProcessor/IncidentManagement.EventProcessor.csproj"
COPY . .
WORKDIR "/src/Systems/EventProcessor/IncidentManagement.EventProcessor"
RUN dotnet build "IncidentManagement.EventProcessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IncidentManagement.EventProcessor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentManagement.EventProcessor.dll"]