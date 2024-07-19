# Harmonia

Welcome to the Harmonia project! This repository contains the source code for the Harmonia microservices application. Harmonia is a demo project to showcase how to build and deploy microservices using ASP.NET Core, RabbitMQ, gRPC, MS SQL, and Kubernetes.

## Table of Contents

- [Harmonia](#harmonia)
  - [Table of Contents](#table-of-contents)
  - [Overview](#overview)
  - [Technologies Used](#technologies-used)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Running Locally](#running-locally)
    - [Running on Kubernetes](#running-on-kubernetes)
  - [Services](#services)
  - [Contributing](#contributing)
  - [License](#license)

## Overview

Harmonia is a microservices-based application designed to demonstrate the integration of various modern technologies. It includes multiple services that communicate with each other using synchronous and asynchronous messaging.

## Technologies Used

- **ASP.NET Core**: For building the web APIs.

- **Entity Framework Core**: For database interactions.

- **RabbitMQ**: For asynchronous messaging between services.

- **gRPC**: For high-performance, language-agnostic remote procedure calls.

- **Kubernetes**: For container orchestration and management.

- **Docker**: For containerizing the services.

- **MS SQL**: For relational database management.

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine or on Kubernetes.

### Prerequisites

- .NET SDK 8.0
- Docker
- Kubernetes (Docker Desktop or any other Kubernetes cluster)
- kubectl
- RabbitMQ (for local development)
- MS SQL Server (for local development)
- Postman

### Running Locally

1. Clone the repository:

   ```bash
   git clone https://github.com/juvenstu/harmonia.git
   cd harmonia
   ```

2. Start RabbitMQ locally

    ```bash
    docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
    ```

3. Start MS SQL Server locally:

    ```bash
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Your_password123' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
    ```

4. Update the `appsettings.Development.json` files in each service to point to your local RabbitMQ instances.
5. Apply any pending database migrations:

    ```bash
    cd PlatformService
    dotnet ef database update
    ```

6. Build and run the services:

   ```bash
   dotnet run
   ```

Repeat for `CommandsService` services.

### Running on Kubernetes

1. Build Docker images for each service:

   ```bash
    docker build -t <username>/platformservice:latest -f .
    docker build -t <username>/commandsservice:latest -f .
    ```

2. Push the images to a container registry (e.g., Docker Hub)

    ```bash
    docker push <username>/platformservice:latest
    docker push <username>/commandsservice:latest
    ```

3. Deploy on Kubernetes using `K8s` folder:

    ```bash
    cd K8s
    kubectl apply -f .
    ```

4. Deploy Ingress Nginx Controller

    ```bash
    kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.11.1/deploy/static/provider/cloud/deploy.yaml```

## Services

- PlatformService: Manages platform-related data and operations.
- CommandsService: Handles command-related data and operations.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request if you have any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
