FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["back-EP26.csproj", "./"]
RUN dotnet restore "back-EP26.csproj"
COPY . .
RUN dotnet publish "back-EP26.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "back-EP26.dll"]
