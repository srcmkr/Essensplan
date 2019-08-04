FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Essensplan/Essensplan.csproj", "Essensplan/"]
RUN dotnet restore "Essensplan/Essensplan.csproj"
COPY . .
WORKDIR "/src/Essensplan"
RUN dotnet build "Essensplan.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Essensplan.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Essensplan.dll"]