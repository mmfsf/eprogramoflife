FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app

EXPOSE 57519
EXPOSE 44373

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY epl.IdentityServer/epl.IdentityServer.csproj epl.IdentityServer/
RUN dotnet restore epl.IdentityServer/epl.IdentityServer.csproj
COPY . .
WORKDIR /src/epl.IdentityServer
RUN dotnet build epl.IdentityServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish epl.IdentityServer.csproj -c Release -o /app

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "epl.IdentityServer.dll"]
