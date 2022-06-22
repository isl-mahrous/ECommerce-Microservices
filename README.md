# ECommerce Microservices

The projet consists of 4 microservices which implemented **e-commerce** modules over **Catalog**, **Inventory**,**Basket**, **Identity** and **Ordering** microservices with **NoSQL (MongoDB, Redis)** and **Relational databases (Sql Server)** with communicating over **RabbitMQ Event Driven Communication** and using **Ocelot API Gateway**.

## The Overall Picture of The Project:

![microservices](https://raw.githubusercontent.com/isl-mahrous/ECommerce-Microservices/master/Diagram.png)


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

4. If Identity Api service doesn't work correctly, it's recommended to restart it using Docker Desktop (Migration Problem On Slower PC's)

5. You can **launch microservices** as below urls:

* **Catalog API -> http://host.docker.internal:8000/swagger/index.html**
* **Basket API -> http://host.docker.internal:8001/swagger/index.html**
* **Identity API -> http://host.docker.internal:8003/swagger/index.html**
* **Ordering API -> http://host.docker.internal:8004/swagger/index.html**
* **API Gateway -> http://host.docker.internal:8010/Catalog**
* **Rabbit Management Dashboard -> http://host.docker.internal:15672**   -- guest/guest
* **Inventory API -> In Development**


## Documentation and Details:
**Design and Architectual Patterns used:**
- N-Tier Architecture in Catalog, Identity and Basket Services
- Generic Repository Pattern
- Sepecification Pattern
- Services Classes to be used inside Controllers to ensure minimal code inside each action
- Clean Architecture and Domain Driven Design in Order Service
- Event-driven Architecture and Async communication between services using RabbitMQ as the Message Broker
- Mediator and CQRS pattern using MediatR NuGet package in the Ordering Service (One Database However)
- Dependency Injection is used to ensure separation of concerns and loose coupling between all services and classes
- Backend for frontend(BFF) pattern implemented using Ocelot


## Authors
* **Islam Mahrous**  - [Islam Mahrous](https://github.com/isl-mahrous)



## Guidance
This repository is inspired by the below udemy course.

[![Screenshot_6](https://user-images.githubusercontent.com/1147445/85838002-907dc280-b7a1-11ea-8219-f84e3af8ba52.png)](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/?couponCode=FA24745CC57592AB612A)

