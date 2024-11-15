# Usa la imagen base de .NET ASP.NET Core para Windows Server
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8081

# Usa la imagen SDK de .NET para compilar y publicar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
WORKDIR /src
COPY ["MutantAPI/MutantAPI.csproj", "MutantAPI/"]
COPY ["MutantLibrary/MutantDetection.csproj", "MutantLibrary/"]
RUN dotnet restore "./MutantAPI/MutantAPI.csproj"
COPY . .
WORKDIR "/src/MutantAPI"
RUN dotnet build "./MutantAPI.csproj" -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "./MutantAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final: usar la imagen base y copiar los archivos publicados
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MutantAPI.dll"]
