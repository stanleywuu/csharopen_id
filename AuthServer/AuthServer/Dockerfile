# Use the official .NET runtime image as a base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the AuthServer project file into the container
COPY AuthServer.csproj ./AuthServer.csproj

# Restore the dependencies for the AuthServer project
RUN dotnet restore ./AuthServer.csproj

# Copy the rest of the application code into the container
# This copies all files from the current directory to the container
COPY . .  

# Build the application
RUN dotnet build ./AuthServer.csproj -c $BUILD_CONFIGURATION -o /app/build

# Publish the app into the /app/publish directory
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish ./AuthServer.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: Use the runtime image to serve the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthServer.dll"]
