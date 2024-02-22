# Use the official .NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Expose the port that the application will run on
EXPOSE 5000

# Copy the published output of your .NET Core web application into the container
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "./WebApi/WebApi.csproj"]
RUN dotnet restore "/src/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "/src/WebApi/WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/WebApi/WebApi.csproj" -c Release -o /app/publish

# Use the base image and copy the published files
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "WebApi.dll"]
