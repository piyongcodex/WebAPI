FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://0.0.0.0:5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["CQRSpattern/CQRSpattern.API.csproj","CQRSpattern/"]
COPY ["CQRSpattern.Application/CQRSpattern.Application.csproj","CQRSpattern.Application/"]
COPY ["CQRSpattern.Domain/CQRSpattern.Domain.csproj","CQRSpattern.Domain/"]
COPY ["CQRSpattern.Infrastructure/CQRSpattern.Infrastructure.csproj","CQRSpattern.Infrastructure/"]
COPY ["CQRSpattern.Presentation/CQRSpattern.Presentation.csproj","CQRSpattern.Presentation/"]
RUN dotnet restore "CQRSpattern/CQRSpattern.API.csproj"
COPY . .
WORKDIR "/src/CQRSpattern"
RUN dotnet build "CQRSpattern.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "CQRSpattern.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRSpattern.API.dll"]