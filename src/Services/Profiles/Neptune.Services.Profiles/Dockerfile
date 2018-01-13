FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Services/Profiles/Neptune.Services.Profiles/Neptune.Services.Profiles.csproj Services/Profiles/Neptune.Services.Profiles/
COPY Services/Profiles/Neptune.Services.Profiles.Database/Neptune.Services.Profiles.Database.csproj Services/Profiles/Neptune.Services.Profiles.Database/
COPY Services/Common/Neptune.Services.Common/Neptune.Services.Common.csproj Services/Common/Neptune.Services.Common/
COPY Services/Profiles/Neptune.Services.Profiles.Messages/Neptune.Services.Profiles.Messages.csproj Services/Profiles/Neptune.Services.Profiles.Messages/
RUN dotnet restore
COPY . .
WORKDIR /src/Services/Profiles/Neptune.Services.Profiles
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Neptune.Services.Profiles.dll"]
