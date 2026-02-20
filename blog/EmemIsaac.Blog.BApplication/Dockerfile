FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["blog/EmemIsaac.Blog.BApplication/EmemIsaac.Blog.BApplication.csproj", "blog/EmemIsaac.Blog.BApplication/"]
COPY ["blog/EmemIsaac.Blog.Shared/EmemIsaac.Blog.Shared.csproj", "blog/EmemIsaac.Blog.Shared/"]
RUN dotnet restore "./blog/EmemIsaac.Blog.BApplication/./EmemIsaac.Blog.BApplication.csproj"
COPY . .
WORKDIR "/src/blog/EmemIsaac.Blog.BApplication"
RUN dotnet build "./EmemIsaac.Blog.BApplication.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EmemIsaac.Blog.BApplication.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM nginx:1-alpine-slim AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ["blog/EmemIsaac.Blog.BApplication/nginx.conf", "/etc/nginx/nginx.conf"]
# RUN apt-get update && apt-get install ca-certificates -y && update-ca-certificates && apt-get install curl -y
