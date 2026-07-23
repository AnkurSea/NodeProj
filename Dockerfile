# Stage 1: Build & Publish
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["XUnitTest.csproj", "./"]
RUN dotnet restore "./XUnitTest.csproj"
COPY . .
RUN dotnet publish "XUnitTest.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "XUnitTest.dll"]