FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ORM_Fun/ORM_Fun.csproj", "ORM_Fun/"]
RUN dotnet restore "ORM_Fun/ORM_Fun.csproj"
COPY . .
WORKDIR "/src/ORM_Fun"
RUN dotnet build "ORM_Fun.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ORM_Fun.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ORM_Fun.dll"]