# Use a imagem base do SDK para compilar e publicar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ../Api/Api.csproj ./Api/
COPY ../Services/Services.csproj ./Services/
COPY ../Infra/Infra.csproj ./Infra/
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Api/Api.csproj" -c Release -o /app/build
RUN dotnet publish "Api/Api.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Api.dll"]






## Use a imagem base do SDK para compilar e publicar a aplicação
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#EXPOSE 8080
#
## Etapa de build
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#
## Copiar os arquivos de projeto com base na estrutura das pastas
#COPY ./Api.csproj ./Api/
#COPY ../Services/Services.csproj ./Services/
#COPY ../Infra/Infra.csproj ./Infra/
#
## Restaurar dependências
#RUN dotnet restore "Api/Api.csproj"
#
## Copiar o restante dos arquivos
#COPY . .
#
## Build do projeto
#WORKDIR "/src/"
#RUN dotnet build "Api/Api.csproj" -c Release -o /app/build
#
## Publicar a aplicação
#RUN dotnet publish "Api/Api.csproj" -c Release -o /app/publish
#
## Etapa de runtime
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
#WORKDIR /app
#COPY --from=build /app/publish .
#EXPOSE 8080
#ENTRYPOINT ["dotnet", "Api.dll"]
#
