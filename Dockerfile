FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all project files
COPY ["CQRSpattern/CQRSpattern.API.csproj", "CQRSpattern/"]
COPY ["CQRSpattern.Application/CQRSpattern.Application.csproj", "CQRSpattern.Application/"]
COPY ["CQRSpattern.Domain/CQRSpattern.Domain.csproj", "CQRSpattern.Domain/"]
COPY ["CQRSpattern.Infrastructure/CQRSpattern.Infrastructure.csproj", "CQRSpattern.Infrastructure/"]
COPY ["CQRSpattern.Presentation/CQRSpattern.Presentation.csproj", "CQRSpattern.Presentation/"]

# Restore dependencies
RUN dotnet restore "CQRSpattern/CQRSpattern.API.csproj"

# Copy source code for each project (avoiding .vs folder)
COPY CQRSpattern/ CQRSpattern/
COPY CQRSpattern.Application/ CQRSpattern.Application/
COPY CQRSpattern.Domain/ CQRSpattern.Domain/
COPY CQRSpattern.Infrastructure/ CQRSpattern.Infrastructure/
COPY CQRSpattern.Presentation/ CQRSpattern.Presentation/

# Build
WORKDIR "/src/CQRSpattern"
RUN dotnet build "CQRSpattern.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRSpattern.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRSpattern.API.dll"]