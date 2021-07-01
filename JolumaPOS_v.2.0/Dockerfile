#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JolumaPOS_v.2.0/JolumaPOS_v.2.0.csproj", "JolumaPOS_v.2.0/"]
RUN dotnet restore "JolumaPOS_v.2.0/JolumaPOS_v.2.0.csproj"
COPY . .
WORKDIR "/src/JolumaPOS_v.2.0"
RUN dotnet build "JolumaPOS_v.2.0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JolumaPOS_v.2.0.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JolumaPOS_v.2.0.dll"]