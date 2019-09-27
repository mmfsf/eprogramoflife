FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["epl.reactui/epl.reactui.csproj", "epl.reactui/"]
RUN dotnet restore "epl.reactui/epl.reactui.csproj"
COPY . .
WORKDIR "/src/epl.reactui"
RUN dotnet build "epl.reactui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "epl.reactui.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "epl.reactui.dll"]