FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY GatewayAPI/Gateway.API/*.csproj GatewayAPI/Gateway.API/
RUN dotnet restore GatewayAPI/Gateway.API/*.csproj
COPY . .
RUN dotnet publish GatewayAPI/Gateway.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Gateway.API.dll" ]