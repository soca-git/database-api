#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Database/Database.csproj", "src/Database/"]
COPY ["src/Database.Core/Database.Core.csproj", "src/Database.Core/"]
COPY ["src/Database.Controllers/Database.Controllers.csproj", "src/Database.Controllers/"]
RUN dotnet restore "src/Database/Database.csproj"
COPY . .
WORKDIR "/src/src/Database"
RUN dotnet build "Database.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Database.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Database.dll