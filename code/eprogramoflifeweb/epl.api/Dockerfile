FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58960
EXPOSE 44355

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY epl.api/epl.api.csproj epl.api/
RUN dotnet restore epl.api/epl.api.csproj
COPY . .
WORKDIR /src/epl.api
RUN dotnet build epl.api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish epl.api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "epl.api.dll"]
