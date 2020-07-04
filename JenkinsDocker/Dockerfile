FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
# copy csproj and restore as distinct layers
COPY *.sln .
COPY JenkinsDockerWeb/*.csproj ./JenkinsDockerWeb/
RUN dotnet restore

# copy everything else and build app
COPY JenkinsDockerWeb/. ./JenkinsDockerWeb/
WORKDIR /app/JenkinsDockerWeb
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime
WORKDIR /app
COPY --from=build /app/JenkinsDockerWeb/out ./
ENTRYPOINT ["dotnet", "JenkinsDockerWeb.dll"]