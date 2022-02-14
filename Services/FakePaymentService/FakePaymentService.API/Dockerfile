FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Shared/*.csproj Shared/Shared/
COPY Services/FakePaymentService/FakePaymentService.API/*.csproj Services/FakePaymentService/FakePaymentService.API/
RUN dotnet restore Services/FakePaymentService/FakePaymentService.API/*.csproj
COPY . .
RUN dotnet publish Services/FakePaymentService/FakePaymentService.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FakePaymentService.API.dll" ]