FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Services/Identities/Neptune.Services.Identities/Neptune.Services.Identities.csproj Services/Identities/Neptune.Services.Identities/
COPY Services/Identities/Neptune.Services.Identities.Messages/Neptune.Services.Identities.Messages.csproj Services/Identities/Neptune.Services.Identities.Messages/
COPY Services/Common/Neptune.Services.Common/Neptune.Services.Common.csproj Services/Common/Neptune.Services.Common/
COPY Services/Identities/Neptune.Services.Identities.Database/Neptune.Services.Identities.Database.csproj Services/Identities/Neptune.Services.Identities.Database/
RUN dotnet restore
COPY . .
WORKDIR /src/Services/Identities/Neptune.Services.Identities
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Neptune.Services.Identities.dll"]
