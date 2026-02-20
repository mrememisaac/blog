#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EmemIsaac.Identity/EmemIsaac.Identity.csproj", "EmemIsaac.Identity/"]
RUN dotnet restore "./EmemIsaac.Identity/./EmemIsaac.Identity.csproj"
COPY . .
WORKDIR "/src/EmemIsaac.Identity"
RUN dotnet build "./EmemIsaac.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EmemIsaac.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt-get update && apt-get install ca-certificates -y && update-ca-certificates && apt-get install curl -y
ENTRYPOINT ["dotnet", "EmemIsaac.Identity.dll"]