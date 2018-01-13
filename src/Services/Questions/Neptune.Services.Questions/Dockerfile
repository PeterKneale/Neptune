FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Services/Questions/Neptune.Services.Questions/Neptune.Services.Questions.csproj Services/Questions/Neptune.Services.Questions/
COPY Services/Questions/Neptune.Services.Questions.Database/Neptune.Services.Questions.Database.csproj Services/Questions/Neptune.Services.Questions.Database/
COPY Services/Questions/Neptune.Services.Questions.Messages/Neptune.Services.Questions.Messages.csproj Services/Questions/Neptune.Services.Questions.Messages/
COPY Services/Common/Neptune.Services.Common/Neptune.Services.Common.csproj Services/Common/Neptune.Services.Common/
RUN dotnet restore
COPY . .
WORKDIR /src/Services/Questions/Neptune.Services.Questions
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Neptune.Services.Questions.dll"]
