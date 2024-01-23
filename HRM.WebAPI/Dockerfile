FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HRM.Application/HRM.Application.csproj", "HRM.Application/"]
COPY ["HRM.Domain/HRM.Domain.csproj", "HRM.Domain/"]
COPY ["HRM.Infrastructure/HRM.Infrastructure.csproj", "HRM.Infrastructure/"]
COPY ["HRM.WebAPI/HRM.WebAPI.csproj", "HRM.WebAPI/"]
RUN dotnet restore "HRM.WebAPI/HRM.WebAPI.csproj"
COPY . .
WORKDIR "/src/HRM.WebAPI"
RUN dotnet build "HRM.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HRM.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRM.WebAPI.dll"]
