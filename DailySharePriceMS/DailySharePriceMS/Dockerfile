#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DailySharePriceMS/DailySharePriceMS.csproj", "DailySharePriceMS/"]
RUN dotnet restore "DailySharePriceMS/DailySharePriceMS.csproj"
COPY . .
WORKDIR "/src/DailySharePriceMS"
RUN dotnet build "DailySharePriceMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DailySharePriceMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DailySharePriceMS.dll"]