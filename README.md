# Web API CRUD - Net 8
- https://github.com/Jonatandb/CrudAPINet8

### Setup: Set Codespaces secret:
- Go to https://github.com/settings/codespaces
- Add a secret named "CRUDAPINET8_NEONCONNECTIONSTRING" with a valid connection string to a PostgreSQL database in the format:
   - "Host=localhost;Database=store;Username=store_owner;Password=pass;SslMode=Require;Trust Server Certificate=true;"


### Run

```bash
dotnet ef database update (*required only the first time)
dotnet restore
dotnet run
```
Visit:
- http://localhost:5226/swagger


--- 

### Neon Database Project (Free PostgreSQL Database)
- https://console.neon.tech/app/projects/yellow-fog-04617934/branches/br-silent-hill-a8a5qfpq/tables?database=store