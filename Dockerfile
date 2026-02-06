# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Create a writable directory for the database
RUN mkdir -p /app/data
# Set permission for the database file/folder if needed (optional but good practice)
# ENV connection string will point to this location
# But since we use relative path "Data Source=lab6.db" in appsettings, 
# and WORKDIR is /app, the db will be at /app/lab6.db
# To persist data, Render requires a stronger database (Postgres), but for SQLite on free tier:
# The DB will be lost on restart. Ideally, use a volume or external DB.
# For this lab, ephemeral is fine.

ENTRYPOINT ["dotnet", "Lab6.dll"]
