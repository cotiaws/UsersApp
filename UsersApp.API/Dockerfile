# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UsersApp.API/UsersApp.API.csproj", "UsersApp.API/"]
COPY ["UsersApp.Application/UsersApp.Application.csproj", "UsersApp.Application/"]
COPY ["UsersApp.Domain/UsersApp.Domain.csproj", "UsersApp.Domain/"]
COPY ["UsersApp.Infra.Data.MongoDB/UsersApp.Infra.Data.MongoDB.csproj", "UsersApp.Infra.Data.MongoDB/"]
COPY ["UsersApp.Infra.Data.SqlServer/UsersApp.Infra.Data.SqlServer.csproj", "UsersApp.Infra.Data.SqlServer/"]
COPY ["UsersApp.Infra.Security/UsersApp.Infra.Security.csproj", "UsersApp.Infra.Security/"]
RUN dotnet restore "./UsersApp.API/UsersApp.API.csproj"
COPY . .
WORKDIR "/src/UsersApp.API"
RUN dotnet build "./UsersApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UsersApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV DOTNET_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "UsersApp.API.dll"]