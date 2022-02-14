FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Shared/*.csproj Shared/Shared/
COPY Services/BasketService/BasketService.API/*.csproj Services/BasketService/BasketService.API/
RUN dotnet restore Services/BasketService/BasketService.API/*.csproj
COPY . .
RUN dotnet publish Services/BasketService/BasketService.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","BasketService.API.dll" ]