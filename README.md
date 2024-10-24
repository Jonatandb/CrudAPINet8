# Web API CRUD - Net 8
- https://github.com/Jonatandb/CrudAPINet8

### Setup:

#### Set connection string in `appsettings.json`:
 - Add this:
```csharp
  "ConnectionStrings": {
    "ProductDbContext": "Host=localhost;Database=store;Username=store_owner;Password=[pass];SslMode=Require;Trust Server Certificate=true;"
  }
```
#### OR Set Github Codespaces secret:
- Go to https://github.com/settings/codespaces
- Add a secret named "CRUDAPINET8_NEONCONNECTIONSTRING" with a valid connection string to a PostgreSQL database in the format:
   - "Host=localhost;Database=store;Username=store_owner;Password=[pass];SslMode=Require;Trust Server Certificate=true;"


### Run

```bash
dotnet restore
dotnet ef database update (*required only the first time)
dotnet run
```
Visit:
- http://localhost:5226/swagger 🎉


---

### Neon Database Project (Free PostgreSQL Database)
- https://console.neon.tech/app/projects/yellow-fog-04617934/branches/br-silent-hill-a8a5qfpq/tables?database=store

---

# Performed steps:
1: Project creation
```bash
dotnet new webapi -n CrudAPINet8 -controllers
```

2: Product model added:
- Models/Product.cs

3: Package installation:
```bash
dotnet tool install --global dotnet-ef
```
  - Tool to work with EFCore through the command line.

4: Package installation:
```bash
dotnet add package Microsoft.EntityFrameworkCore
```
  - ORM that allows to .NET work with several databases.

5: Package installation:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
  - Allows to manage migrations through DbContext.

6: Package installation:
```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```
  - PostgreSQL/Npgsql provider for EntityFrameworkCore.

7: Setting of conection string (choose one method/alternative):
  - Set connection string in `appsettings.json`:
    ```csharp
    "ConnectionStrings": {
        "ProductDbContext": "Host=localhost;Database=store;Username=store_owner;Password=[pass];SslMode=Require;Trust Server Certificate=true;"
    }
    ```
 - #### Github Codespaces secrets (environment variable):
    - Go to https://github.com/settings/codespaces
    - Add a secret named "CRUDAPINET8_NEONCONNECTIONSTRING" with a valid connection string to a PostgreSQL database in the format:
      - "Host=localhost;Database=store;Username=store_owner;Password=[pass];SslMode=Require;Trust Server Certificate=true;"

8: Update DbContext service configuration in `program.cs` to allow it to read connection string:
```csharp
var connectionString = Environment.GetEnvironmentVariable("CRUDAPINET8_NEONCONNECTIONSTRING")
                        ?? builder.Configuration.GetConnectionString("ProductDbContext");

builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(connectionString ?? throw new InvalidOperationException("Connection string 'ProductDbContext' not found.")));
```

9: Package installation:
```bash
dotnet tool install --global dotnet-aspnet-codegenerator
```
  - Code Generator of Controllers and Views for NetCore.

10: Package installation:
```bash
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```
  - Code Generator of Controllers and Views at project level.

11: Package installation:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
  - Package required by dotnet-aspnet-codegenerator.

12: Product controller generation:
```bash
dotnet-aspnet-codegenerator controller -name ProductController -api -outDir Controllers --model Product --dataContext ProductDbContext -async -actions
```
 - This command generates a controller named ProductController in the Controllers directory using the Product model and ProductDbContext data context. The controller is created with async methods and CRUD (Create, Read, Update, Delete) actions for the API.
   - https://learn.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-8.0

12: Package uninstall:
```bash
dotnet remove package Microsoft.EntityFrameworkCore.SqlServer
```
  - No longer needed package.

13: Migration generation:
```bash
dotnet ef migrations add InitialMigration
```

14: Database update (tables creation):
```bash
dotnet ef database update
```

15: Running the project:
```bash
dotnet run
```
Visit:
- http://localhost:5226/swagger 🎉
- http://localhost:5226/api/products

![Swagger screenshot](Swagger_Screenshot.png)
![JSON response screenshot](JSON_response.png)