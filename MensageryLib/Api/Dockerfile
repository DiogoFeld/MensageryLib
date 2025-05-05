# build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000
COPY --from=build /app/out .

ENTRYPOINT [ "dotnet", "Api.dll" ]