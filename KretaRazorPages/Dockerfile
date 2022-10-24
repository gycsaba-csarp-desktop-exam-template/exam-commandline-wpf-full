# Kreta Razor oldal docker f�jl
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KretaRazorPages/KretaRazorPages.csproj", "KretaRazorPages/"]
COPY ["ApplicationProperties/ApplicationPropertiesSettings.csproj", "ApplicationProperties/"]
COPY ["KretaParancssoriAlkalmazas/KretaParancssoriAlkalmazas.csproj", "KretaParancssoriAlkalmazas/"]
COPY ["ServiceKretaLogger/ServiceKretaLogger.csproj", "ServiceKretaLogger/"]
COPY ["StaticClasses/StaticClasses.csproj", "StaticClasses/"]
COPY ["ServiceKretaAPI/ServiceKretaAPI.csproj", "ServiceKretaAPI/"]
RUN dotnet restore "KretaRazorPages/KretaRazorPages.csproj"
COPY . .
WORKDIR "/src/KretaRazorPages"
RUN dotnet build "KretaRazorPages.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KretaRazorPages.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/build .
EXPOSE 80
# ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "KretaRazorPages.dll"]