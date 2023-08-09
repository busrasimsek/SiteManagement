# .NET Core SDK'nın kullanılacağı taban imajı
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Projeyi Docker içinde derleme
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# Çalıştırılabilir imaj oluşturma
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Uygulama başlatma komutu
ENTRYPOINT ["dotnet", "SiteManagement.dll"]