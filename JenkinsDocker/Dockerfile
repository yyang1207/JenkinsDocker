FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app
EXPOSE 5001
EXPOSE 5002
# copy csproj and restore as distinct layers
COPY *.sln .
COPY JenkinsDockerWeb/*.csproj ./JenkinsDockerWeb/
RUN dotnet restore

# copy everything else and build app
COPY JenkinsDockerWeb/. ./JenkinsDockerWeb/
WORKDIR /app/JenkinsDockerWeb
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/JenkinsDockerWeb/out ./
ENTRYPOINT ["dotnet", "JenkinsDockerWeb.dll"]