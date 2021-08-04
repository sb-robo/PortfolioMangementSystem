#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CalculateNetworthMS/CalculateNetworthMS.csproj", "CalculateNetworthMS/"]
RUN dotnet restore "CalculateNetworthMS/CalculateNetworthMS.csproj"
COPY . .
WORKDIR "/src/CalculateNetworthMS"
RUN dotnet build "CalculateNetworthMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculateNetworthMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculateNetworthMS.dll"]