# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory
WORKDIR /app

# Expose ports
EXPOSE 8080
EXPOSE 8081

# Use SDK image to build the application
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define arguments
ARG TARGETARCH
ARG TARGETOS
ARG BUILDPLATFORM
ARG BUILD_CONFIGURATION=Release

# Set the architecture environment variable
RUN arch=$TARGETARCH \
    && if [ "$arch" = "amd64" ]; then arch="x64"; fi \
    && echo $TARGETOS-$arch > /tmp/rid 

# Set the working directory
WORKDIR /src

# Copy csproj files and restore as distinct layers
COPY ["HRM.Application/HRM.Application.csproj", "HRM.Application/"]
COPY ["HRM.Domain/HRM.Domain.csproj", "HRM.Domain/"]
COPY ["HRM.Infrastructure/HRM.Infrastructure.csproj", "HRM.Infrastructure/"]
COPY ["HRM.WebAPI/HRM.WebAPI.csproj", "HRM.WebAPI/"]

# Restore the project
RUN dotnet restore "HRM.WebAPI/HRM.WebAPI.csproj" -r $(cat /tmp/rid)

# Copy everything else and build
COPY . .
WORKDIR "/src/HRM.WebAPI"
RUN dotnet build "HRM.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build -r $(cat /tmp/rid)

# Publish the application
FROM build AS publish
RUN dotnet publish "HRM.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false -r $(cat /tmp/rid)

# Final stage / image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRM.WebAPI.dll"]
