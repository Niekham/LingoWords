FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Lingowords.csproj", "./"]
COPY . .
RUN dotnet restore "./Lingowords.csproj"
WORKDIR "/src/."
RUN dotnet build "Lingowords.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lingowords.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["Resources/DUTCH.txt", "./Resources"]
COPY ["Resources/DTUCH_COMMON.txt", "./Resources"]
ENTRYPOINT ["dotnet", "Lingowords.dll", "--environment=Production"]
