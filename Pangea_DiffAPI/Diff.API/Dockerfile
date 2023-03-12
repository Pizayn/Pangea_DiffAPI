#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Diff.API/Diff.API.csproj", "Diff.API/"]
COPY ["Diff.Application/Diff.Application.csproj", "Diff.Application/"]
COPY ["Diff.Domain/Diff.Domain.csproj", "Diff.Domain/"]
COPY ["Diff.Infastructure/Diff.Infastructure.csproj", "Diff.Infastructure/"]
RUN dotnet restore "Diff.API/Diff.API.csproj"
COPY . .
WORKDIR "/src/Diff.API"
RUN dotnet build "Diff.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diff.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diff.API.dll"]