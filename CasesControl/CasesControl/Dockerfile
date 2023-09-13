FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CasesControl/CasesControl.csproj", "CasesControl/"]
RUN dotnet restore "CasesControl/CasesControl.csproj"
COPY . .
WORKDIR "/src/CasesControl"
RUN dotnet build "CasesControl.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CasesControl.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CasesControl.dll"]
