#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["blog/EmemIsaac.Blog.Api/EmemIsaac.Blog.Api.csproj", "blog/EmemIsaac.Blog.Api/"]
COPY ["blog/EmemIsaac.Blog.Application/EmemIsaac.Blog.Application.csproj", "blog/EmemIsaac.Blog.Application/"]
COPY ["blog/EmemIsaac.Blog.Domain/EmemIsaac.Blog.Domain.csproj", "blog/EmemIsaac.Blog.Domain/"]
COPY ["blog/EmemIsaac.Blog.Persistence/EmemIsaac.Blog.Persistence.csproj", "blog/EmemIsaac.Blog.Persistence/"]
RUN dotnet restore "./blog/EmemIsaac.Blog.Api/./EmemIsaac.Blog.Api.csproj"
COPY . .
WORKDIR "/src/blog/EmemIsaac.Blog.Api"
RUN dotnet build "./EmemIsaac.Blog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EmemIsaac.Blog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apt-get update && apt-get install ca-certificates -y && update-ca-certificates && apt-get install curl -y
ENTRYPOINT ["dotnet", "EmemIsaac.Blog.Api.dll"]