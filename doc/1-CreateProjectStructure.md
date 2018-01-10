dotnet new sln
dotnet new razor    -o Apps/Web/Neptune.App.Web  --auth Individual -f netcoreapp2.0
dotnet new webapi   -o API/Web/Neptune.API.Web -f netcoreapp2.0
dotnet new xunit    -o API/Web/Neptune.API.Web.Tests -f netcoreapp2.0
dotnet new classlib -o API/Web/Neptune.API.Web.Models -f netcoreapp2.0
dotnet new webapi   -o API/Mobile/Neptune.API.Mobile -f netcoreapp2.0
dotnet new xunit    -o API/Mobile/Neptune.API.Mobile.Tests -f netcoreapp2.0
dotnet new classlib -o API/Mobile/Neptune.API.Mobile.Models -f netcoreapp2.0
dotnet new classlib -o API/Common/Neptune.API.Common -f netcoreapp2.0
dotnet new classlib -o Services/Databases/Neptune.Services.Databases -f netcoreapp2.0
dotnet new classlib -o Services/Databases/Neptune.Services.Databases.Messages -f netcoreapp2.0
dotnet new xunit    -o Services/Databases/Neptune.Services.Databases.Tests -f netcoreapp2.0

# App
dotnet add Apps/Web/Neptune.App.Web reference API/Web/Neptune.API.Web.Models/Neptune.API.Web.Models.csproj

# API.Web
dotnet add API/Web/Neptune.API.Web  reference API/Web/Neptune.API.Web.Models/Neptune.API.Web.Models.csproj
dotnet add API/Web/Neptune.API.Web  reference API/Common/Neptune.API.Common/Neptune.API.Common.csproj

# API.Mobile
dotnet add API/Mobile/Neptune.API.Mobile  reference API/Mobile/Neptune.API.Mobile.Models/Neptune.API.Mobile.Models.csproj
dotnet add API/Mobile/Neptune.API.Mobile  reference API/Common/Neptune.API.Common/Neptune.API.Common.csproj
dotnet sln add Apps/Web/Neptune.App.Web/Neptune.App.Web.csproj
dotnet sln add API/Web/Neptune.API.Web/Neptune.API.Web.csproj
dotnet sln add API/Mobile/Neptune.API.Mobile/Neptune.API.Mobile.csproj
dotnet sln add API/Common/Neptune.API.Common/Neptune.API.Common.csproj
dotnet sln add API/Web/Neptune.API.Web.Models/Neptune.API.Web.Models.csproj
dotnet sln add API/Mobile/Neptune.API.Mobile.Models/Neptune.API.Mobile.Models.csproj

# Databases
dotnet add API/Web/Neptune.API.Web							  reference Services/Databases/Neptune.Services.Databases.Messages/Neptune.Services.Databases.Messages.csproj
dotnet add API/Mobile/Neptune.API.Mobile                      reference Services/Databases/Neptune.Services.Databases.Messages/Neptune.Services.Databases.Messages.csproj
dotnet add Services/Databases/Neptune.Services.Databases        reference Services/Databases/Neptune.Services.Databases.Messages/Neptune.Services.Databases.Messages.csproj
dotnet add Services/Databases/Neptune.Services.Databases.Tests  reference Services/Databases/Neptune.Services.Databases/Neptune.Services.Databases.csproj
dotnet add Services/Databases/Neptune.Services.Databases.Tests  reference Services/Databases/Neptune.Services.Databases.Messages/Neptune.Services.Databases.Messages.csproj

dotnet sln add Services/Databases/Neptune.Services.Databases/Neptune.Services.Databases.csproj
dotnet sln add Services/Databases/Neptune.Services.Databases.Messages/Neptune.Services.Databases.Messages.csproj
dotnet sln add Services/Databases/Neptune.Services.Databases.Tests/Neptune.Services.Databases.Tests.csproj

mkdir Services/Databases/Neptune.Services.Databases/Handlers
mkdir Services/Databases/Neptune.Services.Databases/Data
mkdir Services/Databases/Neptune.Services.Databases/Database
