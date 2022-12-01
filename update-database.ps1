function Update-Database
{
    dotnet ef database update --startup-project .\src\Database --project .\src\Database.Core
}

Update-Database
