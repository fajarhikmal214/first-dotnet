# First .NET API | Hello World

A simple ASP.NET Core Web API project demonstrating basic CRUD operations using Entity Framework Core with SQL Server.


## How to Run

### Run Manually (Local Development)

```bash
# 1. Restore and build the project
$ dotnet restore
$ dotnet build

# 2. Run the project
$ dotnet run
```

### Run with Docker (Local Development)


```bash
# 1. Create a Docker network
$ docker network create dotnet-network

# 2. Run SQL Server container
$ docker run \
  -e "ACCEPT_EULA=Y" \
  -e "SA_PASSWORD=YourStrong@Passw0rd" \
  -p 1433:1433 \
  --name sqlserver \
  --network dotnet-network \
  -d mcr.microsoft.com/mssql/server:2022-latest

# 3. Build the API image
$ docker build -t hello-world -f Docker/Dockerfile .

# 4. Run the API container
$ docker run -d \
  -p 5000:5000 \
  -e ASPNETCORE_ENVIRONMENT=Development \
  --network dotnet-network \
  hello-world:latest
```

