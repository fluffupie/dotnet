https://learn.microsoft.com/en-au/ef/core/miscellaneous/cli/dotnet

# Installing or Updating tools

dotnet tool install --global dotnet-ef
OR
dotnet tool update --global dotnet-ef

# Scaffold all Tables

dotnet ef dbcontext scaffold `
"Server=rmit.australiaeast.cloudapp.azure.com;Encrypt=False;Uid=demo_Northwind;Pwd=abc123;MultipleActiveResultSets=True" `
Microsoft.EntityFrameworkCore.SqlServer `
--no-onconfiguring `
--context-dir Data --context NorthwindContext --output-dir Models --force
