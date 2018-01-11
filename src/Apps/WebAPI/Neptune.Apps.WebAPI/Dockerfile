FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Apps/WebAPI/Neptune.Apps.WebAPI/Neptune.Apps.WebAPI.csproj Apps/WebAPI/Neptune.Apps.WebAPI/
COPY Apps/WebAPI/Neptune.Apps.WebAPI.Models/Neptune.Apps.WebAPI.Models.csproj Apps/WebAPI/Neptune.Apps.WebAPI.Models/
COPY Services/Profiles/Neptune.Services.Profiles.Messages/Neptune.Services.Profiles.Messages.csproj Services/Profiles/Neptune.Services.Profiles.Messages/
COPY Services/Common/Neptune.Services.Common/Neptune.Services.Common.csproj Services/Common/Neptune.Services.Common/
COPY Services/Search/Neptune.Services.Search.Messages/Neptune.Services.Search.Messages.csproj Services/Search/Neptune.Services.Search.Messages/
COPY Services/Questions/Neptune.Services.Questions.Messages/Neptune.Services.Questions.Messages.csproj Services/Questions/Neptune.Services.Questions.Messages/
COPY Services/Discussions/Neptune.Services.Discussions.Messages/Neptune.Services.Discussions.Messages.csproj Services/Discussions/Neptune.Services.Discussions.Messages/
COPY Services/Identities/Neptune.Services.Identities.Messages/Neptune.Services.Identities.Messages.csproj Services/Identities/Neptune.Services.Identities.Messages/
RUN dotnet restore
COPY . .
WORKDIR /src/Apps/WebAPI/Neptune.Apps.WebAPI
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Neptune.Apps.WebAPI.dll"]
