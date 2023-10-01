Interview .NET Core REST API CQRS implementation with raw SQL and DDD using Clean Architecture.
==============================================================
~~~~
## Description

## CQRS

Read Model - executing raw SQL scripts on database views objects (using [Dapper](https://github.com/StackExchange/Dapper)).

Write Model - Domain Driven Design approach (using Entity Framework Core).

Commands/Queries/Domain Events handling using [MediatR](https://github.com/jbogard/MediatR) library.

## Domain



## Validation
Data validation using [FluentValidation](https://github.com/JeremySkinner/FluentValidation)

## Caching
Using Cache-Aside pattern and in-memory cache.

## Integration
Outbox Pattern implementation using [Quartz.NET](https://github.com/quartznet/quartznet)

## Related blog articles

# Start Logging Server
docker-compose -f docker-compose.elk.yml up

## Open browser
Kiabana: http://localhost:5601

#Certificates
dotnet dev-certs https -t

#Migrations
dotnet tool update --global dotnet-ef
dotnet ef migrations add Initial --context Plooto.Assessment.Payment.Infrastructure.PaymentContext -o ./Infrastructure/Migrations
dotnet ef database update

# Deployment in Dockeer
1. Create the aspnetapp.pfx certificate for local development
2. Create the aspnetapp.pfx certificate for production
3. Create the aspnetapp.pfx certificate for staging

2. Run the docker-compose command:
docker-compose -f docker-compose.yml -f docker-compose-override.yml  up --build -d  

3. Release all containers Run the docker-compose command:
docker-compose -f docker-compose.yml -f docker-compose-override.yml  down

# Swagger
https://127.0.0.1:7227/swagger/index.html


# Health Check 
1. https://127.0.0.1:7000/healthcheck
2. https://127.0.0.1:7000/dashboard#/healthchecks

## How to run application


## How to run Integration Tests

