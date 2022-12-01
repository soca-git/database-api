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

---
