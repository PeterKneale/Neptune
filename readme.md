# Neptune Overview
A sample dotnet core 2.0 application demonstrating a website and webapi communicating with microservices via a bus implemented upon EasyNetQ and RabbitMQ
Two docker compose environments combine to host the necessary infrastructure and applications.

## Architecture
- Web: ASP.NET Core MVC 
- WebAPI: ASP.NET Core Web API
- Micro-services: .NetCore executables connected to RabbitMQ accepting Commands, Requests/Responses and Events
  
### Identity Service
- Stores users identity, passwords, roles, groups etc.
- Backed is a SQL Server database 
- Dapper is used for sql execution

### Profile Service
- Stores users badges, notifications, reputation etc.
- Backed is a SQL Server database 
- Dapper is used for sql execution

### Search Service
- In response to events occuring, a Elastic Search index is updated.
- In response to queries, Elastic Search is searched and its results returned.
  
## Environment
- Two docker compose setups that share a common network
  - Infrastructure
    - RabbitMQ container
    - Elastic Search container
    - SqlServer Express for Linux container
    - Graylog / Mongo / Elastic Search container
  - Application
    - WebApp container
    - WebApi container
    - Identity container
    - Profile container
    - Search container