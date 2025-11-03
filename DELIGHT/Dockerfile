# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar los proyectos
COPY ["DELIGHT/DELIGHT.Presentation.Api.csproj", "."]
COPY ["DELIGHT.Core.Application/DELIGHT.Core.Application.csproj", "DELIGHT.Core.Application/"]
COPY ["DELIGHT.Core.Domain/DELIGHT.Core.Domain.csproj", "DELIGHT.Core.Domain/"]
COPY ["DELIGHT.Infrastructure.Persistence/DELIGHT.Infrastructure.Persistence.csproj", "DELIGHT.Infrastructure.Persistence/"]

# Restaurar dependencias
RUN dotnet restore "DELIGHT.Presentation.Api.csproj"

# Copiar todo el código
COPY . .

WORKDIR "/src/DELIGHT"
RUN dotnet build "DELIGHT.Presentation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar la aplicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DELIGHT.Presentation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DELIGHT.Presentation.Api.dll"]
