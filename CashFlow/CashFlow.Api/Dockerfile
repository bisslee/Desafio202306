#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CashFlow.Api/CashFlow.Api.csproj", "CashFlow.Api/"]
RUN dotnet restore "CashFlow.Api/CashFlow.Api.csproj"
COPY . .
WORKDIR "/src/CashFlow.Api"
RUN dotnet build "CashFlow.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CashFlow.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]