# 🎁 ShopBridge Web API

This project is a web API built 100% using .NET 6.0.

The API was made considering the specifications availabe on Case Study For Backend Developers

---

## Setup your local machine
>Docker will be necessary

### Setup Database
The API persistence uses SQL Server 2022. Using SQL Server from Docker container is hightly recommended. The image can be downloaded running the command below on Terminal (Linux) or PowerShell (Windows):

```bash
docker run --name sqlserver -d --restart unless-stopped -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SuperAdmin10" -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest
```

> If you already have SQL Server running on your machine, be sure to change connection string with new host, user and password on `/src/ThinkBridge.ShopBridge.WebAPI/appsettings.json`.

For create the database and the tables with seed, use the scripts available at `/sql`.

---

## Running the Web API
### Run the Web API using docker-compose

After seting up the database, use docker compose to run the web API. navigate to `/docker` and run the command below on Terminal (Linux) or PowerShell (Windows)

```bach
docker-compose up
```
The API will run at address http://localhost:5000. To verify it is running correctly, access the API swagger at http://localhost:5000/swagger.

> If you need to change the some variable at `/src/ThinkBridge.ShopBridge.WebAPI/appsettings.json`, remember to delete the image `shopbridge-web-api` from your Docker, as the image contains a snapshot of this file.

### Run the Web API using command line

If you have dotnet SDK 6.0 installed on your machine, you can run the project from Terminal (Linux) or PowerShell (Windows).
Navigate to directory root and run the commands below:

```bash
dotnet build ThinkBridge.ShopBridge.sln
cd .\src\ThinkBridge.ShopBridge.WebAPI\
dotnet run
```

The API will run at the address specified on apllication logs. To verify it is running correctly, access the API swagger at [http://{{log.address}}/swagger]().

### Run the Web API using Visual Studio

If you have Visual Studio 2022 installed on your machine, you can run the project directly from it.
Open the solution `Strider.Posterr.sln`, set the project `ThinkBridge.ShopBridge.WebAPI` as startup project and run the project.

The API swagger will automatically open on your default browser.

---

If you have any question, enter in contact by the email [arthur@arthursoares.dev](mailto:arthur@arthursoares.dev).
