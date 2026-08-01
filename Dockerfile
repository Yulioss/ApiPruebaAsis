FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copiar archivos de proyecto
COPY ApiPruebaAsis/ApiPruebaAsis.csproj ApiPruebaAsis/
COPY ApiPruebaAsis.Application/ApiPruebaAsis.Application.csproj ApiPruebaAsis.Application/
COPY ApiPruebaAsis.Domain/ApiPruebaAsis.Domain.csproj ApiPruebaAsis.Domain/
COPY ApiPruebaAsis.Infrastructure/ApiPruebaAsis.Infrastructure.csproj ApiPruebaAsis.Infrastructure/

# Restaurar dependencias
RUN dotnet restore ApiPruebaAsis/ApiPruebaAsis.csproj

# Copiar el resto del código
COPY . .

# Publicar
RUN dotnet publish ApiPruebaAsis/ApiPruebaAsis.csproj -c Release -o /app/publish

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "ApiPruebaAsis.dll"]