FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Derleme ve yayınlama aşaması
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SiteManagement.Api/SiteManagement.Api.csproj", "SiteManagement.Api/"]
COPY ["SiteManagement.Business/SiteManagement.Business.csproj", "SiteManagement.Business/"]
COPY ["SiteManagement.Core/SiteManagement.Core.csproj", "SiteManagement.Core/"]
COPY ["SiteManagement.Data/SiteManagement.Data.csproj", "SiteManagement.Data/"]
RUN dotnet restore "SiteManagement.Api/SiteManagement.Api.csproj"
COPY . .
WORKDIR "/src/SiteManagement.Api"
RUN dotnet build "SiteManagement.Api.csproj" -c Release -o /app/build

# Yayın aşaması
FROM build AS publish
RUN dotnet publish "SiteManagement.Api.csproj" -c Release -o /app/publish

# Üretim aşaması
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SiteManagement.Api.dll"]
