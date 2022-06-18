# Floward Task

**Refer the main repository -> https://github.com/aspnetrun/run-aspnetcore-microservices**

This repository is inspired by the below udemy course.

[![Screenshot_6](https://user-images.githubusercontent.com/1147445/85838002-907dc280-b7a1-11ea-8219-f84e3af8ba52.png)](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/?couponCode=FA24745CC57592AB612A)


See the overall picture of **implementations on microservices with .net tools** on real-world **e-commerce microservices** project;

![microservices_remastered](https://user-images.githubusercontent.com/1147445/110304529-c5b70180-800c-11eb-832b-a2751b5bda76.png)

There is a couple of microservices which implemented **e-commerce** modules over **Catalog, Basket and **Ordering** microservices with **NoSQL (MongoDB, Redis)** and **Relational databases (Sql Server)** with communicating over **RabbitMQ Event Driven Communication** and using **Ocelot API Gateway**.

**Refer the main repository -> https://github.com/aspnetrun/run-aspnetcore-microservices**

## Run The Project
You will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 5 or later](https://dotnet.microsoft.com/download/dotnet-core/5)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installing
Follow these steps to get your development environment set up: (Before Run Start the Docker Desktop)
1. Clone the repository
2. At the root directory which include **docker-compose.yml** files, run below command:
```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
3. Wait for docker compose all microservices. That’s it! (some microservices need extra time to work so please wait if not worked in first shut)

4. You can **launch microservices** as below urls:

* **Catalog API -> http://host.docker.internal:8000/swagger/index.html**
* **Basket API -> http://host.docker.internal:8001/swagger/index.html**
* **Ordering API -> http://host.docker.internal:8004/swagger/index.html**
* **API Gateway -> http://host.docker.internal:8010/Catalog**
* **Rabbit Management Dashboard -> http://host.docker.internal:15672**   -- guest/guest
* **Portainer -> http://host.docker.internal:9000**


>Note: If you are running this application in macOS then use `docker.for.mac.localhost` as DNS name in `.env` file and the above URLs instead of `host.docker.internal`.


## Documentation and Details:
**Design and Architectual Patterns used:**
- N-Tier Architecture in both Catalog and Basket Services
- Generic Repository Pattern (with ability to add query expressions for specification)
- Clean Architecture and Domain Driven Design in Order Service
- Event-driven Architecture and Async communication between services using RabbitMQ as the Message Broker
- Mediator and CQRS pattern using MediatR NuGet package in the Ordering Service
- Dependency Injection is used to ensure separation of concerns and loose coupling between all services and classes
- API Gateway Routing Pattern or BFF (Backend for frontend) which was implemented using Ocelot NuGet Package


## Authors
* **Islam Mahrous** - *Adaptation* - [Islam Mahrous](https://github.com/isl-mahrous)

## Mentors
* **Mehmet Ozkaya** - *Initial work* - [mehmetozkaya](https://github.com/mehmetozkaya)
