#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/EventGenerator/IncidentManagement.EventGenerator/IncidentManagement.EventGenerator.csproj", "Systems/EventGenerator/IncidentManagement.EventGenerator/"]
COPY ["Services/IncidentManagement.Services.Events/IncidentManagement.Services.Events.csproj", "Services/IncidentManagement.Services.Events/"]
COPY ["Data/IncidentManagement.Context.Entities/IncidentManagement.Context.Entities.csproj", "Data/IncidentManagement.Context.Entities/"]
COPY ["Shared/IncidentManagement.Common/IncidentManagement.Common.csproj", "Shared/IncidentManagement.Common/"]
RUN dotnet restore "Systems/EventGenerator/IncidentManagement.EventGenerator/IncidentManagement.EventGenerator.csproj"
COPY . .
WORKDIR "/src/Systems/EventGenerator/IncidentManagement.EventGenerator"
RUN dotnet build "IncidentManagement.EventGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IncidentManagement.EventGenerator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentManagement.EventGenerator.dll"]