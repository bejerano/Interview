# Plooto - Interview .NET Core REST API && ReactJS

Brief description of your project.

## Business Features

- **List Bills:** View all available bills.
- **View Payment History:** Access the history of paid bills.
- **Add New Payments:** Add new payment records.

## Technical Features

- **OData Support:** Enable querying and manipulation of data through OData.
- **Health Check:** Implement health checks for monitoring the application's status.
- **CORS Configuration:** Manage Cross-Origin Resource Sharing for enhanced security.
- **Throttling:** Implement request throttling to prevent abuse and optimize performance.

## Screenshots

![Screenshot 1](/screenshots/screenshot1.png)
*Caption for Screenshot 1.*

![Screenshot 2](/screenshots/screenshot2.png)
*Caption for Screenshot 2.*

## How to Execute the Project

### Database

1. Use SSMS or Azure Data Studio to connect to the SQL Server instance.
2. Connect to server with this credentials: 
    - Server: localhost,1433
    - Login: sa
    - Password: P@ssw0rd

Done, Yeah I know is simple

### Prerequisites

Make sure you have the following tools installed:

- [Docker](https://www.docker.com/)

### Using Docker Compose

1. Clone the repository:

    ```bash
    git clone https://github.com/plootoinc/BE-take-home-task-JoseBejerano.git
    ```

2. Navigate to the project directory (skip if just want to run the app):

    ```bash
    vscode ➜ /workspaces/Interviews (main) $cd cd Payment.Service.API -- API
    vscode ➜ /workspaces/Interviews (main) $cd cd web/plooto-billing  -- WebApp
    ```

3. Run the following command to start the project using Docker Compose:

    ```bash
    vscode ➜ /workspaces/Interviews (main) $ docker-compose -f docker-compose.yml -f docker-compose-override.yml  up --build -d 
    ```

   This command will build and start the containers defined in `docker-compose.yml`.

3. Run the following command to stop the project using Docker Compose:

    ```bash
    vscode ➜ /workspaces/Interviews (main) $ docker-compose -f docker-compose.yml -f docker-compose-override.yml  down
    vscode ➜ /workspaces/Interviews (main) $ docker system prune -a
    ```

   This command will stop  and remove the containers defined in `docker-compose.yml`.   

### Development Environment

#### Using Visual Studio Code with DevContainers

1. Open the project in Visual Studio Code.
2. Install the recommended extensions for DevContainers.
3. Click on the green pop-up at the bottom right (or use F1 and search for "Reopen in Container").
4. Visual Studio Code will automatically set up the development environment inside a container.

##### Configurations
1. Add the deveploment certificate config. 
```
vscode ➜ /workspaces/Interviews/Payment.Service.API (main) $  cd Payment.Service.API
vscode ➜ /workspaces/Interviews/Payment.Service.API (main) $  dotnet dev-certs https -t
```

2. To add changes to the database use EF Migrations
```

vscode ➜ /workspaces/Interviews/Payment.Service.API (main) $  cd Payment.Service.API

vscode ➜ /workspaces/Interviews/Payment.Service.API (main) $  dotnet tool update --global dotnet-ef

vscode ➜ /workspaces/Interviews/Payment.Service.API (main) $  dotnet ef migrations add Initial --context Plooto.Assessment.Payment.Infrastructure.PaymentContext -o ./Infrastructure/Migrations

vscode ➜ /workspaces/Interviews/Payment.Service.API (main) $ dotnet ef database update
```

## Assumptions

- List any assumptions made during the development of the project.

## Extras

- Any additional information you want to provide, such as future plans, known issues, or special thanks.












## Validation
Data validation using [FluentValidation](https://github.com/JeremySkinner/FluentValidation)

## Caching
Recommended Cache-Aside pattern and Redis cache. : Not Implemented

## Integration
Not Implemented

## Troubleshooting
Outbox Pattern implementation using [Quartz.NET](https://github.com/quartznet/quartznet)

#### Deployment in Docker
1. Create the aspnetapp.pfx certificate for local development
2. Update the docker-compose.override.yml file with the certificate path

 

# Start Logging Server
docker-compose -f docker-compose.elk.yml up

## Open browser
Kiabana: http://localhost:5601


# Swagger
https://127.0.0.1:7227/swagger/index.html


# Health Check 
1. https://127.0.0.1:7000/healthcheck
2. https://127.0.0.1:7000/dashboard#/healthchecks
