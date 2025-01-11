FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CriptoBull.Api/CriptoBull.Api.csproj", "CriptoBull.Api/"]
COPY ["CriptoBull.Application/CriptoBull.Application.csproj", "CriptoBull.Application/"]
COPY ["CriptoBull.Domain/CriptoBull.Domain.csproj", "CriptoBull.Domain/"]
COPY ["CriptoBull.IoC/CriptoBull.IoC.csproj", "CriptoBull.IoC/"]
COPY ["CriptoBull.Integrations/CriptoBull.Integrations.csproj", "CriptoBull.Integrations/"]
RUN dotnet restore "CriptoBull.Api/CriptoBull.Api.csproj"
COPY . .
WORKDIR "/src/CriptoBull.Api"
RUN dotnet build "CriptoBull.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CriptoBull.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CriptoBull.Api.dll"]
