FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
EXPOSE 58960
EXPOSE 44355

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY epl.api/epl.api.csproj epl.api/
RUN dotnet restore epl.api/epl.api.csproj
COPY . .
WORKDIR /src/epl.api
RUN dotnet build epl.api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish epl.api.csproj -c Release -o /app

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "epl.api.dll"]
