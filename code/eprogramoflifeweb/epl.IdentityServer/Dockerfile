FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

EXPOSE 57519
EXPOSE 44373

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY epl.IdentityServer/epl.IdentityServer.csproj epl.IdentityServer/
RUN dotnet restore epl.IdentityServer/epl.IdentityServer.csproj
COPY . .
WORKDIR /src/epl.IdentityServer
RUN dotnet build epl.IdentityServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish epl.IdentityServer.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "epl.IdentityServer.dll"]
