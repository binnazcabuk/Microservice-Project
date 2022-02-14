FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Shared/*.csproj Shared/Shared/
COPY Services/CatalogService/Catalog.Service.API/*.csproj Services/CatalogService/Catalog.Service.API/
RUN dotnet restore Services/CatalogService/Catalog.Service.API/*.csproj
COPY . .
RUN dotnet publish Services/CatalogService/Catalog.Service.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Catalog.Service.API.dll" ]