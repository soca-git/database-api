function Add-Migration
{
    param 
    (
        [Parameter(Mandatory=$true)]
        $name
    )

    dotnet ef migrations add $name --startup-project .\src\Database --project .\src\Database.Core
}

Add-Migration($args[0])
