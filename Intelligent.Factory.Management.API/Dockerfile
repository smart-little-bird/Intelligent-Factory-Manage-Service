FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Intelligent.Factory.Management.API/Intelligent.Factory.Management.API.csproj", "Intelligent.Factory.Management.API/"]
RUN dotnet restore "Intelligent.Factory.Management.API/Intelligent.Factory.Management.API.csproj"
COPY . .
WORKDIR "/src/Intelligent.Factory.Management.API"
RUN dotnet build "Intelligent.Factory.Management.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Intelligent.Factory.Management.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Intelligent.Factory.Management.API.dll"]
