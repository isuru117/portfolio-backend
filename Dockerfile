FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App


COPY . ./

RUN dotnet restore portfolio-backend.sln

RUN dotnet publish -c Release -o out portfolio-backend.sln

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "PortfolioBackend.dll"]