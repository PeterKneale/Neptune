FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Services/Hosts/Neptune.Services.MultiHost/Neptune.Services.MultiHost.csproj Services/Hosts/Neptune.Services.MultiHost/
COPY Services/Search/Neptune.Services.Search/Neptune.Services.Search.csproj Services/Search/Neptune.Services.Search/
COPY Services/Search/Neptune.Services.Search.Messages/Neptune.Services.Search.Messages.csproj Services/Search/Neptune.Services.Search.Messages/
COPY Services/Questions/Neptune.Services.Questions/Neptune.Services.Questions.csproj Services/Questions/Neptune.Services.Questions/
COPY Services/Questions/Neptune.Services.Questions.Messages/Neptune.Services.Questions.Messages.csproj Services/Questions/Neptune.Services.Questions.Messages/
COPY Services/Discussions/Neptune.Services.Discussions/Neptune.Services.Discussions.csproj Services/Discussions/Neptune.Services.Discussions/
COPY Services/Discussions/Neptune.Services.Discussions.Messages/Neptune.Services.Discussions.Messages.csproj Services/Discussions/Neptune.Services.Discussions.Messages/
COPY Services/Identities/Neptune.Services.Identities/Neptune.Services.Identities.csproj Services/Identities/Neptune.Services.Identities/
COPY Services/Identities/Neptune.Services.Identities.Messages/Neptune.Services.Identities.Messages.csproj Services/Identities/Neptune.Services.Identities.Messages/
COPY Services/Common/Neptune.Services.Common/Neptune.Services.Common.csproj Services/Common/Neptune.Services.Common/
COPY Services/Databases/Neptune.Services.Databases/Neptune.Services.Databases.csproj Services/Databases/Neptune.Services.Databases/
COPY Services/Questions/Neptune.Services.Questions.Database/Neptune.Services.Questions.Database.csproj Services/Questions/Neptune.Services.Questions.Database/
COPY Services/Profiles/Neptune.Services.Profiles.Database/Neptune.Services.Profiles.Database.csproj Services/Profiles/Neptune.Services.Profiles.Database/
COPY Services/Profiles/Neptune.Services.Profiles/Neptune.Services.Profiles.csproj Services/Profiles/Neptune.Services.Profiles/
COPY Services/Profiles/Neptune.Services.Profiles.Messages/Neptune.Services.Profiles.Messages.csproj Services/Profiles/Neptune.Services.Profiles.Messages/
RUN dotnet restore
COPY . .
WORKDIR /src/Services/Hosts/Neptune.Services.MultiHost
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Neptune.Services.MultiHost.dll"]
