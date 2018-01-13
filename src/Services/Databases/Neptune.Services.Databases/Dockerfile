FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Services/Databases/Neptune.Services.Databases/Neptune.Services.Databases.csproj Services/Databases/Neptune.Services.Databases/
COPY Services/Questions/Neptune.Services.Questions.Database/Neptune.Services.Questions.Database.csproj Services/Questions/Neptune.Services.Questions.Database/
COPY Services/Profiles/Neptune.Services.Profiles.Database/Neptune.Services.Profiles.Database.csproj Services/Profiles/Neptune.Services.Profiles.Database/
COPY Services/Common/Neptune.Services.Common/Neptune.Services.Common.csproj Services/Common/Neptune.Services.Common/
RUN dotnet restore
COPY . .
WORKDIR /src/Services/Databases/Neptune.Services.Databases
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Neptune.Services.Databases.dll"]
