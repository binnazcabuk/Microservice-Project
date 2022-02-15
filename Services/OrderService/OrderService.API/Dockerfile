FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Shared/*.csproj Shared/Shared/

COPY Services/OrderService/OrderService.Application/*.csproj Services/OrderService/OrderService.Application/

COPY Services/OrderService/OrderService.Domain/*.csproj Services/OrderService/OrderService.Domain/

COPY Services/OrderService/OrderService.Domain.Core/*.csproj Services/OrderService/OrderService.Domain.Core/

COPY Services/OrderService/OrderService.Infastucture/*.csproj Services/OrderService/OrderService.Infrastructure/

COPY Services/OrderService/OrderService.API/*.csproj Services/OrderService/OrderService.API/
RUN dotnet restore Services/OrderService/OrderService.API/*.csproj
COPY . .
RUN dotnet publish Services/OrderService/OrderService.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","OrderService.API.dll" ]