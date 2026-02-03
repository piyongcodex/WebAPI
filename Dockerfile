FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . ./

# Restore the main Presentation project (it will restore dependencies)
RUN dotnet restore CQRSpattern/CQRSpattern.Presentation/CQRSpattern.Presentation.csproj

# Build and publish
RUN dotnet publish CQRSpattern/CQRSpattern.Presentation/CQRSpattern.Presentation.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "CQRSpattern.Presentation.dll"]