# Database Application
<!-- ![Build](https://github.com/soca-git/stocks-api/actions/workflows/build.yml/badge.svg)
![Tests](https://github.com/soca-git/stocks-api/actions/workflows/dotnet.yml/badge.svg) -->

> A personal project which aims to create an API-driven database application, which is intended to serve multiple projects.  
> Note: this project is continuously being updated; progress is tracked [here](https://github.com/users/soca-git/projects/1/views/1).

## Database Migrations
In order to propagate changes to the database from entity framework core, ```Microsoft.EntityFrameworkCore.Tools``` is installed into the startup project.

This exposes a set of commands in the package manager console:
```ps1
Add-Migration <desiredMigrationName>
Update-Database
```
Or alternatively, install the dotnet entity framework CLI:
```ps1
dotnet tool install --global dotnet-ef
```
And add migrations & update the database as follows:
```ps1
# add migration
dotnet ef migrations add <desiredMigrationName> --startup-project .src\Database --project .src\Database.Core
# update database
dotnet ef database update --startup-project .src\Database --project .src\Database.Core
```

## Docker & Heroku Deployment
The application is deployed via a Docker container to Heroku.  
The [Dockerfile](./Dockerfile) is generated through Visual Studio Container Tools (```Right-Click Host Project``` > ```Add``` > ```Docker Support```).

---
