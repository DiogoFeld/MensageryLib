# build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY *.csproj ./

#restore
RUN dotnet restore
COPY . ./

# publish stage
RUN dotnet publish -c Release -o out

# Run stage
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "Api.dll" ]