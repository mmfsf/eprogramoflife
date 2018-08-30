FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_8.x | bash - && \
    apt-get install -y build-essential nodejs
WORKDIR /app
EXPOSE 54139
EXPOSE 44386

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
