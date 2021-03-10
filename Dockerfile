# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY AspNetService/*.csproj ./AspNetService/
RUN dotnet restore --verbosity detailed

# copy everything else and build app
COPY AspNetService/. ./AspNetService/
WORKDIR /source/AspNetService
RUN dotnet publish -c Release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "AspNetService.dll"]