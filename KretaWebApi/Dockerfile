#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KretaWebApi/KretaWebApi.csproj", "KretaWebApi/"]
COPY ["KretaParancssoriAlkalmazas/KretaParancssoriAlkalmazas.csproj", "KretaParancssoriAlkalmazas/"]
COPY ["ApplicationProperties/ApplicationPropertiesSettings.csproj", "ApplicationProperties/"]
COPY ["StaticClasses/StaticClasses.csproj", "StaticClasses/"]
COPY ["ServiceKretaLogger/ServiceKretaLogger.csproj", "ServiceKretaLogger/"]
COPY ["ServiceKretaAPI/ServiceKretaAPI.csproj", "ServiceKretaAPI/"]
RUN dotnet restore "KretaWebApi/KretaWebApi.csproj"
COPY . .
WORKDIR "/src/KretaWebApi"
RUN dotnet build "KretaWebApi.csproj" -c Release -o /app/build

FROM build AS publishd
RUN dotnet publish "KretaWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# flyctl
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
# flyctl
ENTRYPOINT ["dotnet", "KretaWebApi.dll"]