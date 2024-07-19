# Installation

## Prerequisites

- .NET SDK 8.0
- Docker
- Kubernetes (Docker Desktop or any other Kubernetes cluster)
- kubectl
- RabbitMQ (for local development)
- MS SQL Server (for local development)
- Postman

## Running Locally

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

## Running on Kubernetes

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
