# Installation

## Prerequisites

- .NET SDK 8.0
- Docker
- Kubernetes (Docker Desktop, Minikube, or any other Kubernetes cluster)
- Postman (for API calls and testing)

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

3. You don't need to worry about Microsoft SQL Server in the local environment; we use an in-memory database instead. Microsoft SQL Server is used in the production environment (Kubernetes).

4. Build and run the services:

   ```bash
   cd <service>
   dotnet run
   ```

5. Make sure both the `PlatformService` and `CommandsService` are running. Then, use Postman to call API endpoints and perform actions.

## Running on Kubernetes

1. Deploy on Kubernetes:

    ```bash
    cd K8s
    kubectl apply -f .
    ```

2. Deploy Ingress Nginx Controller
    - Using Docker Desktop

        ```bash
        kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.11.1/deploy/static/provider/cloud/deploy.yaml
        ```

    - Using Minikube

        ```bash
        minikube addons enable ingress
        ```

3. Change the `hosts` file to point the `harmonia.com` host to the `127.0.0.1` address to use Nginx. If you're using Windows and have the `Dev Home` system app, you can use the `Hosts File Editor` utility, which is pretty straightforward.
4. If you're using `Minikube`, you will need to employ a `minikube tunnel` to utilize load balancer services. However, for those who are using `Docker Desktop`, the load balancer is natively supported.
