FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 54139
EXPOSE 44305

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY epl.ui/epl.ui.csproj epl.ui/
RUN dotnet restore epl.ui/epl.ui.csproj
COPY . .
WORKDIR /src/epl.ui
RUN dotnet build epl.ui.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish epl.ui.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "epl.ui.dll"]
