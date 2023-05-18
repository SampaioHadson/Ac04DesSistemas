#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DesSistemas.SnackNow.Api/DesSistemas.SnackNow.Api.csproj", "DesSistemas.SnackNow.Api/"]
RUN dotnet restore "DesSistemas.SnackNow.Api/DesSistemas.SnackNow.Api.csproj"
COPY . .
WORKDIR "/src/DesSistemas.SnackNow.Api"
RUN dotnet build "DesSistemas.SnackNow.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesSistemas.SnackNow.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesSistemas.SnackNow.Api.dll"]