#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["01 - Presentation/Auth.Config.Api/Auth.Config.Api.csproj", "01 - Presentation/Auth.Config.Api/"]
RUN dotnet restore "01 - Presentation/Auth.Config.Api/Auth.Config.Api.csproj"
COPY . .
WORKDIR "/src/01 - Presentation/Auth.Config.Api"
RUN dotnet build "Auth.Config.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Auth.Config.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.Config.Api.dll"]