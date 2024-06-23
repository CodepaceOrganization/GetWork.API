FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CodePace.GetWork.API/CodePace.GetWork.API.csproj", "CodePace.GetWork.API/"]
RUN dotnet restore "CodePace.GetWork.API/CodePace.GetWork.API.csproj"
COPY . .
WORKDIR "/src/CodePace.GetWork.API"
RUN dotnet build "CodePace.GetWork.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CodePace.GetWork.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodePace.GetWork.API.dll"]
