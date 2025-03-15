FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5286

ENV ASPNETCORE_URLS=http://+:5286

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["countries.api/countries.api.csproj", "countries.api/"]
RUN dotnet restore "countries.api/countries.api.csproj"
COPY . .
WORKDIR "/src/countries.api"
RUN dotnet build "countries.api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "countries.api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "countries.api.dll"]
